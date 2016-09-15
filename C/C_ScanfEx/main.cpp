#include <stdio.h>
#include <string.h>

void tokenStrToFields( char *tokenStr, char token, char *fields[] );
void strToFields( char *string );

int main( int argc, char *argv[] )
{
	char string[100];
	double val1 = 0.0;
	double val2 = 0.0;

	strcpy( string, "3079610001;1421831;1390;;;5309113750;;1;TELEFONI - FAST;1014604T2AUG01N63145;0" );
	sscanf( string, "%lf;%*lf;%lf", &val1, &val2 );

	printf("%10.0f;%10.0f",val1, val2 );

	strToFields( string );
}

void strToFields( char *string )
{
	char fields[11][60];
	char *pfields[11];
	int ix;

	for( ix=0; ix<11; ++ix )
		pfields[ix] = &fields[ix][0];

	tokenStrToFields( string, ';', pfields );
}

void tokenStrToFields( char *tokenStr, char token, char *fields[] )
{   
	const char *ptr = tokenStr;   
	char format[20]; 
	int n;   
	int ix = 0;

	sprintf( format, "%%31[^%c]%%n", token );
	while ( ptr )
	{
		n = 0;
		if( sscanf(ptr, format, fields[ix], &n) == 0 )   
		{
			*fields[ix] = '\0'; //Empty field
		}
		ptr += n; /* advance the pointer by the number of characters read */      
		if ( *ptr != token )      
		{         
			break; /* didn't find an expected delimiter, done? */      
		}  

		++ix;
		++ptr; /* skip the delimiter */   
	}
}