grammar Cymbol;
import Clexer;

file:   (functionDecl | varDecl)+
	; 

functionDecl
	:   type ID '(' formalParameters? ')' block
	;

formalParameters
	:   formalParameter (',' formalParameter)*
	;

formalParameter 
	:   type ID
	;

stat:   block  
	|   varDecl	           
	|   ifStat	
	|   forStat				  
	|   returnStat ';'    
	|   assignStat  ';'  
	|   printStat  ';'   
	|   expr ';'     
	;
	 
block
	:  '{' stat* '}'
	;   

assignStat
	:  ID '=' expr
	;

ifStat
	: 'if' '(' expr ')' stat ('else' stat)?
	;

forStat
	: 'for' '(' assignStat ';' expr ';' assignStat ')' block
	;

returnStat
	: 'return' expr
	;

args: expr (',' expr)*
	;  

printStat
	: 'printf' '(' expr ')'
	;

varDecl
	:   type ';'
	;

type: 'int'
	| 'void'
	; 

expr:   '-' expr					
	|   '!' expr						
	|   expr ('*'|'/') expr				
	|   expr ('+'|'-') expr				
	|   expr ('=='|'!='|'<'|'>') expr	
	|   expr '?' expr ':' expr			
	|   ID								
	|   INT								
	|   '(' expr ')'					
	|   ID '(' args? ')'				
	;