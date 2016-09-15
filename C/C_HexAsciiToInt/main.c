#include <stdlib.h>
#include <stdio.h>

int main( const int argc, const char *argv[] )
{
	unsigned long result = 0;
	char *p = NULL;
	char *str[5] = {"99999999","11111111","abcdef12","ABCDEF12", "incorrect" };
	int ix;

	for( ix = 0; ix < 5; ++ix )
	{
		result = strtoul( str[ix], &p,16);
		if( *p != 0 )
			printf("String %s contain a character that isn't an hexadecimal numeric value\n", str[ix]);
		else
			printf("String %s converted to Integer value: %lu, Hex value:%#X\n", str[ix], result, result );
	}
}