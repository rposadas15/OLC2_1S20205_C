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
	/// Enter a parse tree produced by <see cref="AnalizadorLexicoParser.prog"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterProg([NotNull] AnalizadorLexicoParser.ProgContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AnalizadorLexicoParser.prog"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitProg([NotNull] AnalizadorLexicoParser.ProgContext context);
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
