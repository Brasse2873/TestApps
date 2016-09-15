// TimeFunctions_C.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <time.h>
#include <string.h>

int _tmain(int argc, _TCHAR* argv[])
{
	clock_t var_clock_t;
	tm *var_ptm;
	time_t var_time_t;
	char formattedDated[255];

	time( &var_time_t );
	printf("time test: time_t=%I64u\n\n", var_time_t );

	//clock, in:-, out:clock_t
	var_clock_t = clock();
	printf("Test clock: clock_t=%d\n\n",var_clock_t);

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
	printf("mktime test: \ntime_t=%I64u\n", var_time_t );
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
	printf("ctime test: result=%s, time_t=%I64u\n\n",formattedDated, var_time_t );

	//strftime
	strftime( formattedDated, 255, "a=%a \n A=%A \n b=%b \n B=%B \n c=%c \n d=%d \n H=%H \n I=%I \n j=%j \n m=%m \n M=%M \n p=%p \n S=%S \n U=%U \n w=%w \n W=%W", var_ptm );
	printf("strftime test:\n%s", formattedDated );
	strftime( formattedDated, 255, "\n x=%x \n X=%X \n y=%y \n Y=%Y \n z=%z \n Z=%Z", var_ptm );
	printf("%s\n\n", formattedDated );

	return 0;
}


