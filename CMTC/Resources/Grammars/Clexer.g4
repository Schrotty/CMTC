lexer grammar Clexer;

STRING
	: '"' .*? '"'
	;

BOOL
	: 'true' | 'false'
	;

ID  : LETTER (LETTER | DIGIT)*
	;
	
INT : DIGIT+
	;

fragment LETTER
	: [a-zA-Z]
	;
	
fragment DIGIT
	: [0-9]
	;
	
WS  : [ \t\n\r] -> skip
	;

COMMENT
	: '//' ~[\r\n]* -> skip
	;