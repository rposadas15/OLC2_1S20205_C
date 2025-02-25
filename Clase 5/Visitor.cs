using System.Net;
using Antlr4.Runtime.Misc;
using Microsoft.VisualBasic;

class Visitor : AnalizadorLexicoBaseVisitor<Object> {

    public Stack<EntornoDTO> pilaEntornos = new Stack<EntornoDTO>();
    public EntornoDTO entornoInicial;
    public List<Object> listaSalida = new List<Object>();

    public Visitor(EntornoDTO entorno) {
        this.entornoInicial = entorno;
        pilaEntornos.Push(entorno);
    }

    /* INICIO */
    public override Object VisitInicio([NotNull] AnalizadorLexicoParser.InicioContext context)
    {
        if (context.listainstrucciones() != null) {
            return VisitListainstrucciones(context.listainstrucciones());
        }
        return true;
    }

    public override Object VisitListainstrucciones([NotNull] AnalizadorLexicoParser.ListainstruccionesContext context)
    {
        if (context.instruccion() == null)
            return true;

        foreach (AnalizadorLexicoParser.InstruccionContext instruccion in context.instruccion()) {
            VisitInstruccion(instruccion);
        }
        return true;
    }

    public override Object VisitInstruccion([NotNull] AnalizadorLexicoParser.InstruccionContext context) {
        if (context == null) 
            return false;

        if (context.print() != null) 
            Visit(context.print());
        else if (context.variables() != null) 
            //BreakDTO instanciaBreak = (BreakDTO) Visit(context.variables());
            Visit(context.variables());            
        else if (context.asignacion() != null)
            Visit(context.asignacion());
        else if (context.instruccion_if() != null)
            Visit(context.instruccion_if());

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

    /* VARIABLES */
    public override Object VisitDeclaracionVar([NotNull] AnalizadorLexicoParser.DeclaracionVarContext context) {
        EntornoDTO entorno = pilaEntornos.Peek();
        string nombreVariable = context.PALABRA().GetText();
        string tipoVariable = context.tipo().GetText();
        Object? valor = null;

        if (!entorno.variables.ContainsKey(nombreVariable)) {
            if (context.expr() != null)
                valor = Visit(context.expr());
            else 
                valor = ValorPorDefecto(tipoVariable);

            entorno.guardarVariable(nombreVariable, new SimbolosDTO(nombreVariable, tipoVariable, valor));
            Console.WriteLine("Nombre de la variable " + nombreVariable + " valor " + valor);
        }
        return true;//new BreakDTO("continue");
    }

    /* ASIGNACION */
    public override Object VisitAsignacionVar([NotNull] AnalizadorLexicoParser.AsignacionVarContext context) {
        EntornoDTO entorno = pilaEntornos.Peek();
        string nombreVariable = context.PALABRA().GetText();
        string signo = context.GetChild(1).GetText();
        Object valor = Visit(context.expr());

        if (signo == ":=") {
            if (!entorno.variables.ContainsKey(nombreVariable)) {
                if (context.expr() != null)
                    valor = Visit(context.expr());
                /*else 
                    valor = ValorPorDefecto(valor.GetType());*/

                entorno.guardarVariable(nombreVariable, new SimbolosDTO(nombreVariable, "int", valor));
                Console.WriteLine("Nombre de la variable " + nombreVariable + " valor " + valor);
            }
        } else if (signo == "=") {
            entorno.actualizarValorSimbolo(nombreVariable, valor);
        }
        return true;
    }

    public Object ValorPorDefecto(string tipo) {
        return tipo switch {
            "int" => 0,
            "float64" => 0.0,
            "string" => "",
            "bool" => false,
            "rune" => "\0",
            _ => throw new Exception("Tipo desconocido")
        };
    }

    /* INSTUCCION IF */
    public override object VisitInstruccion_if([NotNull] AnalizadorLexicoParser.Instruccion_ifContext context) {
        // validar expresion (tiene que existir y ser de tipo bool)
        if ((bool) Visit(context.expr())) {
            EntornoDTO entorno = new EntornoDTO("If", pilaEntornos.Peek());
            pilaEntornos.Peek().punteroASiguiente = entorno;
            pilaEntornos.Push(entorno);
            VisitListainstrucciones(context.listainstrucciones());
            pilaEntornos.Pop();
            pilaEntornos.Peek().punteroASiguiente = null;            
        }
        return "";
    }

    /* EXPRESIONES */
    public override Object VisitMultiplicacionYdivision([NotNull] AnalizadorLexicoParser.MultiplicacionYdivisionContext context) {
        string operador = context.GetChild(1).GetText();
        int left = (int) Visit(context.expr(0));
        int rigth = (int) Visit(context.expr(1));
        if (operador == "*") {
            Console.WriteLine(left + " * " + rigth);
            Console.WriteLine(left * rigth);
            return left * rigth;
        } else if (operador == "/") {
            Console.WriteLine(left + " / " + rigth);
            Console.WriteLine(left / rigth);
            return left / rigth;
        }
        return "-999999999999999999";
    }

    public override Object VisitSumaYresta([NotNull] AnalizadorLexicoParser.SumaYrestaContext context) {
        string operador = context.GetChild(1).GetText();
        int left = (int) Visit(context.expr(0));
        int rigth = (int) Visit(context.expr(1));
        if (operador == "+") {
            return left + rigth;
        } else if (operador == "-") {
            Console.WriteLine(left + " - " + rigth);
            return left - rigth;
        }
        return -999999999999999999;
    }

    public override Object VisitIntExpresion([NotNull] AnalizadorLexicoParser.IntExpresionContext context) {
        return int.Parse(context.INT().GetText()); 
    }

    public override Object VisitDecimalExpresion([NotNull] AnalizadorLexicoParser.DecimalExpresionContext context) {
        return float.Parse(context.DECIMAL().GetText());
    }

    public override object VisitCaracterExpresion([NotNull] AnalizadorLexicoParser.CaracterExpresionContext context) {
        return context.GetText();
    }

    public override object VisitBoleanExpresion([NotNull] AnalizadorLexicoParser.BoleanExpresionContext context) {
        if (context.BOOL().GetText() == "true")
            return true;
        else if (context.BOOL().GetText() == "false")
            return false;
        return "NULL";
    }

    public override Object VisitExpreParentesis(AnalizadorLexicoParser.ExpreParentesisContext context) {
        Console.WriteLine("Encontro expresion en parentesis");
        return Visit(context.expr());
    }

    public override Object VisitIdExpresion([NotNull] AnalizadorLexicoParser.IdExpresionContext context) {
        EntornoDTO entorno = pilaEntornos.Peek();
        SimbolosDTO? simbolo = entorno.buscarVariable(context.PALABRA().GetText());
        if (simbolo != null)  {
            return simbolo.valor;
        } 
        return "NULL";
    }

    public override Object VisitCadenaExpresion([NotNull] AnalizadorLexicoParser.CadenaExpresionContext context) {
        Console.WriteLine(context.GetText());
        return context.GetText();
    }

    public override Object VisitOperadorLogico([NotNull] AnalizadorLexicoParser.OperadorLogicoContext context) {
        string operador = context.GetChild(1).GetText();
        dynamic left = Visit(context.left);
        dynamic right = Visit(context.right);

        return operador switch {
            "&&" => left == right,
            "||" => left != right,
            _ => throw new Exception("Operador logico no reconocido: " + operador)
        };
    }

    public override Object VisitOperadorNegacion([NotNull] AnalizadorLexicoParser.OperadorNegacionContext context) {
        if ((bool) Visit(context.right)) 
            return false;
        else 
            return true;
    }

    public override Object VisitOperadorRelacional([NotNull] AnalizadorLexicoParser.OperadorRelacionalContext context) {
        string operador = context.GetChild(1).GetText();
        dynamic left = Visit(context.left);
        dynamic right = Visit(context.right);

        return operador switch {
            "==" => left == right,
            "!=" => left != right,
            ">"  => left > right,
            ">=" => left >= right,
            "<"  => left < right,
            "<=" => left <= right,
            _ => throw new Exception("Operador relacional no reconocido: " + operador)
        };
    }

}
