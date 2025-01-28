grammar AnalizadorLexico;

options { caseInsensitive = true; }

NEWLINE : [ \r\n\t]+ -> channel(HIDDEN);

INT     : [0-9]+ ;

prog: expr EOF ;

expr: expr ('*'|'/') expr #multiplicacionYdivision
    | expr ('+'|'-') expr #sumaYresta
    | int=INT #intExpresion
    | '(' expr ')' #expreParentesis
    ;
