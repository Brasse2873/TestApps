#include <string.h>

int main( int argc, char *argv[] )
{
	char string[255];
	char *toPos;
	char *data[11];
	int ix;

	memset( string, 0, 255 );
	memset( data, 0 , 11 );

	strcpy( string, "\"3079610001;1421831;1390;;;5309113750;;1;TELEFONI - FAST;1014604T2AUG01N63145;0\"" ); //11 fields
	//strcpy( string, "\";1421831;1390;;;5309113750;;1;TELEFONI - FAST;1014604T2AUG01N63145;0\"" ); //11 fields

	toPos = string;

	for( ix = 0; ix<11; ++ix )
	{
		data[ix] = toPos + 1;
		toPos = data[ix] + strcspn( data[ix], ";\"" );
		*toPos  = '\0';
	}
}