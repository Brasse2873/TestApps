#include <stdlib.h>
#include <stdio.h>
#include <stddef.h>


typedef struct _struct1
{
	char cVar;
	int iVar;
	long lVar;
	char sVar[3];
	char cLastVar;
}struct1;

#pragma pack(1)
typedef struct _struct2
{
	char cVar;
	int iVar;
	long lVar;
	char sVar[3];
	char cLastVar;
}struct2;
#pragma pack()

typedef struct _struct3
{
	char cVar;
	int iVar;
	long lVar;
	char sVar[3];
	char cLastVar;
}struct3;

int main( const int argc, const char* argv[] )
{
	printf("struct1. default pack size\n");
	printf("cVar: %d\n", offsetof(struct1, cVar) );
	printf("iVar: %d\n", offsetof(struct1, iVar) );
	printf("lVar: %d\n", offsetof(struct1, lVar) );
	printf("sVar: %d\n", offsetof(struct1, sVar) );
	printf("cLastVar: %d\n", offsetof(struct1, cLastVar) );


	printf("struct2. pack size = 1\n");
	printf("cVar: %d\n", offsetof(struct2, cVar) );
	printf("iVar: %d\n", offsetof(struct2, iVar) );
	printf("lVar: %d\n", offsetof(struct2, lVar) );
	printf("sVar: %d\n", offsetof(struct2, sVar) );
	printf("cLastVar: %d\n", offsetof(struct2, cLastVar) );

	printf("struct3. pack size = 1\n");
	printf("cVar: %d\n", offsetof(struct3, cVar) );
	printf("iVar: %d\n", offsetof(struct3, iVar) );
	printf("lVar: %d\n", offsetof(struct3, lVar) );
	printf("sVar: %d\n", offsetof(struct3, sVar) );
	printf("cLastVar: %d\n", offsetof(struct3, cLastVar) );

	return EXIT_SUCCESS;
}
