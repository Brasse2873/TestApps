// FileManagement_Win_cpp.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>

using namespace std;

int _tmain(int argc, _TCHAR* argv[])
{
	int fileCount = 0;
	WIN32_FIND_DATA findData;
	LPCSTR filePathName = "REKO_PROD*.sql";

	//iterate directory
	HANDLE hFileSearch = FindFirstFile(filePathName, &findData );
	if( hFileSearch ==  INVALID_HANDLE_VALUE )
	{
		cout <<  TEXT("Faild to open file TW_PROD*.sql. Error code = ") << GetLastError();
		return 1;
	}

	do
	{
		fileCount++;
		cout << findData.cFileName  << endl; 

	}while( FindNextFile( hFileSearch, &findData ) );

	cout << "Found # files: " << fileCount << endl;
	FindClose( hFileSearch );


	//Delete file
	if( !DeleteFile( "filetodelete.txt" ) )
	{
		cout <<  TEXT("Faild to delete file filetodelete.txt. Error code = ") << GetLastError();
	}




	int dummy;
	cin >> dummy;

	return 0;
}

