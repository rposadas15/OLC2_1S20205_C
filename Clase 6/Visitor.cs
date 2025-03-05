using System.Net;
using System.Security.Cryptography.X509Certificates;
using Antlr4.Runtime;
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
        else if (context.instruccion_funciones() != null)
            Visit(context.instruccion_funciones());
        else if (context.instruccion_ejecutar_funciones() != null)
            Visit(context.instruccion_ejecutar_funciones());

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
        Object valor;

        if (context.expr() != null)
            valor = Visit(context.expr());
        else 
            valor = ValorPorDefecto(tipoVariable);

        entorno.guardarVariable(nombreVariable, new SimbolosDTO(nombreVariable, tipoVariable, valor));
        Console.WriteLine("Nombre de la variable " + nombreVariable + " valor " + valor);

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
    public override Object VisitInstruccion_if([NotNull] AnalizadorLexicoParser.Instruccion_ifContext context) {
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

    /* INSTRUCCION FUNCION */
    public override Object VisitInstruccion_funciones([NotNull] AnalizadorLexicoParser.Instruccion_funcionesContext context) {
        Console.WriteLine(context.PALABRA().GetText());
        Dictionary<string, SimbolosDTO> parametros = new Dictionary<string, SimbolosDTO>();
        List<String> tipoParametros = new ArrayList<string>();

        if (context.parametros_funciones() != null) {
            var parametrosContext = context.parametros_funciones();
            var expresiones = parametrosContext.expr();
            var tipos = parametrosContext.tipo();

            for (int i = 0; i < expresiones.Length; i++) {
                string nombreParametro = expresiones[i].GetText();
                string tipoParametro = tipos[i].GetText();

                parametros.Add(nombreParametro, new SimbolosDTO(nombreParametro, tipoParametro));
                tipoParametros.Add(tipoParametro);
            }
        }
        string tipoRetorno = context.retornarTipo != null ? context.retornarTipo.GetText() : "void";
        SimbolosDTO retornar = new SimbolosDTO("retornar_" + context.PALABRA().GetText(), tipoRetorno);
        parametros.Add("retornar_" + context.PALABRA().GetText(), retornar);

        FuncionDTO funcion = new FuncionDTO(context.PALABRA().GetText(), parametros,context.listainstrucciones(),tipoParametros,retornar);
        pilaEntornos.Peek().guardarVariable(context.PALABRA().GetText(), new SimbolosDTO(context.PALABRA().GetText(), "Funcion", funcion));
        
        Console.WriteLine("Función registrada exitosamente: " + context.PALABRA().GetText());
        return true;
    }

    /* INSTRUCCION EJECUTAR FUNCION */
    public override object VisitInstruccion_ejecutar_funciones([NotNull] AnalizadorLexicoParser.Instruccion_ejecutar_funcionesContext context) {
        EntornoDTO entorno = pilaEntornos.Peek();
        SimbolosDTO? simbolo = entorno.buscarVariable(context.PALABRA().GetText());

        Console.WriteLine("entro");
        if (simbolo != null && simbolo.valor is FuncionDTO funcion) {
            EntornoDTO entornoFuncion = new EntornoDTO("Funcion", entorno);
            
            pilaEntornos.Push(entornoFuncion);
            VisitListainstrucciones(funcion.instrucciones);
            pilaEntornos.Pop();
            pilaEntornos.Peek().punteroASiguiente = null;

            if (funcion.retorno != null) {
                if (funcion.retorno.valor != null) {
                    return funcion.retorno.valor;
                }
            }

            return true;
        } else {
            return $"ERROR SEMÁNTICO: La función {context.PALABRA().GetText()} no existe en el entorno actual.";
        }
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
        return "NULL";
    }

    public override Object VisitExpreParentesis(AnalizadorLexicoParser.ExpreParentesisContext context) {
        Console.WriteLine("Encontro expresion en parentesis");
        return Visit(context.expr());
    }

    public override Object VisitIdExpresion([NotNull] AnalizadorLexicoParser.IdExpresionContext context) {
        EntornoDTO entorno = pilaEntornos.Peek();
        SimbolosDTO? simbolo = entorno.buscarVariable(context.PALABRA().GetText());

        Console.WriteLine("Variable: " + context.PALABRA().GetText());
        if (simbolo != null)  {
            if (simbolo.valor != null)
                return simbolo.valor;
            return "NULL NO ESTA DECLARADA LA VARIABLE EN EL ENTORNO ACTUAL";    
        } else {
            Console.WriteLine("La variable " + context.PALABRA().GetText() + " no existe.");
            return "NULL NO ESTA DECLARADA LA VARIABLE EN EL ENTORNO ACTUAL";
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

    public override object VisitEjecutarFunciones([NotNull] AnalizadorLexicoParser.EjecutarFuncionesContext context) {
        return VisitInstruccion_ejecutar_funciones(context.instruccion_ejecutar_funciones());
    }

}
