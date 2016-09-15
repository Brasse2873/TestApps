#include <stdio.h>
#include <ctype.h>
#include <string.h>
#include <stdio.h>
#include <time.h>


char* ltrimFileName( char *str )  
{ 
    char *posFileName = str + strlen( str ); 

#ifdef _WIN
	while( (posFileName != str) && (*(posFileName-1)!='\\') ) {
            --posFileName; 
	}
#else
	while( (posFileName != str) && (*(posFileName-1)!=']') && (*(posFileName-1)!=':' ) ) {
            --posFileName; 
	}
#endif
    memmove( str, posFileName, strlen(posFileName) + 1 );
 
    return str; 
} 
 
char* rtrimFileName( char* str ) 
{ 
	char* end;

	strtok(str,";");
    end = str + strlen( str ); 
	while( (end != str) && isspace(*(end-1)) ) {
            --end; 
	}
	*end = '\0'; 
 
    return str; 
} 
 
char* trimFileName( char *str )
{
    return rtrimFileName( ltrimFileName(str) ); 
}

void getRunDate( char *date )
{
	time_t t;
	struct tm *ptm;

	time( &t );	
	ptm = localtime( &t );
	strftime( date, 255, "%d-%b-%Y", ptm );
}

void	printStatHeader( FILE *output, const char * inFile, const char *outFile )
{
	char name[255];
	char date[20];

	fprintf( output, "\n<Statistics:Header>" );

	name[0] = 0;
	if( inFile && strlen(inFile) )
	{
		strcpy( name, inFile );
		trimFileName( name );
	}
	fprintf( output, "%s~", name );

	name[0] = 0;
	if( outFile && strlen(outFile) )
	{
		strcpy( name, outFile );
		trimFileName( name );
	}
	fprintf( output, "%s~", name );

	getRunDate( date );
	fprintf( output, "%s~", date );

	fprintf( output, "\n");
}

void	printStatStartBlock( FILE *output )
{
	fprintf( output, "\n<Statistics:Start> \n");
}

void	printStatEndBlock( FILE *output )
{
	fprintf( output, "\n<Statistics:End>\n");
}