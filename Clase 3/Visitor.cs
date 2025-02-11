using System.Net;
using Antlr4.Runtime.Misc;
using Microsoft.VisualBasic;

class Visitor : AnalizadorLexicoBaseVisitor<Object> {

    private Dictionary<string, Object> variables = new Dictionary<string, Object>();
    public List<Object> listaSalida = new List<Object>();

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
            Visit(context.variables());
        else if (context.asignacion() != null)
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

    /* VARIABLES */
    public override Object VisitDeclaracionVar([NotNull] AnalizadorLexicoParser.DeclaracionVarContext context)
    {
        string nombreVariable = context.PALABRA().GetText();
        string tipoVariable = context.tipo().GetText();
        Object valor = null;

        if (context.expr() != null)
            valor = Visit(context.expr());
        else 
            valor = ValorPorDefecto(tipoVariable);

        variables[nombreVariable] = valor;
        Console.WriteLine("Nombre de la variable " + nombreVariable + " valor " + valor);

        return true;
    }

    /* ASIGNACION */
    public override Object VisitAsignacionVar([NotNull] AnalizadorLexicoParser.AsignacionVarContext context) {
        string nombreVariable = context.PALABRA().GetText();
        string signo = context.GetChild(1).GetText();
        Object valor = Visit(context.expr());

        if (signo == ":=") {
            if (variables.ContainsKey(nombreVariable)) {
                Console.WriteLine("Error: La variable " + nombreVariable + " ya ha sido declarada.");
                return false;
            }

            variables[nombreVariable] = valor;
            Console.WriteLine("Nombre de la variable: " + nombreVariable + " valor: " + valor);
        } else if (signo == "=") {
            if (!variables.ContainsKey(nombreVariable))  {
                Console.WriteLine("Error: La variable " + nombreVariable + " no ha sido declarada.");
                return false;
            }
            
            var valorAntiguo = variables[nombreVariable];
            Console.WriteLine("Variable " + nombreVariable + " valor antiguo " + valorAntiguo + " nuevo valor: " + valor);
            variables[nombreVariable] = valor;
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
        return -999999999999999999;
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
        return null;
    }

    public override Object VisitExpreParentesis(AnalizadorLexicoParser.ExpreParentesisContext context) {
        Console.WriteLine("Encontro expresion en parentesis");
        return Visit(context.expr());
    }

    public override Object VisitIdExpresion([NotNull] AnalizadorLexicoParser.IdExpresionContext context) {
        Console.WriteLine("Variable: " + context.PALABRA().GetText());
        if (variables.ContainsKey(context.PALABRA().GetText()))  {
            return variables[context.PALABRA().GetText()];
        } else {
            Console.WriteLine("La variable " + context.PALABRA().GetText() + " no existe.");
            return null;
        }
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
