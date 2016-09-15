#include "intDate.h"
#include <time.h>
#include <iostream>

using namespace std;

const int laps = 1000000;

template <typename T>
void testMyDate( T &dateSaved, T &dateFile )
{
	for( int ix = 0; ix < laps; ix++)
	{
		dateFile.setDateTime( "100102", "010102" );
		if( dateFile < dateSaved )
		{
			dateSaved = dateFile;
		}
	}
}

int main( int argc, char *argv[] )
{

	MyDate<int> intDateSaved(100102, 10103);
	MyDate<int> intDateFile;

	clock_t startTime = clock();
	testMyDate( intDateSaved, intDateFile );
	clock_t endTime = clock();

	cout << "Time for int:" << (double)(endTime-startTime)/CLOCKS_PER_SEC;


	MyDate<double> doubleDateSaved(100102, 10103);
	MyDate<double> doubleDateFile;

	startTime = clock();
	testMyDate( doubleDateSaved, doubleDateFile );
	endTime = clock();


}