//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.13.2
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from AnalizadorLexico.g4 by ANTLR 4.13.2

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using Antlr4.Runtime.Misc;
using IParseTreeListener = Antlr4.Runtime.Tree.IParseTreeListener;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete listener for a parse tree produced by
/// <see cref="AnalizadorLexicoParser"/>.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.13.2")]
[System.CLSCompliant(false)]
public interface IAnalizadorLexicoListener : IParseTreeListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="AnalizadorLexicoParser.inicio"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterInicio([NotNull] AnalizadorLexicoParser.InicioContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AnalizadorLexicoParser.inicio"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitInicio([NotNull] AnalizadorLexicoParser.InicioContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="AnalizadorLexicoParser.listainstrucciones"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterListainstrucciones([NotNull] AnalizadorLexicoParser.ListainstruccionesContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AnalizadorLexicoParser.listainstrucciones"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitListainstrucciones([NotNull] AnalizadorLexicoParser.ListainstruccionesContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="AnalizadorLexicoParser.instruccion"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterInstruccion([NotNull] AnalizadorLexicoParser.InstruccionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AnalizadorLexicoParser.instruccion"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitInstruccion([NotNull] AnalizadorLexicoParser.InstruccionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="AnalizadorLexicoParser.print"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPrint([NotNull] AnalizadorLexicoParser.PrintContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AnalizadorLexicoParser.print"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPrint([NotNull] AnalizadorLexicoParser.PrintContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>declaracionVar</c>
	/// labeled alternative in <see cref="AnalizadorLexicoParser.variables"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterDeclaracionVar([NotNull] AnalizadorLexicoParser.DeclaracionVarContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>declaracionVar</c>
	/// labeled alternative in <see cref="AnalizadorLexicoParser.variables"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitDeclaracionVar([NotNull] AnalizadorLexicoParser.DeclaracionVarContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>asignacionVar</c>
	/// labeled alternative in <see cref="AnalizadorLexicoParser.asignacion"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAsignacionVar([NotNull] AnalizadorLexicoParser.AsignacionVarContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>asignacionVar</c>
	/// labeled alternative in <see cref="AnalizadorLexicoParser.asignacion"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAsignacionVar([NotNull] AnalizadorLexicoParser.AsignacionVarContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="AnalizadorLexicoParser.tipo"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterTipo([NotNull] AnalizadorLexicoParser.TipoContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AnalizadorLexicoParser.tipo"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitTipo([NotNull] AnalizadorLexicoParser.TipoContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="AnalizadorLexicoParser.instruccion_if"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterInstruccion_if([NotNull] AnalizadorLexicoParser.Instruccion_ifContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AnalizadorLexicoParser.instruccion_if"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitInstruccion_if([NotNull] AnalizadorLexicoParser.Instruccion_ifContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="AnalizadorLexicoParser.instruccion_funciones"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterInstruccion_funciones([NotNull] AnalizadorLexicoParser.Instruccion_funcionesContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AnalizadorLexicoParser.instruccion_funciones"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitInstruccion_funciones([NotNull] AnalizadorLexicoParser.Instruccion_funcionesContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="AnalizadorLexicoParser.instruccion_ejecutar_funciones"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterInstruccion_ejecutar_funciones([NotNull] AnalizadorLexicoParser.Instruccion_ejecutar_funcionesContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AnalizadorLexicoParser.instruccion_ejecutar_funciones"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitInstruccion_ejecutar_funciones([NotNull] AnalizadorLexicoParser.Instruccion_ejecutar_funcionesContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="AnalizadorLexicoParser.parametros_funciones"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterParametros_funciones([NotNull] AnalizadorLexicoParser.Parametros_funcionesContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AnalizadorLexicoParser.parametros_funciones"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitParametros_funciones([NotNull] AnalizadorLexicoParser.Parametros_funcionesContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>operadorLogico</c>
	/// labeled alternative in <see cref="AnalizadorLexicoParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterOperadorLogico([NotNull] AnalizadorLexicoParser.OperadorLogicoContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>operadorLogico</c>
	/// labeled alternative in <see cref="AnalizadorLexicoParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitOperadorLogico([NotNull] AnalizadorLexicoParser.OperadorLogicoContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>expreParentesis</c>
	/// labeled alternative in <see cref="AnalizadorLexicoParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterExpreParentesis([NotNull] AnalizadorLexicoParser.ExpreParentesisContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>expreParentesis</c>
	/// labeled alternative in <see cref="AnalizadorLexicoParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitExpreParentesis([NotNull] AnalizadorLexicoParser.ExpreParentesisContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>idExpresion</c>
	/// labeled alternative in <see cref="AnalizadorLexicoParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIdExpresion([NotNull] AnalizadorLexicoParser.IdExpresionContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>idExpresion</c>
	/// labeled alternative in <see cref="AnalizadorLexicoParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIdExpresion([NotNull] AnalizadorLexicoParser.IdExpresionContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>ejecutarFunciones</c>
	/// labeled alternative in <see cref="AnalizadorLexicoParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterEjecutarFunciones([NotNull] AnalizadorLexicoParser.EjecutarFuncionesContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>ejecutarFunciones</c>
	/// labeled alternative in <see cref="AnalizadorLexicoParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitEjecutarFunciones([NotNull] AnalizadorLexicoParser.EjecutarFuncionesContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>operadorNegacion</c>
	/// labeled alternative in <see cref="AnalizadorLexicoParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterOperadorNegacion([NotNull] AnalizadorLexicoParser.OperadorNegacionContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>operadorNegacion</c>
	/// labeled alternative in <see cref="AnalizadorLexicoParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitOperadorNegacion([NotNull] AnalizadorLexicoParser.OperadorNegacionContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>caracterExpresion</c>
	/// labeled alternative in <see cref="AnalizadorLexicoParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterCaracterExpresion([NotNull] AnalizadorLexicoParser.CaracterExpresionContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>caracterExpresion</c>
	/// labeled alternative in <see cref="AnalizadorLexicoParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitCaracterExpresion([NotNull] AnalizadorLexicoParser.CaracterExpresionContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>decimalExpresion</c>
	/// labeled alternative in <see cref="AnalizadorLexicoParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterDecimalExpresion([NotNull] AnalizadorLexicoParser.DecimalExpresionContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>decimalExpresion</c>
	/// labeled alternative in <see cref="AnalizadorLexicoParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitDecimalExpresion([NotNull] AnalizadorLexicoParser.DecimalExpresionContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>boleanExpresion</c>
	/// labeled alternative in <see cref="AnalizadorLexicoParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBoleanExpresion([NotNull] AnalizadorLexicoParser.BoleanExpresionContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>boleanExpresion</c>
	/// labeled alternative in <see cref="AnalizadorLexicoParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBoleanExpresion([NotNull] AnalizadorLexicoParser.BoleanExpresionContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>cadenaExpresion</c>
	/// labeled alternative in <see cref="AnalizadorLexicoParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterCadenaExpresion([NotNull] AnalizadorLexicoParser.CadenaExpresionContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>cadenaExpresion</c>
	/// labeled alternative in <see cref="AnalizadorLexicoParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitCadenaExpresion([NotNull] AnalizadorLexicoParser.CadenaExpresionContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>multiplicacionYdivision</c>
	/// labeled alternative in <see cref="AnalizadorLexicoParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterMultiplicacionYdivision([NotNull] AnalizadorLexicoParser.MultiplicacionYdivisionContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>multiplicacionYdivision</c>
	/// labeled alternative in <see cref="AnalizadorLexicoParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitMultiplicacionYdivision([NotNull] AnalizadorLexicoParser.MultiplicacionYdivisionContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>intExpresion</c>
	/// labeled alternative in <see cref="AnalizadorLexicoParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIntExpresion([NotNull] AnalizadorLexicoParser.IntExpresionContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>intExpresion</c>
	/// labeled alternative in <see cref="AnalizadorLexicoParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIntExpresion([NotNull] AnalizadorLexicoParser.IntExpresionContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>operadorRelacional</c>
	/// labeled alternative in <see cref="AnalizadorLexicoParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterOperadorRelacional([NotNull] AnalizadorLexicoParser.OperadorRelacionalContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>operadorRelacional</c>
	/// labeled alternative in <see cref="AnalizadorLexicoParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitOperadorRelacional([NotNull] AnalizadorLexicoParser.OperadorRelacionalContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>sumaYresta</c>
	/// labeled alternative in <see cref="AnalizadorLexicoParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSumaYresta([NotNull] AnalizadorLexicoParser.SumaYrestaContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>sumaYresta</c>
	/// labeled alternative in <see cref="AnalizadorLexicoParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSumaYresta([NotNull] AnalizadorLexicoParser.SumaYrestaContext context);
}
