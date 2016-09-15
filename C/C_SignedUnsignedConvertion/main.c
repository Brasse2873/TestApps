#include <limits.h>
#include <stdio.h>


int main()
{
	int signedInt;
	unsigned unsignedInt;

	printf("signedInt MIN: %d\n", INT_MIN );
	printf("signedInt MAX: %d\n", INT_MAX );

	printf("unsignedInt MIN: %u\n", 0 );
	printf("unsignedInt MAX: %u\n", UINT_MAX );

}