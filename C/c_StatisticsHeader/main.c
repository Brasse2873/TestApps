#include "statPrint.h"
#include <stdlib.h>


int main(const int argc, const char *argv[] )
{
	FILE *statFile = fopen("c:\\temp\\statPrint.log","a" );

	printStatHeader( stdout, "c:\\temp\\cdmkdccsweiq02318","c:\\temp\\cdmkdccsweiq02318.done" );
	printStatStartBlock(stdout);
	printStatEndBlock(stdout);

	printStatHeader( statFile, "c:\\temp\\cdmkdccsweiq02318","c:\\temp\\cdmkdccsweiq02318.done" );
	printStatStartBlock( statFile );
	printStatEndBlock( statFile );


}