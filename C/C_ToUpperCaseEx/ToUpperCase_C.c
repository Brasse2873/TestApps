#include <ctype.h> //toupper
#include <stdio.h> //printf
#include <stdlib.h> //EXIT_SUCCESS, EXIT_FAILUE

void makeUpperCase( char *szString )
{
	char *ptr = szString;

	for(;*ptr;ptr++)
	{
		*ptr=toupper(*ptr);
	}
}

int main( int argc, char *argv[] )
{
	if( argc < 2 )
	{
		printf("Type string to make uppercase as parameter" );
		return EXIT_FAILURE;
	}
	printf("In string: %s\n", argv[1] );

	makeUpperCase( argv[1] );

	printf("Upper case string: %s\n", argv[1] );

	return EXIT_SUCCESS;
}

