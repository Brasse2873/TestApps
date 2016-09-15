#include <string.h>
#include <stdio.h>




char* ReplaceChar( char *string, char fromChar, char toChar  )
{
    char *pos = string;

    while( (pos = strchr(pos, fromChar )) != NULL )
    {
        *pos++ = toChar;
    }    

    return string;
}

int main( int argc, char *argv[] )
{
    char string[] = ";sträng med ; som skall hittas ;";
    char *pos = string;

    printf("string: %s\n",string);
    replaceChar( string, ';', ',' );
    printf("string: %s\n",string);
}

