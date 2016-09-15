#ifndef STATPRINT_H
#define STATPRINT_H

#include <stdio.h>

void	printStatHeader( FILE *output, const char * inFile, const char *outFile );
void	printStatStartBlock( FILE *output );
void	printStatEndBlock( FILE *output );

#endif