#include <stdlib.h>
#include <stdio.h>


void intVal()
{
	int ival1 = 0x01234567;
	int ival2 = 0x89abcdef;
	char str[9];

	sprintf( str,"%08X",ival1 );
	printf( "int val1:%s\n", str );
	sprintf( str,"%08X",ival2 );
	printf( "int val2: %s\n", str );

}

char* byte2AsciiHex( unsigned char byte, char *ascii )
{
	sprintf(ascii,"%02X", byte );
	return ascii;
}

void charVal()
{
	char cvals[31];
	char asciiVal[3] ={0};
	int ix;

	for( ix=0; ix<16;ix++ ) cvals[ix] = ix;
	for( ix=1; ix<16;ix++ ) cvals[15+ix] = ix<<4;

	printf("char values:" );
	for(ix=0; ix<31;ix++ ) printf( "%s ", byte2AsciiHex(cvals[ix], asciiVal) );
	printf("\n" );
}

int main( const int argc, const char* argv[] )
{
	intVal();
	charVal();
}