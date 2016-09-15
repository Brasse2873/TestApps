#include <stdio.h>
#include <stdlib.h>
int main( const int argc, const char *argv[] )
{
	FILE *file;
	char line[255];
	long posStart;
	long posFirstLine;
	long posSecondLine;
	int res;

	if( (file = fopen( argv[1], argv[2] ) ) == NULL)
	{
		printf("failed to open file '%s' in mode '%s'\n", argv[1], argv[2] );
		return EXIT_FAILURE;	
	}

	posStart = ftell( file );
	printf( "stream pos after open. Pos=%d\n", posStart );

	fgets( line, 255, file );
	posFirstLine = ftell( file );
	printf( "stream pos after read of first line. Pos=%d\n\tLine=%s", posFirstLine,line );

	fgets( line, 255, file );
	posSecondLine = ftell( file );
	printf( "stream pos after read of second line. Pos=%d\n\tLine=%s", posSecondLine,line );

	if( (res =fseek( file, 0, SEEK_SET ))  != 0 )
	{
		printf("Failed to set pos to start of file. res:%d\n",res);
		return EXIT_FAILURE;
	}
	fgets( line, 255, file );
	printf( "This should be the first line:%s", line );


	if( (res =fseek( file, posFirstLine, SEEK_SET ))  != 0 )
	{
		printf("Failed to set pos to second line. res:%d\n",res);
		return EXIT_FAILURE;
	}
	fgets( line, 255, file );
	printf( "This should be the second line:%s", line );

	return EXIT_SUCCESS;
}