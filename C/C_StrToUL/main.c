#include <stdlib.h>
#include <stdio.h>


void toInt( char *str )
{
	char *end = NULL;
	unsigned long val;

	val = strtoul(str, &end, 10 );
	if( *end != '\0' )
		printf("Failed to convert\n");
	else
		printf("String value = %s, Int value = %lu\n", str, val );
}

int main( const int argc, const char *argv[] )
{
	char *str1 = "0046118101";
	char *str2 = "46118101";

	toInt( str1 );
	toInt( str2 );


}