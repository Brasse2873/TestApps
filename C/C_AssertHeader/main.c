#include <assert.h>

int main( int argc, char *argv[] )
{
	assert( 1 ); //OK, 

	assert( 0 ); //Failure, Termimate program by calling abort()

	return 0; //This row is newer reached
}

