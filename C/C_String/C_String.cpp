// C_String.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"


int _tmain(int argc, _TCHAR* argv[])
{
    char *stackString = "Stack string";
    
    printf("stackString = %s\n",stackString);

    stackString = "Multi line declaration \
    \nLine 2 \
    \nLine 3\n";
    printf("stackString = %s",stackString);


	return 0;
}

