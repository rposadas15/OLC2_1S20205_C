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

inicio: listainstrucciones ;

listainstrucciones : instruccion (instruccion)* ;

instruccion: print 
| variables 
| asignacion 
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
;
