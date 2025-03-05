using System;
using System.Collections.Generic;
using Antlr4.Runtime;

class Program {
    static void Main(string[] args) {
        List<ErroresDTO> listaErrores = new List<ErroresDTO>();

        var entrada = "func suma () { fmt.Println(\"funcion suma\") }  suma();";
        var entradaParseada = new AntlrInputStream(entrada);

        //Analisis lexico
        var analisisLexico = new AnalizadorLexicoLexer(entradaParseada);
        analisisLexico.RemoveErrorListeners();
        
        //Analisis sintactico
        var listaTokens = new CommonTokenStream(analisisLexico);
        var analisiSintactico = new AnalizadorLexicoParser(listaTokens);
        analisiSintactico.RemoveErrorListeners();
        
        var arbol = analisiSintactico.inicio();
        
        EntornoDTO entornoInicial = new EntornoDTO("main", null);
        Visitor visitor = new Visitor(entornoInicial);

        visitor.Visit(arbol);
        //Console.WriteLine(arbol.ToStringTree());
        Console.WriteLine("-----------------------------------------");
        foreach (var consola in visitor.listaSalida) {
            Console.WriteLine(consola);
        }
        Console.WriteLine("-----------------------------------------");
    }
}
