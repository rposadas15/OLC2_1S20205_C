using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using System;
using System.Collections.Generic;
using System.IO;

class Visitor : AnalizadorLexicoBaseVisitor<Object> {

    private Dictionary<string, Object> variables = new Dictionary<string, Object>();
    public List<Object> listaSalida = new List<Object>();
    private StreamWriter writer;

    public Visitor() {
        writer = new StreamWriter("clase11.s");  // Abre un archivo .s para escribir el código ASM64
        writer.AutoFlush = true;  // Asegúrate de que el archivo se vacíe inmediatamente
        writer.WriteLine("section .data"); // Añade la sección de datos al principio
        writer.WriteLine("section .text"); // Añadir la sección de texto
        writer.WriteLine("global _start"); // Definir el punto de entrada
        writer.WriteLine("_start:"); // Añadir la etiqueta de inicio
    }

    public void Finalizar() {
        writer.Close();
    }

    /* INICIO */
    public override Object VisitInicio([NotNull] AnalizadorLexicoParser.InicioContext context) {
        if (context.listainstrucciones() != null) {
            return VisitListainstrucciones(context.listainstrucciones());
        }
        return true;
    }

    public override Object VisitListainstrucciones([NotNull] AnalizadorLexicoParser.ListainstruccionesContext context) {
        if (context.instruccion() == null)
            return true;

        foreach (AnalizadorLexicoParser.InstruccionContext instruccion in context.instruccion()) {
            if (instruccion != null) {
                VisitInstruccion(instruccion);
            }
        }
        return true;
    }

    public override Object VisitInstruccion([NotNull] AnalizadorLexicoParser.InstruccionContext context) {
        if (context.print != null)
            Visit(context.print());
        else if (context.variables != null)
            Visit(context.variables());
        else if (context.asignacion != null)
            Visit(context.asignacion());
        return true;
    }

    /* IMPRIMIR */
    public override Object VisitPrint([NotNull] AnalizadorLexicoParser.PrintContext context) {
        if (context.expr() != null) {
            Object consola = Visit(context.expr());
            listaSalida.Add(consola);

            // Generar el código ASM64 para imprimir en consola
            if (consola is int) {
                writer.WriteLine($"    ; Imprimiendo valor entero: {consola}");
                writer.WriteLine($"    mov rdi, fmt_int      ; Cargar formato de entero");
                writer.WriteLine($"    mov rsi, {consola}    ; Cargar valor de {consola}");
                writer.WriteLine($"    call printf           ; Llamar a printf para imprimir el entero");
            } else if (consola is string) {
                writer.WriteLine($"    ; Imprimiendo cadena: {consola}");
                writer.WriteLine($"    mov rdi, fmt_str      ; Cargar formato de cadena");
                writer.WriteLine($"    mov rsi, {consola}    ; Cargar dirección de la cadena");
                writer.WriteLine($"    call printf           ; Llamar a printf para imprimir la cadena");
            }
        }
        return true;
    }

    /* DECLARACION */
    public override Object VisitDeclaracionVar([NotNull] AnalizadorLexicoParser.DeclaracionVarContext context) {
        string nombreVariable = context.PALABRA().GetText();
        string tipoVariable = context.tipo().GetText();
        Object valor = null;

        if (context.expr() != null)
            valor = Visit(context.expr());
        else 
            valor = ObtenerValorPorDefecto(tipoVariable);

        variables[nombreVariable] = valor;

        // Generar la declaración de la variable en ASM64
        writer.WriteLine($"    ; Declarando variable {nombreVariable} de tipo {tipoVariable}");
        if (tipoVariable == "int") {
            writer.WriteLine($"    mov rax, {valor}       ; Asignar valor {valor} a {nombreVariable}");
            writer.WriteLine($"    mov [{nombreVariable}], rax   ; Guardar valor en memoria");
        } else if (tipoVariable == "float64") {
            writer.WriteLine($"    movsd xmm0, qword [{valor}] ; Asignar valor float64 {valor} a {nombreVariable}");
        } else if (tipoVariable== "string") {
            writer.WriteLine($"    mov [2000], =Mensaje [{valor}] ; Asignar valor float64 {valor} a {nombreVariable}");
        }
        } else {
            throw new Exception($"Tipo desconocido: {tipoVariable}");
        }

        return true;
    }

    private Object ObtenerValorPorDefecto(string tipo) {
        return tipo switch
        {
            "int" => 0,
            "float64" => 0.0,
            "string" => "",
            "bool" => false,
            "rune" => '\0',
            _ => throw new Exception($"Tipo desconocido: {tipo}")
        };
    }

    /* ASIGNACION */
    public override Object VisitAsignacionVar([NotNull] AnalizadorLexicoParser.AsignacionVarContext context) {
        string nombreVariable = context.PALABRA().GetText();
        string signo = context.GetChild(1).GetText();
        Object valor = Visit(context.expr());

        if (signo == ":=") {
            if (variables.ContainsKey(nombreVariable)) 
                throw new Exception("Error: La variable " + nombreVariable + " ya ha sido declarada.");

            variables[nombreVariable] = valor;
            writer.WriteLine($"    ; Asignando valor {valor} a la variable {nombreVariable}");
            if (valor is int) {
                writer.WriteLine($"    mov rax, {valor}        ; Asignar valor {valor} a {nombreVariable}");
                writer.WriteLine($"    mov [{nombreVariable}], rax  ; Guardar valor en memoria");
            }
        } else if (signo == "=") {
            if (!variables.ContainsKey(nombreVariable)) 
                throw new Exception("Error: La variable " + nombreVariable + " no ha sido declarada.");

            var valorAntiguo = variables[nombreVariable];
            variables[nombreVariable] = valor;
            writer.WriteLine($"    ; Asignando nuevo valor {valor} a la variable {nombreVariable}");
            if (valor is int) {
                writer.WriteLine($"    mov rax, {valor}        ; Asignar nuevo valor {valor} a {nombreVariable}");
                writer.WriteLine($"    mov [{nombreVariable}], rax  ; Guardar nuevo valor en memoria");
            }
        }

        return true;
    }

    /* EXPR */
    public override Object VisitMultiplicacionYdivision([NotNull] AnalizadorLexicoParser.MultiplicacionYdivisionContext context) {
        string operador = context.GetChild(1).GetText();
        int left = (int) Visit(context.expr(0));
        int right = (int) Visit(context.expr(1));
        if (operador == "*") {
            writer.WriteLine($"    ; Multiplicando {left} * {right}");
            writer.WriteLine($"    mov rax, {left}       ; Cargar valor izquierdo");
            writer.WriteLine($"    imul rax, {right}    ; Multiplicar");
            return left * right;
        } else if (operador == "/") {
            writer.WriteLine($"    ; Dividiendo {left} / {right}");
            writer.WriteLine($"    mov rax, {left}       ; Cargar valor izquierdo");
            writer.WriteLine($"    mov rbx, {right}      ; Cargar valor derecho");
            writer.WriteLine($"    xor rdx, rdx          ; Limpiar el registro de división");
            writer.WriteLine($"    div rbx               ; Dividir");
            return left / right;
        }
        return -999999999999999999;
    }

    public override Object VisitSumaYresta([NotNull] AnalizadorLexicoParser.SumaYrestaContext context) {
        string operador = context.GetChild(1).GetText();
        int left = (int) Visit(context.expr(0));
        int right = (int) Visit(context.expr(1));
        if (operador == "+") {
            writer.WriteLine($"    ; Sumando {left} + {right}");
            writer.WriteLine($"    mov rax, {left}       ; Cargar valor izquierdo");
            writer.WriteLine($"    add rax, {right}     ; Sumar");
            return left + right;
        } else if (operador == "-") {
            writer.WriteLine($"    ; Restando {left} - {right}");
            writer.WriteLine($"     mov rax, {left}      ; Cargar valor izquierdo");
            writer.WriteLine($"    sub rax, {right}     ; Restar");
            return left - right;
        }
        return -999999999999999999;
    }

    public override Object VisitIntExpresion([NotNull] AnalizadorLexicoParser.IntExpresionContext context) {
        return int.Parse(context.INT().GetText()); 
    }

    public override Object VisitIdExpresion([NotNull] AnalizadorLexicoParser.IdExpresionContext context) {
        return context.GetText();
    }

    public override Object VisitCadenaExpresion([NotNull] AnalizadorLexicoParser.CadenaExpresionContext context) {
        return context.GetText();
    }

    public override Object VisitExpreParentesis(AnalizadorLexicoParser.ExpreParentesisContext context) {
        return Visit(context.expr());
    }
}
