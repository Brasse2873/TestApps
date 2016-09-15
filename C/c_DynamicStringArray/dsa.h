#ifndef DSA_H
#define DSA_H

#define ARRAY_BLOCK_SIZE    3
#define DATA_BLOCK_SIZE     30


typedef struct _DsaDataHeader
{
    long size;
    long used;
    struct _DsaDataHeader* nextDataBlock;
    char *data;
}DSA_DATAHEADER, *PDSA_DATAHEADER;

typedef struct _DsaArrayHeader
{
    long size;    
    char **arrRoot;
}DSA_ARRAYHEADER, *PDSA_ARRAYHEADER;

typedef struct _DsaHandle
{
    PDSA_ARRAYHEADER arrayRoot;
    PDSA_DATAHEADER dataRoot;
}DSA_HANDLE, *PDSA_HANDLE;


PDSA_HANDLE dsaNewArray();


#endif