#include <dirent.h> 
#include <stdio.h>

int main( int argc, char *aragv[] )
{
	DIR *dir;
	struct dirent *dp;

	dir = opendir("TE_USR:[SCHERERM.CSM]");

	printf("Items in dir TE_USR:[SCHERERM.CSM]\n" );

	while( ( dp = readdir( dir )) != NULL )
	{
		printf( "d_name = %s, d_ino  = %d\n" , dp->d_name, dp->d_ino );
	}

	closedir( dir );
}