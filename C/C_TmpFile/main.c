#include <stdio.h>

int main( const int argc, const char *argv[] )
{
	FILE *file;
	char filename[100];

	tmpnam( filename );
	if( (file = tmpfile()) != NULL )
	{
		fprintf( file, "Line 1\n" );
		fprintf( file, "Line 2\n" );
	}
}