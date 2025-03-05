grammar AnalizadorLexico;

options { caseInsensitive = false; }

NEWLINE : [ \r\n\t]+ -> channel(HIDDEN);
INT     : [0-9]+ ;
DECIMAL : [0-9]+('.'[0-9]+) ;
CARACTER : ('"'|'\'') [.]? ('"'|'\'') ;
CADENA: ('"'|'\'') (~["\r\n] | '""')* ('"'|'\'') ;
BOOL : ('true'|'false') ;
PALABRA: [a-zA-Z]+('_')?([0-9]+)? ;

IGUAL: '=' ;
DOSPUNTOS_IGUAL: ':=' ;
PARENTESIS_ABRE: '(' ;
PARENTESIS_CIERRA: ')' ;
COMA: ',' ;

inicio: listainstrucciones ;

listainstrucciones : instruccion (instruccion)* ;

instruccion: print 
| variables 
| asignacion 
| instruccion_if
| instruccion_funciones
| instruccion_ejecutar_funciones
;

print: 'fmt.Println' PARENTESIS_ABRE expr PARENTESIS_CIERRA ;

variables: 'var' PALABRA tipo (IGUAL expr)? #declaracionVar ;

asignacion: PALABRA signo=(IGUAL | DOSPUNTOS_IGUAL) expr #asignacionVar ;

tipo: 'int'
| 'float64'
| 'string'
| 'bool'
| 'rune'
;

instruccion_if: 'if' PARENTESIS_ABRE expr PARENTESIS_CIERRA 'then' listainstrucciones 'end if';

instruccion_funciones: 'func' PALABRA PARENTESIS_ABRE parametros_funciones? PARENTESIS_CIERRA retornarTipo=tipo? '{' listainstrucciones '}';

instruccion_ejecutar_funciones: PALABRA PARENTESIS_ABRE parametros_funciones PARENTESIS_CIERRA ';'?;

parametros_funciones: expr paraTipo=tipo (COMA expr paraTipo=tipo)*;

expr: '(' expr ')' #expreParentesis
| INT #intExpresion
| DECIMAL #decimalExpresion
| CARACTER #caracterExpresion
| BOOL #boleanExpresion
| CADENA #cadenaExpresion
| PALABRA #idExpresion

| expr ('*'|'/') expr #multiplicacionYdivision
| expr ('+'|'-') expr #sumaYresta

| left=expr operador='&&' right=expr #operadorLogico
| left=expr operador='||' right=expr #operadorLogico
| '!' right=expr #operadorNegacion

| left=expr operador='==' right=expr #operadorRelacional
| left=expr operador='!=' right=expr #operadorRelacional
| left=expr operador='>=' right=expr #operadorRelacional
| left=expr operador='>' right=expr #operadorRelacional
| left=expr operador='<=' right=expr #operadorRelacional
| left=expr operador='<' right=expr #operadorRelacional

| instruccion_ejecutar_funciones #ejecutarFunciones
;
