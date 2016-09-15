#include <stdio.h>

void func1();
void func2( int val );
int func3( int val );


int main( const int argc, const char *argv[] )
{
	int nVal;
	void (*pVoidFunc)();
	void (*pIntFunc)( int );
	int (*pIntIntFunc)(int);

	pVoidFunc = func1;
	pVoidFunc();


	pIntFunc = func2;
	pIntFunc( 1 );

	pIntIntFunc = func3;
	nVal = pIntIntFunc( 2 );
	printf("pIntIntFunc result = %d", nVal );
}



void func1()
{
	printf("func1\n");
}

void func2( int val )
{
	printf("func2: val=%d\n", val );
}

int func3( int val )
{
	printf("func3: val=%d\n", val );
	return val * val;
}