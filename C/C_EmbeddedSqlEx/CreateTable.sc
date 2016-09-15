#include<stdio.h>
#include<stdlib.h>
#include<string.h>

EXEC SQL BEGIN DECLARE SECTION;
	int 	err_code;
	char	err_msg[256];
EXEC SQL END DECLARE SECTION;


int main( int argc, char *argv[] )
{
	EXEC SQL BEGIN DECLARE SECTION;
        char *dbname = "comviqprod";        
        char sql[1000];             
        int custCount;
        int		dbRowCount = 0;
	EXEC SQL END DECLARE SECTION;



    
	EXEC SQL CONNECT :dbname;
	EXEC SQL INQUIRE_SQL (:err_msg = errortext, :err_code = errorno);
	if(err_code != 0)
	{
		printf("Connect failed. Errorno: %d\tError Msg: %s\n", err_code, err_msg);
		return err_code;
	}
    printf("Connect to DB OK\n");    
    

    
    
/*    sprintf(sql, "DECLARE GLOBAL TEMPORARY TABLE session.my_tmp_table AS\
                    select cust_id\
                    from\
                      cust_mast\
                    where\
                      cust_id = 11247044\
                    ON COMMIT PRESERVE ROWS WITH NORECOVERY");
 */   
    
    
    //EXEC SQL EXECUTE IMMEDIATE :sql;		
    EXEC SQL DECLARE GLOBAL TEMPORARY TABLE  session.my_tmp_table 
    AS
        select cust_id
    from
        cust_mast
    where
        cust_id >= 11247000
        and 
        cust_id <= 11248000
    ON COMMIT PRESERVE ROWS 
    WITH NORECOVERY;

	EXEC SQL INQUIRE_SQL (:err_msg = errortext, :err_code = errorno, :dbRowCount = rowcount);
	if(err_code != 0)
	{
		printf("Execute immediate failed. Errorno: %d\tError Msg: %s\n", err_code, err_msg);
		return err_code;
	}
    printf("Create session table OK. Rowcount:%d\n",dbRowCount );
    
  
    EXEC SQL SELECT 
        count(*)
    INTO
        :custCount
    FROM
        session.my_tmp_table;
        
    printf("Count:%d\n",custCount);
	EXEC SQL INQUIRE_SQL (:err_msg = errortext, :err_code = errorno, :dbRowCount = rowcount);
	if(err_code != 0)
	{
		printf("Get count from session table  failed. Errorno: %d\tError Msg: %s\n", err_code, err_msg);
		return err_code;
	}
    printf("Get count OK. rowCount:%d\n",dbRowCount);
    
    
    
    EXEC SQL DISCONNECT;
    
    return 0;
}