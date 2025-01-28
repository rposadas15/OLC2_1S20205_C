# Comandos para C#
## Crear proyecto
	dotnet new console -o <nombre del proyecto>

## Agregar dependencia de ANTLR al proyecto
	dotnet add package Antlr4.Runtime.Standard

## Ejeuctar proyecto
	dotnet run


# Comandos para herramienta de ANTLR
## Generar clases de ANTLR
	antlr4 -Dlanguage=CSharp <nombre del archivo>.g4 -visitor -listener
