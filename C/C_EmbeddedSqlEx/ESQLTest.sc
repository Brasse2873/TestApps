EXEC SQL INCLUDE SQLCA;		 /*Sql's error hantering*/
EXEC SQL WHENEVER SQLERROR call Ingres_Error;

#include<stdio.h>
#include<stdlib.h>
#include<string.h>
#include<memory.h>


EXEC SQL BEGIN DECLARE SECTION;
	int 	err_code;
	char	err_msg[256];
	int		nRowCount = 0;
	char	sqlstatement[1000];
	char	szQueryText[1000];
EXEC SQL END DECLARE SECTION;

void SelectDataCursor();



void Ingres_Error(void)
{
	printf("Ingres error\n");
}


int main (int argc, char *argv[])
{
	int result = 0;
	EXEC SQL BEGIN DECLARE SECTION;
	char 	dbname[20];
	EXEC SQL END DECLARE SECTION;
	
	memset( dbname, 0, 20 );
	memset( err_msg, 0, 255 );
	memset( sqlstatement, 0, 1000 );
	
	strcpy(dbname,"dmo4_2db");

	printf("Connect to db\n");
	EXEC SQL CONNECT: dbname;
	EXEC SQL INQUIRE_SQL (:err_msg = errortext, :err_code = errorno);
	if(err_code != 0)
	{
		printf("Connect failed. Errorno: %d\tError Msg: %s\n", err_code, err_msg);
		result = err_code;
	}
	if( result == 0 )
	{
		printf("Connect OK\n");

		SelectDataCursor();
		
		return 0;
		exec sql set autocommit off;	

		strcpy( sqlstatement, "drop table micke_airr_air_rate_tmp2" );			
		printf("execute SQL: %s\n", sqlstatement ); 
		exec sql execute immediate :sqlstatement;		
		EXEC SQL INQUIRE_SQL (:err_msg = errortext,	:err_code = errorno, :nRowCount = rowcount, :szQueryText = querytext);
		printf("SQL result: err_code=%d, nRowCount = %d, szQueryText = %s\n", err_code, nRowCount, szQueryText);		
 		if(err_code != 0)
		{
			printf("Errorno: %d\tError Msg:%s\n", err_code, err_msg);
			result = err_code;
		}
		
		strcpy( sqlstatement, "create table micke_airr_air_rate_tmp as select * from airr_air_rate" );			
		printf("execute SQL: %s\n", sqlstatement ); 
		exec sql execute immediate :sqlstatement;		
		EXEC SQL INQUIRE_SQL (:err_msg = errortext,	:err_code = errorno, :nRowCount = rowcount, :szQueryText = querytext);
		printf("SQL result: nRowCount = %d, szQueryText = %s\n", nRowCount, szQueryText);		
 		if(err_code != 0)
		{
			printf("Errorno: %d\tError Msg:%s\n", err_code, err_msg);
			result = err_code;
		}
		
		
	}
	
	if( result == 0 )
	{ 
		printf("execute SQL OK\n");
		exec sql commit;
	}
	else
	{
		printf("execute SQL Failed\n");
		exec sql rollback;
	}
	
	
	return result;
}



void SelectDataCursor()
{
	EXEC SQL BEGIN DECLARE SECTION;
		double 	dbMsisdn = 0;
		long 	dbCustId = 0;
	EXEC SQL END DECLARE SECTION;

	EXEC SQL WHENEVER SQLERROR GO TO db_error;
	EXEC SQL DECLARE CUR_MSISDN CURSOR FOR
		SELECT 
			cust_id
			,ifnull(tele_numb,0)			
		FROM   
			cust_mast;
			
	EXEC SQL OPEN CUR_MSISDN;

	do
	{
		EXEC SQL FETCH CUR_MSISDN
		INTO
			:dbCustId
			,:dbMsisdn;
		printf("SelectData: cust_id=%d, msisdn=%.0f\n",dbCustId,dbMsisdn);	
	}while (!sqlca.sqlcode);
	
	EXEC SQL CLOSE CUR_MSISDN;
	
	return;
	
db_error:	
	EXEC SQL INQUIRE_SQL (:err_msg = errortext,	:err_code = errorno, :nRowCount = rowcount, :szQueryText = querytext);
	printf("SQL result: err_code=%d, nRowCount = %d, szQueryText = %s\n", err_code, nRowCount, szQueryText);		
	EXEC SQL CLOSE CUR_MSISDN;
}