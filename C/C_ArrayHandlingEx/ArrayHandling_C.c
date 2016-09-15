#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <malloc.h>

void printArray( char *arrayName, int ar[], int count )
{
	int ix;

	printf("\n%s: ",arrayName );
	for( ix = 0; ix < count; ++ix )
	{
		printf("%d, ", ar[ix] );
	}
}


void pointerArray()
{
	int a = 1,b=2,c=3,d=4;
	int *arr[5] = {&a,&b,&c,&d,NULL};
	int **pint;

	for( pint = arr; *pint; ++pint )
		(**pint)++;
}

void** AllocatePointerArray( int itemCount )
{
    void** pArray = (void**)calloc( itemCount, sizeof(void*) );
    return pArray;
}

void DeallocatePointerArray( void ** array )
{
    void **pItem;
    if( array )
    {
        pItem = array;
        while( *pItem != NULL )
        {
            free( *pItem );
            *pItem = NULL;
            pItem++;
        }

        free(array);
    }
}

void TestDynamicArray()
{
    long *plong;
    void **pArray = AllocatePointerArray( 10 );

    *(pArray+0) = (long*)malloc(sizeof(long));
    plong = (long*)*(pArray+0);
    *plong = 1; 

    *(pArray+1) = (long*)malloc(sizeof(long));
    *(long*)(*(pArray+1)) = 2; 

    DeallocatePointerArray( pArray );
/*
    free( *(pArray+1) );
    *(pArray+1) = NULL;

    free( *(pArray+0) );
    *(pArray+0) = NULL;
*/

}

int main( int argc, char *argv[] )
{
	int array1[10] = { 1,2,3,4,5 };
	int array2[10] = { 6,7,8,9,10 };

	printArray( "array1", array1, 5 );

	//array1 = array2; Not OK

	memcpy( array1,array2,5);
	printArray( "array1", array1, 5 );

	pointerArray();


    TestDynamicArray();

	return EXIT_SUCCESS;
}