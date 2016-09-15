#include <memory.h>
#include <stdio.h>
#include <string.h>

typedef struct
{
    char xtemp[10];
    char start_date[7];
    char start_time[7];
    char first_date[13];
    char last_date[13];
    char old_date[7];
    char old_time[7];
    char call_type[2];
    char called_msisdn[35];
    char calling_msisdn[25];
    char called_sms_msisdn[35];
    char calling_imsi[21];
    char suppl_service[41];
    long msc_id;
    unsigned int lac_id;
    unsigned int cell_id;
    unsigned int call_duration;
    short int called_msisdn_type;
    short int calling_msisdn_type;
    short ms_classmark;
    char inc_truncgrp[7];
    short record_type;
} LM_DATA;

void Func1()
{
	char called_number[30];
	char called_msisdn[30];
	char* szRow = "224007782039083709146737440966          0810704491523               46246809011105493230    MICINCFFFFFF8111  0  0  0 4  101C\n";

	memset( called_number, 0, 30 );
	memset( called_msisdn, 0, 30 );
    strncpy( called_number, &szRow[43], strchr(&szRow[43],' ')- &szRow[43] );

	if ( ( szRow[41] == '9' ) && ( called_number[0] != '0' ))
    {
        strcpy( called_msisdn, "00" );
    }
    strcat( called_msisdn, called_number );
}

int main()
{
	LM_DATA lm_data;
	char buff[255];

	Func1();

	memset( &lm_data, 0, sizeof(LM_DATA) );
	memset(buff,0xF,255);

    lm_data.call_type[0] = 'U';
    strcpy( lm_data.calling_imsi, "240077950227704" );
    strcpy( lm_data.calling_msisdn, "46736350780" );
    strcpy( lm_data.xtemp, "81" );
    strcpy( lm_data.called_msisdn, "0704491523" );
    lm_data.msc_id = 4;
    lm_data.lac_id = 62465;
    strcpy( lm_data.start_date, "090111" );
    strcpy( lm_data.start_time, "055000" );
    lm_data.call_duration = 0;
    lm_data.ms_classmark = 0xABCD;
    lm_data.record_type = 0x1;
    lm_data.cell_id = 0xFEDCBA98;
    strcpy( lm_data.inc_truncgrp, "MICINC" );

    sprintf( buff,
        "%1s%-15s091%-21s0%-2s%-21s%5ld%5ld%-6s%-6s%-6d%6s%08X%-11s %2d %4X\n",
        lm_data.call_type,
        lm_data.calling_imsi,
        lm_data.calling_msisdn,
        &lm_data.xtemp[strlen(lm_data.xtemp)-2],
        lm_data.called_msisdn,
        lm_data.msc_id,
        lm_data.lac_id,
        lm_data.start_date,
        lm_data.start_time,
        lm_data.call_duration,
        lm_data.inc_truncgrp,
        lm_data.ms_classmark,
        "12345678901",
        lm_data.record_type,
        lm_data.cell_id);


}

