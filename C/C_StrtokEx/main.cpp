#include <string.h>
#include <stdio.h>


int main( int argc, char *argv[] )
{
	char string[] = "\"3079610001;1421831;1390;;;5309113750;;1;TELEFONI - FAST;1014604T2AUG01N63145;0\"";	
	char *pos = NULL;

	pos = strtok( string,";");

	while( pos != NULL )
	{
		printf("%s\n",pos);
		pos = strtok( NULL,";");
	}

}


