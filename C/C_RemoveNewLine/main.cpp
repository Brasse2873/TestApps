#include <string.h>


int main( int argc, char *argv[] )
{
	char string[20];
	
	strcpy( string, "Hej hopp \n") ;
	string[ strcspn( string, "\r\n" ) ] = '\0';

	strcpy( string, "Hej hopp") ;
	string[ strcspn( string, "\r\n" ) ] = '\0';

	strcpy( string, "Hej hopp \r\n") ;
	string[ strcspn( string, "\r\n" ) ] = '\0';

}
