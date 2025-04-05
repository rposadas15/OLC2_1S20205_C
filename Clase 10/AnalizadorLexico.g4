grammar AnalizadorLexico;

options { caseInsensitive = false; }

NEWLINE: [ \r\n\t]+ -> channel(HIDDEN);
INT: [0-9]+ ;
CADENA: ('"'|'\'') (~["\r\n] | '""')* ('"'|'\'') ;
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

expr: expr ('*'|'/') expr #multiplicacionYdivision
| expr ('+'|'-') expr #sumaYresta
| INT #intExpresion
| CADENA #cadenaExpresion
| PALABRA #idExpresion
| '(' expr ')' #expreParentesis
;
