using Antlr4.Runtime.Misc;

class Visitor : AnalizadorLexicoBaseVisitor<Object> {

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

    public override object VisitSumaYresta([NotNull] AnalizadorLexicoParser.SumaYrestaContext context) {
        string operador = context.GetChild(1).GetText();
        int left = (int) Visit(context.expr(0));
        int rigth = (int) Visit(context.expr(1));
        if (operador == "+") {
            Console.WriteLine(left + " + " + rigth);
            return left + rigth;
        } else if (operador == "-") {
            Console.WriteLine(left + " - " + rigth);
            return left - rigth;
        }
        return -999999999999999999;
    }

    public override Object VisitIntExpresion([NotNull] AnalizadorLexicoParser.IntExpresionContext context) {
        Console.WriteLine(context.GetText());
        return int.Parse(context.INT().GetText()); 
    }

    public override Object VisitExpreParentesis(AnalizadorLexicoParser.ExpreParentesisContext context) {
        Console.WriteLine("Encontro expresion en parentesis");
        return Visit(context.expr());
    }

}