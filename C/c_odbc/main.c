#include <stdio.h>
#include <Windows.h>
#include <sql.h>
#include <sqlext.h>
#include <stddef.h>

/*Bra info sida: http://www.easysoft.com/developer/languages/c/odbc_tutorial.html */

SQLINTEGER dbConnect( SQLHANDLE *penvironmentHandle, SQLHANDLE *pconnectionHandle, char *connectionString );
SQLINTEGER dbSelectQuery(SQLHANDLE connectionHandle);
SQLINTEGER printSQLError( const char *function, SQLHANDLE *handle, SQLSMALLINT handleType );
SQLINTEGER dbInsert(SQLHANDLE connectionHandle);


int main( int argc, char *argv[])
{
	SQLHENV		environmentHandle;
	SQLHDBC		connectionHandle;
	SQLRETURN   ret = 0;

	if( dbConnect( &environmentHandle, &connectionHandle, (SQLCHAR*)"DSN=CdrStatistics_32" ) )
		return EXIT_FAILURE;


	dbSelectQuery( connectionHandle );

	dbInsert( connectionHandle );

	// Deallocate handles
	SQLFreeHandle( SQL_HANDLE_DBC, connectionHandle );
	SQLFreeHandle( SQL_HANDLE_ENV, environmentHandle );
}

SQLINTEGER dbConnect( SQLHANDLE *penvironmentHandle, SQLHANDLE *pconnectionHandle, char *connectionString )
{
	SQLINTEGER result = 0;

	// 1) Allocate environment handle
	if( !SQL_SUCCEEDED(SQLAllocHandle( SQL_HANDLE_ENV, SQL_NULL_HANDLE, penvironmentHandle ) ) )
		result = printSQLError( "SQLAllocHandle", penvironmentHandle, SQL_HANDLE_ENV );

	// 2) Setup environment, Use ODBC 3
	if( !result && !SQL_SUCCEEDED(SQLSetEnvAttr( *penvironmentHandle, SQL_ATTR_ODBC_VERSION, (void *) SQL_OV_ODBC3, 0 ) ) )
		result = printSQLError( "SQLSetEnvAttr", penvironmentHandle, SQL_HANDLE_ENV );

	// 3) Allocate connection handle
	if( !result && !SQL_SUCCEEDED(SQLAllocHandle( SQL_HANDLE_DBC, *penvironmentHandle, pconnectionHandle )) )
		result = printSQLError( "SQLAllocHandle", pconnectionHandle, SQL_HANDLE_DBC );

	// 4) Connect to data source
	if( !result && !SQL_SUCCEEDED(SQLDriverConnect( *pconnectionHandle, NULL, (SQLCHAR*)connectionString, SQL_NTS, NULL, 0, NULL, SQL_DRIVER_COMPLETE ) ) ) 
		result = printSQLError( "SQLDriverConnect", pconnectionHandle, SQL_HANDLE_DBC );

	return result;
}

int dbBeginTransaction( SQLHANDLE *connectionHandle )
{
	if( !SQL_SUCCEEDED(SQLSetConnectAttr( connectionHandle, SQL_ATTR_AUTOCOMMIT, SQL_AUTOCOMMIT_OFF, 0)) ) 
	{
		return printSQLError( "SQLSetConnectAttr", connectionHandle, SQL_HANDLE_DBC );
	}
	return 0;
}

int dbCommit( SQLHANDLE connectionHandle )
{
	SQLRETURN ret = 0;

	ret = SQLEndTran( SQL_HANDLE_DBC, connectionHandle, SQL_COMMIT );
	if( !SQL_SUCCEEDED( ret ) )
	{
		return printSQLError( "SQLEndTran", &connectionHandle, SQL_HANDLE_DBC );
	}

	if( !SQL_SUCCEEDED( SQLSetConnectAttr( connectionHandle, SQL_ATTR_AUTOCOMMIT, (SQLPOINTER)SQL_AUTOCOMMIT_ON , 0) ) ) 
	{
		return printSQLError( "SQLSetConnectAttr", &connectionHandle, SQL_HANDLE_DBC );
	}

	return 0;
}

int dbRollback( SQLHANDLE connectionHandle )
{
	SQLRETURN ret = 0;

	ret = SQLEndTran( SQL_HANDLE_DBC, connectionHandle, SQL_ROLLBACK );
	if( !SQL_SUCCEEDED( ret ) )
	{
		return printSQLError( "SQLEndTran", &connectionHandle, SQL_HANDLE_DBC );
	}

	return 0;
}

SQLINTEGER dbSelectQuery( SQLHANDLE connectionHandle )
{
	SQLHSTMT	statementHandle = NULL;
	SQLSMALLINT col;
	SQLSMALLINT row = 0;
	SQLSMALLINT columns;
	SQLINTEGER indicator;
	char buf[512];
	SQLRETURN ret;

	// 5) Allocate statement handle
	if( !SQL_SUCCEEDED(ret = SQLAllocHandle( SQL_HANDLE_STMT, connectionHandle, &statementHandle ) ) )
		printSQLError( "SQLSetEnvAttr", &statementHandle, SQL_HANDLE_STMT );

	// 6) Execute query
	if( !SQL_SUCCEEDED( SQLExecDirect( statementHandle, (SQLCHAR*)"Select * from stat_file", SQL_NTS ) ) )
		printSQLError( "SQLExecDirect", &statementHandle, SQL_HANDLE_STMT );

	SQLNumResultCols( statementHandle, &columns);

	while( SQL_SUCCEEDED( SQLFetch(statementHandle) ) ) 
	{
		printf("Row %d\n", row++);
		/* Loop through the columns */
		for (col = 1; col <= columns; ++col) 
		{
			/* retrieve column data as a string */
			ret = SQLGetData(statementHandle, col, SQL_C_CHAR,
								 buf, sizeof(buf), &indicator);

			if (SQL_SUCCEEDED(ret)) 
			{
				/* Handle null columns */
				if (indicator == SQL_NULL_DATA) 
					strcpy(buf, "NULL");
				printf("  Column %u : %s\n", col, buf);
			}
		}
	}

	if( statementHandle ) SQLFreeHandle( SQL_HANDLE_STMT, statementHandle );

	return ret;
}

SQLINTEGER dbInsert( SQLHANDLE connectionHandle )
{
	SQLHSTMT	statementHandle = NULL;

	if( !SQL_SUCCEEDED(SQLAllocHandle( SQL_HANDLE_STMT, connectionHandle, &statementHandle ) ) )
		printSQLError( "SQLSetEnvAttr", &statementHandle, SQL_HANDLE_STMT );

	if( !SQL_SUCCEEDED( SQLExecDirect( statementHandle, (SQLCHAR*)"insert into stat_file (system_unit_id,source_file_name_in) values (1,'AMAFILE.dat')", SQL_NTS ) ) )
		return printSQLError( "SQLExecDirect", &statementHandle, SQL_HANDLE_STMT );

	if( statementHandle ) SQLFreeHandle( SQL_HANDLE_STMT, statementHandle );

	return 0;
}

SQLINTEGER printSQLError( const char *function, SQLHANDLE *handle, SQLSMALLINT handleType )
{
	SQLSMALLINT		recordNumber = 0;
    SQLINTEGER		nativeErrorNumber = 0;
    SQLCHAR			state[ 7 ];
    SQLCHAR			errorMessage[256];
    SQLSMALLINT		resultLength = 0;
	SQLINTEGER		recordCount = 0;

    printf( "The driver reported the following diagnostics whilst running %s\n\n", function );

	if( SQL_SUCCEEDED( SQLGetDiagField( handleType, *handle, 0, SQL_DIAG_NUMBER, (void*)(&recordCount), sizeof(recordCount)-1, &resultLength ) ) )
	{
		for( recordNumber = 0; recordNumber < recordCount; ++recordNumber )
		{
			if( SQL_SUCCEEDED(  SQLGetDiagRec(handleType, *handle, ++recordNumber, state, &nativeErrorNumber, errorMessage, sizeof(errorMessage), &resultLength ) ) )
			{
				printf("%s:%ld:%ld:%s\n", state, recordNumber, nativeErrorNumber, errorMessage );
				break;
			}
		}
	}

	return nativeErrorNumber;
}