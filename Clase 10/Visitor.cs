using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using System;
using System.Collections.Generic;

class Visitor : AnalizadorLexicoBaseVisitor<Object> {

    private Dictionary<string, Object> variables = new Dictionary<string, Object>();
    public List<Object> listaSalida = new List<Object>();

    /* INICIO */
    public override Object VisitInicio([NotNull] AnalizadorLexicoParser.InicioContext context) {
        // Validar que context.listainstrucciones() no sea null antes de llamar Visit
        if (context.listainstrucciones() != null) {
            return VisitListainstrucciones(context.listainstrucciones());
        }
        return true;
    }

    public override Object VisitListainstrucciones([NotNull] AnalizadorLexicoParser.ListainstruccionesContext context) {
        if (context.instruccion() == null)
            return true;

        foreach (AnalizadorLexicoParser.InstruccionContext instruccion in context.instruccion()) {
            // Validar si la instrucción es null antes de visitar
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
        Console.WriteLine("Nombre de la variable: " + nombreVariable + " valor: " + valor);

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
            Console.WriteLine("Nombre de la variable: " + nombreVariable + " valor: " + valor);
        } else if (signo == "=") {
            if (!variables.ContainsKey(nombreVariable)) 
                throw new Exception("Error: La variable " + nombreVariable + " no ha sido declarada.");

            var valorAntiguo = variables[nombreVariable];
            Console.WriteLine("Variable " + nombreVariable + " valor antiguo " + valorAntiguo + " nuevo valor: " + valor);
            variables[nombreVariable] = valor;
        }
        return true;
    }

    /* EXPR */
    public override Object VisitMultiplicacionYdivision([NotNull] AnalizadorLexicoParser.MultiplicacionYdivisionContext context) {
        string operador = context.GetChild(1).GetText();
        int left = (int) Visit(context.expr(0));
        int right = (int) Visit(context.expr(1));
        if (operador == "*") {
            Console.WriteLine(left + " * " + right);
            Console.WriteLine(left * right);
            return left * right;
        } else if (operador == "/") {
            Console.WriteLine(left + " / " + right);
            Console.WriteLine(left / right);
            return left / right;
        }
        return -999999999999999999;
    }

    public override Object VisitSumaYresta([NotNull] AnalizadorLexicoParser.SumaYrestaContext context) {
        string operador = context.GetChild(1).GetText();
        int left = (int) Visit(context.expr(0));
        int right = (int) Visit(context.expr(1));
        if (operador == "+") {
            Console.WriteLine(left + " + " + right);
            return left + right;
        } else if (operador == "-") {
            Console.WriteLine(left + " - " + right);
            return left - right;
        }
        return -999999999999999999;
    }

    public override Object VisitIntExpresion([NotNull] AnalizadorLexicoParser.IntExpresionContext context) {
        Console.WriteLine(context.GetText());
        return int.Parse(context.INT().GetText()); 
    }

    public override Object VisitIdExpresion([NotNull] AnalizadorLexicoParser.IdExpresionContext context) {
        Console.WriteLine(context.GetText());
        return context.GetText();
    }

    public override Object VisitCadenaExpresion([NotNull] AnalizadorLexicoParser.CadenaExpresionContext context) {
        Console.WriteLine(context.GetText());
        return context.GetText();
    }

    public override Object VisitExpreParentesis(AnalizadorLexicoParser.ExpreParentesisContext context) {
        Console.WriteLine("Encontro expresion en parentesis");
        return Visit(context.expr());
    }
}
