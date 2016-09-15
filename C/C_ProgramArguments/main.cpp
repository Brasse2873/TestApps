#include <string.h>

typedef struct _map
{
	char key[20];
	char value[100];
} Map, *PMap;

void getOptionalArguments( const int argc, const char *argv[], Map optArgs[] )
{
	int ix;
	int ixOptArgs = 0;
	const char *pos = NULL;

	for( ix=0; ix<argc; ++ix )
	{
		if( ( *argv[ix] == '/') || ( *argv[ix] == '-') )
		{
			if( pos = strchr( argv[ix],'=' ) ) 
			{
				strncpy( optArgs[ixOptArgs].key, argv[ix]+1, pos - argv[ix] - 1);
				strcpy( optArgs[ixOptArgs].value, pos+1 );
			}
			else
			{
				strcpy( optArgs[ixOptArgs].key, argv[ix]+1 );
			}			

			++ixOptArgs;
		}
	}
}

int main( const int argc, const char *argv[] )
{
	Map optArgs[10] = {0};

	getOptionalArguments( argc, argv, optArgs );
}