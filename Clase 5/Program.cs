using System;
using System.Collections.Generic;
using Antlr4.Runtime;

class Program {
    static void Main(string[] args) {
        List<ErroresDTO> listaErrores = new List<ErroresDTO>();

        var entrada = "if (10 == 10) then var primero int = 99 fmt.Println(primero) " +
                        "fmt.Println(\"La igualdad es correcta\") end if fmt.Println(primero)";
        var entradaParseada = new AntlrInputStream(entrada);
        //Analisis lexico
        var analisisLexico = new AnalizadorLexicoLexer(entradaParseada);
        
        //Analisis sintactico
        var listaTokens = new CommonTokenStream(analisisLexico);
        var analisiSintactico = new AnalizadorLexicoParser(listaTokens);
        
        var arbol = analisiSintactico.inicio();
        
        EntornoDTO entornoInicial = new EntornoDTO("Primero", null);        
        Visitor visitor = new Visitor(entornoInicial);

        visitor.Visit(arbol);
        Console.WriteLine("-----------------------------------------");
        foreach (var consola in visitor.listaSalida) {
            Console.WriteLine(consola);
        }
        Console.WriteLine("-----------------------------------------");
    }
}
