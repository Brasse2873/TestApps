#include <stddef.h>
#include <stdlib.h>
#include <memory.h>
#include "dsa.h"



PDSA_ARRAYHEADER newArrayHeader()
{
    PDSA_ARRAYHEADER ah = calloc(1, sizeof(DSA_ARRAYHEADER));
    ah->arrRoot = calloc(ARRAY_BLOCK_SIZE, sizeof(char*));
    ah->size = ARRAY_BLOCK_SIZE;
    return ah;
}

/*
void increaseArray(PDSA_ARRAYHEADER *arr)
{
    unsigned long currSize = 0;
    unsigned long newSize = 0;

    currSize = (*arr)->size * sizeof(char*);
    newSize = ((*arr)->size + ARRAY_BLOCK_SIZE) * sizeof(char*)
        
    *arr = realloc(*arr, newSize );

    (*arr)->size = newSize / sizeof(char*);
}
*/

void increaseData(PDSA_DATAHEADER *data)
{
}


PDSA_HANDLE dsaNewArray()
{   
    PDSA_HANDLE hArr = calloc( 1, sizeof(DSA_HANDLE) );
    hArr->arrayRoot = newArrayHeader();
    increaseData(&hArr->dataRoot);

    return hArr;
}
