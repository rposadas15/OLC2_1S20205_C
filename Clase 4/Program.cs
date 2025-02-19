using System;
using System.Collections.Generic;
using Antlr4.Runtime;

class Program {
    static void Main(string[] args) {
        List<ErroresDTO> listaErrores = new List<ErroresDTO>();

        var entrada = "x := 10";
        var entradaParseada = new AntlrInputStream(entrada);

        //Analisis lexico
        var analisisLexico = new AnalizadorLexicoLexer(entradaParseada);
        analisisLexico.RemoveErrorListeners();
        analisisLexico.AddErrorListener(new CustomErrorListener(listaErrores, "Errores lexico"));
        
        //Analisis sintactico
        var listaTokens = new CommonTokenStream(analisisLexico);
        var analisiSintactico = new AnalizadorLexicoParser(listaTokens);
        analisiSintactico.RemoveErrorListeners();
        analisiSintactico.AddErrorListener(new CustomErrorListener(listaErrores, "Errores sintacticos"));
        
        var arbol = analisiSintactico.inicio();
        
        Visitor visitor = new Visitor(listaErrores);

        Console.WriteLine(arbol.ToStringTree());
        Console.WriteLine("-----------------------------------------");
        foreach (var consola in visitor.listaSalida) {
            Console.WriteLine(consola);
        }
        Console.WriteLine("-----------------------------------------");
    }

    public class CustomErrorListener : IAntlrErrorListener<IToken>, IAntlrErrorListener<int> {
        private readonly List<ErroresDTO> listaErrores;
        private readonly string tipoError;

        public CustomErrorListener(List<ErroresDTO> listaErrores, string tipoError) {
            this.listaErrores = listaErrores;
            this.tipoError = tipoError;
        }

        public void SyntaxError(TextWriter output, IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e) {
            listaErrores.Add(new ErroresDTO(tipoError, msg, line, charPositionInLine));
        }

        public void SyntaxError(TextWriter output, IRecognizer recognizer, int offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e) {
            listaErrores.Add(new ErroresDTO(tipoError, msg, line, charPositionInLine));
        }
    }

}
