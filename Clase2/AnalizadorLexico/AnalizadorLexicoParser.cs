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

using System;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.13.2")]
[System.CLSCompliant(false)]
public partial class AnalizadorLexicoParser : Parser {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		T__0=1, T__1=2, T__2=3, T__3=4, T__4=5, T__5=6, T__6=7, T__7=8, T__8=9, 
		T__9=10, T__10=11, NEWLINE=12, INT=13, CADENA=14, PALABRA=15, IGUAL=16, 
		DOSPUNTOS_IGUAL=17, PARENTESIS_ABRE=18, PARENTESIS_CIERRA=19;
	public const int
		RULE_inicio = 0, RULE_listainstrucciones = 1, RULE_instruccion = 2, RULE_print = 3, 
		RULE_variables = 4, RULE_asignacion = 5, RULE_tipo = 6, RULE_expr = 7;
	public static readonly string[] ruleNames = {
		"inicio", "listainstrucciones", "instruccion", "print", "variables", "asignacion", 
		"tipo", "expr"
	};

	private static readonly string[] _LiteralNames = {
		null, "'fmt.Println'", "'var'", "'int'", "'float64'", "'string'", "'bool'", 
		"'rune'", "'*'", "'/'", "'+'", "'-'", null, null, null, null, "'='", "':='", 
		"'('", "')'"
	};
	private static readonly string[] _SymbolicNames = {
		null, null, null, null, null, null, null, null, null, null, null, null, 
		"NEWLINE", "INT", "CADENA", "PALABRA", "IGUAL", "DOSPUNTOS_IGUAL", "PARENTESIS_ABRE", 
		"PARENTESIS_CIERRA"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "AnalizadorLexico.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override int[] SerializedAtn { get { return _serializedATN; } }

	static AnalizadorLexicoParser() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}

		public AnalizadorLexicoParser(ITokenStream input) : this(input, Console.Out, Console.Error) { }

		public AnalizadorLexicoParser(ITokenStream input, TextWriter output, TextWriter errorOutput)
		: base(input, output, errorOutput)
	{
		Interpreter = new ParserATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	public partial class InicioContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ListainstruccionesContext listainstrucciones() {
			return GetRuleContext<ListainstruccionesContext>(0);
		}
		public InicioContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_inicio; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			IAnalizadorLexicoListener typedListener = listener as IAnalizadorLexicoListener;
			if (typedListener != null) typedListener.EnterInicio(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			IAnalizadorLexicoListener typedListener = listener as IAnalizadorLexicoListener;
			if (typedListener != null) typedListener.ExitInicio(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IAnalizadorLexicoVisitor<TResult> typedVisitor = visitor as IAnalizadorLexicoVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitInicio(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public InicioContext inicio() {
		InicioContext _localctx = new InicioContext(Context, State);
		EnterRule(_localctx, 0, RULE_inicio);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 16;
			listainstrucciones();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class ListainstruccionesContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public InstruccionContext[] instruccion() {
			return GetRuleContexts<InstruccionContext>();
		}
		[System.Diagnostics.DebuggerNonUserCode] public InstruccionContext instruccion(int i) {
			return GetRuleContext<InstruccionContext>(i);
		}
		public ListainstruccionesContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_listainstrucciones; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			IAnalizadorLexicoListener typedListener = listener as IAnalizadorLexicoListener;
			if (typedListener != null) typedListener.EnterListainstrucciones(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			IAnalizadorLexicoListener typedListener = listener as IAnalizadorLexicoListener;
			if (typedListener != null) typedListener.ExitListainstrucciones(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IAnalizadorLexicoVisitor<TResult> typedVisitor = visitor as IAnalizadorLexicoVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitListainstrucciones(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public ListainstruccionesContext listainstrucciones() {
		ListainstruccionesContext _localctx = new ListainstruccionesContext(Context, State);
		EnterRule(_localctx, 2, RULE_listainstrucciones);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 18;
			instruccion();
			State = 22;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			while ((((_la) & ~0x3f) == 0 && ((1L << _la) & 32774L) != 0)) {
				{
				{
				State = 19;
				instruccion();
				}
				}
				State = 24;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class InstruccionContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public PrintContext print() {
			return GetRuleContext<PrintContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public VariablesContext variables() {
			return GetRuleContext<VariablesContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public AsignacionContext asignacion() {
			return GetRuleContext<AsignacionContext>(0);
		}
		public InstruccionContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_instruccion; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			IAnalizadorLexicoListener typedListener = listener as IAnalizadorLexicoListener;
			if (typedListener != null) typedListener.EnterInstruccion(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			IAnalizadorLexicoListener typedListener = listener as IAnalizadorLexicoListener;
			if (typedListener != null) typedListener.ExitInstruccion(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IAnalizadorLexicoVisitor<TResult> typedVisitor = visitor as IAnalizadorLexicoVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitInstruccion(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public InstruccionContext instruccion() {
		InstruccionContext _localctx = new InstruccionContext(Context, State);
		EnterRule(_localctx, 4, RULE_instruccion);
		try {
			State = 28;
			ErrorHandler.Sync(this);
			switch (TokenStream.LA(1)) {
			case T__0:
				EnterOuterAlt(_localctx, 1);
				{
				State = 25;
				print();
				}
				break;
			case T__1:
				EnterOuterAlt(_localctx, 2);
				{
				State = 26;
				variables();
				}
				break;
			case PALABRA:
				EnterOuterAlt(_localctx, 3);
				{
				State = 27;
				asignacion();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class PrintContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode PARENTESIS_ABRE() { return GetToken(AnalizadorLexicoParser.PARENTESIS_ABRE, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ExprContext expr() {
			return GetRuleContext<ExprContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode PARENTESIS_CIERRA() { return GetToken(AnalizadorLexicoParser.PARENTESIS_CIERRA, 0); }
		public PrintContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_print; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			IAnalizadorLexicoListener typedListener = listener as IAnalizadorLexicoListener;
			if (typedListener != null) typedListener.EnterPrint(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			IAnalizadorLexicoListener typedListener = listener as IAnalizadorLexicoListener;
			if (typedListener != null) typedListener.ExitPrint(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IAnalizadorLexicoVisitor<TResult> typedVisitor = visitor as IAnalizadorLexicoVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitPrint(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public PrintContext print() {
		PrintContext _localctx = new PrintContext(Context, State);
		EnterRule(_localctx, 6, RULE_print);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 30;
			Match(T__0);
			State = 31;
			Match(PARENTESIS_ABRE);
			State = 32;
			expr(0);
			State = 33;
			Match(PARENTESIS_CIERRA);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class VariablesContext : ParserRuleContext {
		public VariablesContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_variables; } }
	 
		public VariablesContext() { }
		public virtual void CopyFrom(VariablesContext context) {
			base.CopyFrom(context);
		}
	}
	public partial class DeclaracionVarContext : VariablesContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode PALABRA() { return GetToken(AnalizadorLexicoParser.PALABRA, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public TipoContext tipo() {
			return GetRuleContext<TipoContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode IGUAL() { return GetToken(AnalizadorLexicoParser.IGUAL, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ExprContext expr() {
			return GetRuleContext<ExprContext>(0);
		}
		public DeclaracionVarContext(VariablesContext context) { CopyFrom(context); }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			IAnalizadorLexicoListener typedListener = listener as IAnalizadorLexicoListener;
			if (typedListener != null) typedListener.EnterDeclaracionVar(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			IAnalizadorLexicoListener typedListener = listener as IAnalizadorLexicoListener;
			if (typedListener != null) typedListener.ExitDeclaracionVar(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IAnalizadorLexicoVisitor<TResult> typedVisitor = visitor as IAnalizadorLexicoVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitDeclaracionVar(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public VariablesContext variables() {
		VariablesContext _localctx = new VariablesContext(Context, State);
		EnterRule(_localctx, 8, RULE_variables);
		int _la;
		try {
			_localctx = new DeclaracionVarContext(_localctx);
			EnterOuterAlt(_localctx, 1);
			{
			State = 35;
			Match(T__1);
			State = 36;
			Match(PALABRA);
			State = 37;
			tipo();
			State = 40;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			if (_la==IGUAL) {
				{
				State = 38;
				Match(IGUAL);
				State = 39;
				expr(0);
				}
			}

			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class AsignacionContext : ParserRuleContext {
		public AsignacionContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_asignacion; } }
	 
		public AsignacionContext() { }
		public virtual void CopyFrom(AsignacionContext context) {
			base.CopyFrom(context);
		}
	}
	public partial class AsignacionVarContext : AsignacionContext {
		public IToken signo;
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode PALABRA() { return GetToken(AnalizadorLexicoParser.PALABRA, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ExprContext expr() {
			return GetRuleContext<ExprContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode IGUAL() { return GetToken(AnalizadorLexicoParser.IGUAL, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode DOSPUNTOS_IGUAL() { return GetToken(AnalizadorLexicoParser.DOSPUNTOS_IGUAL, 0); }
		public AsignacionVarContext(AsignacionContext context) { CopyFrom(context); }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			IAnalizadorLexicoListener typedListener = listener as IAnalizadorLexicoListener;
			if (typedListener != null) typedListener.EnterAsignacionVar(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			IAnalizadorLexicoListener typedListener = listener as IAnalizadorLexicoListener;
			if (typedListener != null) typedListener.ExitAsignacionVar(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IAnalizadorLexicoVisitor<TResult> typedVisitor = visitor as IAnalizadorLexicoVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitAsignacionVar(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public AsignacionContext asignacion() {
		AsignacionContext _localctx = new AsignacionContext(Context, State);
		EnterRule(_localctx, 10, RULE_asignacion);
		int _la;
		try {
			_localctx = new AsignacionVarContext(_localctx);
			EnterOuterAlt(_localctx, 1);
			{
			State = 42;
			Match(PALABRA);
			State = 43;
			((AsignacionVarContext)_localctx).signo = TokenStream.LT(1);
			_la = TokenStream.LA(1);
			if ( !(_la==IGUAL || _la==DOSPUNTOS_IGUAL) ) {
				((AsignacionVarContext)_localctx).signo = ErrorHandler.RecoverInline(this);
			}
			else {
				ErrorHandler.ReportMatch(this);
			    Consume();
			}
			State = 44;
			expr(0);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class TipoContext : ParserRuleContext {
		public TipoContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_tipo; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			IAnalizadorLexicoListener typedListener = listener as IAnalizadorLexicoListener;
			if (typedListener != null) typedListener.EnterTipo(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			IAnalizadorLexicoListener typedListener = listener as IAnalizadorLexicoListener;
			if (typedListener != null) typedListener.ExitTipo(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IAnalizadorLexicoVisitor<TResult> typedVisitor = visitor as IAnalizadorLexicoVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitTipo(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public TipoContext tipo() {
		TipoContext _localctx = new TipoContext(Context, State);
		EnterRule(_localctx, 12, RULE_tipo);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 46;
			_la = TokenStream.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & 248L) != 0)) ) {
			ErrorHandler.RecoverInline(this);
			}
			else {
				ErrorHandler.ReportMatch(this);
			    Consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class ExprContext : ParserRuleContext {
		public ExprContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_expr; } }
	 
		public ExprContext() { }
		public virtual void CopyFrom(ExprContext context) {
			base.CopyFrom(context);
		}
	}
	public partial class CadenaExpresionContext : ExprContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode CADENA() { return GetToken(AnalizadorLexicoParser.CADENA, 0); }
		public CadenaExpresionContext(ExprContext context) { CopyFrom(context); }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			IAnalizadorLexicoListener typedListener = listener as IAnalizadorLexicoListener;
			if (typedListener != null) typedListener.EnterCadenaExpresion(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			IAnalizadorLexicoListener typedListener = listener as IAnalizadorLexicoListener;
			if (typedListener != null) typedListener.ExitCadenaExpresion(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IAnalizadorLexicoVisitor<TResult> typedVisitor = visitor as IAnalizadorLexicoVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitCadenaExpresion(this);
			else return visitor.VisitChildren(this);
		}
	}
	public partial class ExpreParentesisContext : ExprContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode PARENTESIS_ABRE() { return GetToken(AnalizadorLexicoParser.PARENTESIS_ABRE, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ExprContext expr() {
			return GetRuleContext<ExprContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode PARENTESIS_CIERRA() { return GetToken(AnalizadorLexicoParser.PARENTESIS_CIERRA, 0); }
		public ExpreParentesisContext(ExprContext context) { CopyFrom(context); }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			IAnalizadorLexicoListener typedListener = listener as IAnalizadorLexicoListener;
			if (typedListener != null) typedListener.EnterExpreParentesis(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			IAnalizadorLexicoListener typedListener = listener as IAnalizadorLexicoListener;
			if (typedListener != null) typedListener.ExitExpreParentesis(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IAnalizadorLexicoVisitor<TResult> typedVisitor = visitor as IAnalizadorLexicoVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitExpreParentesis(this);
			else return visitor.VisitChildren(this);
		}
	}
	public partial class MultiplicacionYdivisionContext : ExprContext {
		[System.Diagnostics.DebuggerNonUserCode] public ExprContext[] expr() {
			return GetRuleContexts<ExprContext>();
		}
		[System.Diagnostics.DebuggerNonUserCode] public ExprContext expr(int i) {
			return GetRuleContext<ExprContext>(i);
		}
		public MultiplicacionYdivisionContext(ExprContext context) { CopyFrom(context); }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			IAnalizadorLexicoListener typedListener = listener as IAnalizadorLexicoListener;
			if (typedListener != null) typedListener.EnterMultiplicacionYdivision(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			IAnalizadorLexicoListener typedListener = listener as IAnalizadorLexicoListener;
			if (typedListener != null) typedListener.ExitMultiplicacionYdivision(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IAnalizadorLexicoVisitor<TResult> typedVisitor = visitor as IAnalizadorLexicoVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitMultiplicacionYdivision(this);
			else return visitor.VisitChildren(this);
		}
	}
	public partial class IntExpresionContext : ExprContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode INT() { return GetToken(AnalizadorLexicoParser.INT, 0); }
		public IntExpresionContext(ExprContext context) { CopyFrom(context); }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			IAnalizadorLexicoListener typedListener = listener as IAnalizadorLexicoListener;
			if (typedListener != null) typedListener.EnterIntExpresion(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			IAnalizadorLexicoListener typedListener = listener as IAnalizadorLexicoListener;
			if (typedListener != null) typedListener.ExitIntExpresion(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IAnalizadorLexicoVisitor<TResult> typedVisitor = visitor as IAnalizadorLexicoVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitIntExpresion(this);
			else return visitor.VisitChildren(this);
		}
	}
	public partial class IdExpresionContext : ExprContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode PALABRA() { return GetToken(AnalizadorLexicoParser.PALABRA, 0); }
		public IdExpresionContext(ExprContext context) { CopyFrom(context); }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			IAnalizadorLexicoListener typedListener = listener as IAnalizadorLexicoListener;
			if (typedListener != null) typedListener.EnterIdExpresion(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			IAnalizadorLexicoListener typedListener = listener as IAnalizadorLexicoListener;
			if (typedListener != null) typedListener.ExitIdExpresion(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IAnalizadorLexicoVisitor<TResult> typedVisitor = visitor as IAnalizadorLexicoVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitIdExpresion(this);
			else return visitor.VisitChildren(this);
		}
	}
	public partial class SumaYrestaContext : ExprContext {
		[System.Diagnostics.DebuggerNonUserCode] public ExprContext[] expr() {
			return GetRuleContexts<ExprContext>();
		}
		[System.Diagnostics.DebuggerNonUserCode] public ExprContext expr(int i) {
			return GetRuleContext<ExprContext>(i);
		}
		public SumaYrestaContext(ExprContext context) { CopyFrom(context); }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			IAnalizadorLexicoListener typedListener = listener as IAnalizadorLexicoListener;
			if (typedListener != null) typedListener.EnterSumaYresta(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			IAnalizadorLexicoListener typedListener = listener as IAnalizadorLexicoListener;
			if (typedListener != null) typedListener.ExitSumaYresta(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IAnalizadorLexicoVisitor<TResult> typedVisitor = visitor as IAnalizadorLexicoVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitSumaYresta(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public ExprContext expr() {
		return expr(0);
	}

	private ExprContext expr(int _p) {
		ParserRuleContext _parentctx = Context;
		int _parentState = State;
		ExprContext _localctx = new ExprContext(Context, _parentState);
		ExprContext _prevctx = _localctx;
		int _startState = 14;
		EnterRecursionRule(_localctx, 14, RULE_expr, _p);
		int _la;
		try {
			int _alt;
			EnterOuterAlt(_localctx, 1);
			{
			State = 56;
			ErrorHandler.Sync(this);
			switch (TokenStream.LA(1)) {
			case INT:
				{
				_localctx = new IntExpresionContext(_localctx);
				Context = _localctx;
				_prevctx = _localctx;

				State = 49;
				Match(INT);
				}
				break;
			case CADENA:
				{
				_localctx = new CadenaExpresionContext(_localctx);
				Context = _localctx;
				_prevctx = _localctx;
				State = 50;
				Match(CADENA);
				}
				break;
			case PALABRA:
				{
				_localctx = new IdExpresionContext(_localctx);
				Context = _localctx;
				_prevctx = _localctx;
				State = 51;
				Match(PALABRA);
				}
				break;
			case PARENTESIS_ABRE:
				{
				_localctx = new ExpreParentesisContext(_localctx);
				Context = _localctx;
				_prevctx = _localctx;
				State = 52;
				Match(PARENTESIS_ABRE);
				State = 53;
				expr(0);
				State = 54;
				Match(PARENTESIS_CIERRA);
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			Context.Stop = TokenStream.LT(-1);
			State = 66;
			ErrorHandler.Sync(this);
			_alt = Interpreter.AdaptivePredict(TokenStream,5,Context);
			while ( _alt!=2 && _alt!=global::Antlr4.Runtime.Atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					if ( ParseListeners!=null )
						TriggerExitRuleEvent();
					_prevctx = _localctx;
					{
					State = 64;
					ErrorHandler.Sync(this);
					switch ( Interpreter.AdaptivePredict(TokenStream,4,Context) ) {
					case 1:
						{
						_localctx = new MultiplicacionYdivisionContext(new ExprContext(_parentctx, _parentState));
						PushNewRecursionContext(_localctx, _startState, RULE_expr);
						State = 58;
						if (!(Precpred(Context, 6))) throw new FailedPredicateException(this, "Precpred(Context, 6)");
						State = 59;
						_la = TokenStream.LA(1);
						if ( !(_la==T__7 || _la==T__8) ) {
						ErrorHandler.RecoverInline(this);
						}
						else {
							ErrorHandler.ReportMatch(this);
						    Consume();
						}
						State = 60;
						expr(7);
						}
						break;
					case 2:
						{
						_localctx = new SumaYrestaContext(new ExprContext(_parentctx, _parentState));
						PushNewRecursionContext(_localctx, _startState, RULE_expr);
						State = 61;
						if (!(Precpred(Context, 5))) throw new FailedPredicateException(this, "Precpred(Context, 5)");
						State = 62;
						_la = TokenStream.LA(1);
						if ( !(_la==T__9 || _la==T__10) ) {
						ErrorHandler.RecoverInline(this);
						}
						else {
							ErrorHandler.ReportMatch(this);
						    Consume();
						}
						State = 63;
						expr(6);
						}
						break;
					}
					} 
				}
				State = 68;
				ErrorHandler.Sync(this);
				_alt = Interpreter.AdaptivePredict(TokenStream,5,Context);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			UnrollRecursionContexts(_parentctx);
		}
		return _localctx;
	}

	public override bool Sempred(RuleContext _localctx, int ruleIndex, int predIndex) {
		switch (ruleIndex) {
		case 7: return expr_sempred((ExprContext)_localctx, predIndex);
		}
		return true;
	}
	private bool expr_sempred(ExprContext _localctx, int predIndex) {
		switch (predIndex) {
		case 0: return Precpred(Context, 6);
		case 1: return Precpred(Context, 5);
		}
		return true;
	}

	private static int[] _serializedATN = {
		4,1,19,70,2,0,7,0,2,1,7,1,2,2,7,2,2,3,7,3,2,4,7,4,2,5,7,5,2,6,7,6,2,7,
		7,7,1,0,1,0,1,1,1,1,5,1,21,8,1,10,1,12,1,24,9,1,1,2,1,2,1,2,3,2,29,8,2,
		1,3,1,3,1,3,1,3,1,3,1,4,1,4,1,4,1,4,1,4,3,4,41,8,4,1,5,1,5,1,5,1,5,1,6,
		1,6,1,7,1,7,1,7,1,7,1,7,1,7,1,7,1,7,3,7,57,8,7,1,7,1,7,1,7,1,7,1,7,1,7,
		5,7,65,8,7,10,7,12,7,68,9,7,1,7,0,1,14,8,0,2,4,6,8,10,12,14,0,4,1,0,16,
		17,1,0,3,7,1,0,8,9,1,0,10,11,70,0,16,1,0,0,0,2,18,1,0,0,0,4,28,1,0,0,0,
		6,30,1,0,0,0,8,35,1,0,0,0,10,42,1,0,0,0,12,46,1,0,0,0,14,56,1,0,0,0,16,
		17,3,2,1,0,17,1,1,0,0,0,18,22,3,4,2,0,19,21,3,4,2,0,20,19,1,0,0,0,21,24,
		1,0,0,0,22,20,1,0,0,0,22,23,1,0,0,0,23,3,1,0,0,0,24,22,1,0,0,0,25,29,3,
		6,3,0,26,29,3,8,4,0,27,29,3,10,5,0,28,25,1,0,0,0,28,26,1,0,0,0,28,27,1,
		0,0,0,29,5,1,0,0,0,30,31,5,1,0,0,31,32,5,18,0,0,32,33,3,14,7,0,33,34,5,
		19,0,0,34,7,1,0,0,0,35,36,5,2,0,0,36,37,5,15,0,0,37,40,3,12,6,0,38,39,
		5,16,0,0,39,41,3,14,7,0,40,38,1,0,0,0,40,41,1,0,0,0,41,9,1,0,0,0,42,43,
		5,15,0,0,43,44,7,0,0,0,44,45,3,14,7,0,45,11,1,0,0,0,46,47,7,1,0,0,47,13,
		1,0,0,0,48,49,6,7,-1,0,49,57,5,13,0,0,50,57,5,14,0,0,51,57,5,15,0,0,52,
		53,5,18,0,0,53,54,3,14,7,0,54,55,5,19,0,0,55,57,1,0,0,0,56,48,1,0,0,0,
		56,50,1,0,0,0,56,51,1,0,0,0,56,52,1,0,0,0,57,66,1,0,0,0,58,59,10,6,0,0,
		59,60,7,2,0,0,60,65,3,14,7,7,61,62,10,5,0,0,62,63,7,3,0,0,63,65,3,14,7,
		6,64,58,1,0,0,0,64,61,1,0,0,0,65,68,1,0,0,0,66,64,1,0,0,0,66,67,1,0,0,
		0,67,15,1,0,0,0,68,66,1,0,0,0,6,22,28,40,56,64,66
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
