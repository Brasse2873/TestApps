#include <stdio.h>
#include <ctype.h>
#include <string.h>


char* ltrim( char *str )  
{ 
    char* posFirstNonSpace = str; 
 
    while( isspace( *posFirstNonSpace) ) {
        ++posFirstNonSpace; 
	}
    memmove( str, posFirstNonSpace, strlen(posFirstNonSpace) + 1 );
 
    return str; 
} 
 
 
char* rtrim( char* str ) 
{ 
    char* end = str + strlen( str ); 
 
	while( (end != str) && isspace(*(end-1)) ) {
            --end; 
	}
	*end = '\0'; 
 
    return str; 
} 
 
char*  trim( char* str ) 
{ 
    return rtrim( ltrim(str) ); 
} 


int main( const int argc, const char *argv[] )
{
	char line[100];

	strcpy(line, "   Start      Slut    " );
	trim(line);
}


