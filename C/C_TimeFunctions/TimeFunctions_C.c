
#include <time.h>
#include <string.h>
#include <stdio.h>
#include <Windows.h>


int main(int argc, char* argv[])
{
	clock_t start_clock_t;
	clock_t end_clock_t;
	struct tm *var_ptm;
	time_t var_time_t;
	time_t var2_time_t;
	char formattedDated[255];

	time( &var_time_t );
	printf("time test: time_t=%u\n\n", var_time_t );

	//clock, in:-, out:clock_t
	start_clock_t = clock();
	Sleep( 1000 );
	end_clock_t = clock();
	printf("Test clock: clock_t=%f\n\n", (double)(end_clock_t - start_clock_t )/ CLOCKS_PER_SEC );

	//gmtime, in:time_t, out:tm
	var_ptm = gmtime( &var_time_t );
	printf("gmtime test: tm_hour=%d, tm_isdst=%d, tm_mday=%d, tm_min=%d, tm_mon=%d, tm_sec=%d, tm_wday=%d, tm_yday=%d, tm_year=%d\n", 
		var_ptm->tm_hour, 
		var_ptm->tm_isdst,
		var_ptm->tm_mday,
		var_ptm->tm_min,
		var_ptm->tm_mon,
		var_ptm->tm_sec,
		var_ptm->tm_wday,
		var_ptm->tm_yday,
		var_ptm->tm_year );

	//localtime, in:time_t, out:tm
	var_ptm = localtime( &var_time_t );
	printf("localtime test: tm_hour=%d, tm_isdst=%d, tm_mday=%d, tm_min=%d, tm_mon=%d, tm_sec=%d, tm_wday=%d, tm_yday=%d, tm_year=%d\n", 
		var_ptm->tm_hour, 
		var_ptm->tm_isdst,
		var_ptm->tm_mday,
		var_ptm->tm_min,
		var_ptm->tm_mon,
		var_ptm->tm_sec,
		var_ptm->tm_wday,
		var_ptm->tm_yday,
		var_ptm->tm_year );

	//mktime, in:tm, out:time_t
	var_time_t = mktime( var_ptm );
	printf("mktime test: \ntime_t=%u\n", var_time_t );
	var_ptm = localtime( &var_time_t );
	printf("tm: tm_hour=%d, tm_isdst=%d, tm_mday=%d, tm_min=%d, tm_mon=%d, tm_sec=%d, tm_wday=%d, tm_yday=%d, tm_year=%d\n\n", 
		var_ptm->tm_hour, 
		var_ptm->tm_isdst,
		var_ptm->tm_mday,
		var_ptm->tm_min,
		var_ptm->tm_mon,
		var_ptm->tm_sec,
		var_ptm->tm_wday,
		var_ptm->tm_yday,
		var_ptm->tm_year );

	//ctime, in:time_t, out:string
	strcpy( formattedDated, ctime( &var_time_t ) );
	printf("ctime test: result=%s, time_t=%u\n\n",formattedDated, var_time_t );

	//strftime
	strftime( formattedDated, 255, "a=%a \n A=%A \n b=%b \n B=%B \n c=%c \n d=%d \n H=%H \n I=%I \n j=%j \n m=%m \n M=%M \n p=%p \n S=%S \n U=%U \n w=%w \n W=%W", var_ptm );
	printf("strftime test:\n%s", formattedDated );
	strftime( formattedDated, 255, "\n x=%x \n X=%X \n y=%y \n Y=%Y \n z=%z \n Z=%Z", var_ptm );
	printf("%s\n\n", formattedDated );

	time( &var2_time_t );

	printf("This function used %6.0f s",difftime( var2_time_t, var_time_t ) );

	return 0;
}


void subtractOneDay()
{
	char str[21];
	struct tm *date;
	time_t  tt;

	time( &tt );
	date = localtime( &tt );
	strftime( str, 21,"%d-%b-%Y 00:00:00", date ); 

	tt -= 86400;
	date = localtime( &tt ); //Note! localtime uses a single instance of tm per thread.
	strftime( str, 21,"%d-%b-%Y 23:59:59", date ); 
}

