#include <dirent.h> 
#include <stdio.h>
#include <sys/types.h>
#include <sys/stat.h>
#include <time.h>
#include <regex.h>


char *getDate( time_t * timeT, char *buf )
{
	struct tm *timeTM;

	timeTM = localtime( timeT );
	strftime( buf, 50, "%c", timeTM );
	return buf;
}

int main( int argc, char *argv[] )
{
	DIR *dir;
	struct dirent *dp;
	int res;
	struct stat fileStat;
	char *sourceDir = argv[1];
	char *fileFilter = argv[2];
	char date[50];
	char pathFile[255];

	dir = opendir(sourceDir);

	printf("Items in dir %s\n", sourceDir );

	while( ( dp = readdir( dir )) != NULL )
	{
		printf( "name:%s \n" , dp->d_name );
		sprintf( pathFile, "%s%s", sourceDir, dp->d_name );
		printf( "Get stat for file:%s \n" , pathFile );
		res = stat( pathFile, &fileStat );
		printf( "\tstat result: %d\n", res );
		printf( "\tlast access: %s\n", getDate(&fileStat.st_atime, date) );
		printf( "\tlast data modification: %s\n", getDate(&fileStat.st_mtime, date) );
		printf( "\tlast data modification: %s\n", getDate(&fileStat.st_mtime, date) );
		printf( "\n" );
	}

	closedir( dir );
}