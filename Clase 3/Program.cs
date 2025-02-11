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
        
        //Analisis sintactico
        var listaTokens = new CommonTokenStream(analisisLexico);
        var analisiSintactico = new AnalizadorLexicoParser(listaTokens);
        
        var arbol = analisiSintactico.inicio();
        
        Visitor visitor = new Visitor();
        visitor.Visit(arbol);
        Console.WriteLine("-----------------------------------------");
        foreach (var consola in visitor.listaSalida) {
            Console.WriteLine(consola);
        }
        Console.WriteLine("-----------------------------------------");
    }
}
