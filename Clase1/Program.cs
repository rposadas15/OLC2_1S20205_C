using System;
using System.Collections.Generic;
using Antlr4.Runtime;

class Program {
    static void Main(string[] args) {
        var entrada = "(20 + 10)";
        var entradaParseada = new AntlrInputStream(entrada);

        //Analisis lexico
        var analisisLexico = new AnalizadorLexicoLexer(entradaParseada);
        // Manejar errores lexicos
        analisisLexico.RemoveErrorListeners();
        
        //Analisis sintactico
        var listaTokens = new CommonTokenStream(analisisLexico);
        var analisiSintactico = new AnalizadorLexicoParser(listaTokens);
        analisiSintactico.RemoveErrorListeners();
        
        AnalizadorLexicoParser.ProgContext arbol = analisiSintactico.prog();
        Visitor visitor = new Visitor();
        visitor.Visit(arbol);
    }
}
