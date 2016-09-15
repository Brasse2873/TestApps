#include <rms>        /* defines for rabs and fabs    */
#include <stdio.h>    /* defins printf...             */
#include <starlet>    /* defines sys$open et al       */
#include <errno.h>
#include <string.h>
#include <stdlib.h>

struct FAB  InFab;
struct RAB  InRab;

const char *FileName;
const char *FileType;
#define REC_SIZE 140
char rec_buff[REC_SIZE];     /* maximum record size                */
int stat;

void printAccessConstants();
void printFab(struct FAB *fab);
void InitFab();
void InitRab();
int Open();
int Close();
int ReadFile();
int ReadRecord();
int lib$signal();
void BasicReadFile();

int main( const int argc, const char *argv[] )
{
    int result = 0;
    FileName = argv[1];
    FileType = argv[2];

    if (argc < 3)
    {
        printf("Usage: main <fileName> <file type>\n"); 
        return EXIT_FAILURE;
    }

    BasicReadFile();

	printf("press enter to continoue");
	getchar();

	return EXIT_SUCCESS;
}


// *** BasicReadFile ***
//-----------------------
void BasicReadFile()
{
    InitFab();
    InitRab();
    if ( Open() )
        return;
    if ( ReadFile() )
        return;
    printFab(&InFab);
    Close();
}

void InitFab()
{
    printf("InitFab\n");
    InFab = cc$rms_fab;                     // Make this a real FAB (bid and bln)

    InFab.fab$l_fna = (char*)FileName;		        
    InFab.fab$b_fns = strlen(FileName);	    

    InFab.fab$l_dna = (char*)FileType;
    InFab.fab$b_dns = strlen(FileType);
}

void InitRab()
{
    printf("InitRab\n");
    InRab = cc$rms_rab;                     // Make this a real RAB (bid and bln) 

    InRab.rab$l_fab = &InFab;               // Point to FAB for $CONNECT     
         
    InRab.rab$v_rah = 1;                    // Set bitVield to request read-ahead 
    InRab.rab$l_ubf = rec_buff;             // Point to buffer area..             
    InRab.rab$w_usz = REC_SIZE;             // and indicate its size              
}

int Open()
{
    int result = EXIT_SUCCESS;

    printf("Open\n");

    stat = sys$open(&InFab);

    if (stat & 1)
    {
        printf("File %s is open\n", InFab.fab$l_fna);
    }
    else
    {
        printf("sys$open failed: result=%X, reason: %s\n", stat, strerror(errno));
        return stat;
    }

    stat = sys$connect(&InRab);
    if (stat & 1)
    {
        printf("sys$connect OK\n" );
    }
    else
    {
        printf("sys$connect failed: result=%X, reason: %s\n", stat, strerror(errno));
        return stat;
    }

    return result;
}

int Close()
{
    int result = EXIT_SUCCESS;

    printf("Close\n");

    sys$close(&InFab);

    return result;
}

int ReadRecord()
{    
    int result = EXIT_SUCCESS;
    int len;

    memset(rec_buff,0,REC_SIZE );

    if( (stat = sys$get(&InRab)) & 1 )
    {
        len = InRab.rab$w_rsz;
        printf("Line:\t%d\t%s\n", len, rec_buff);
    }
    else
    {   
        result = stat;
        if( stat != RMS$_EOF )
        {
            printf("ReadRecord faild: result=%X, reason: %s\n", stat, strerror(errno));
        }
    }

    return result;
}

int ReadFile()
{
    int result = EXIT_SUCCESS;
    stat = 1;

    while ((result = ReadRecord()) == EXIT_SUCCESS );

    return result;
}



// *** Common ***
//-----------------------
void printFab(struct FAB *fab)
{
    printf("fab$b_acmodes=%hc \t\t file access modes\n", fab->fab$b_acmodes);
    printf("fab$l_alq=%lu \t\t allocation quantity (blocks)\n", fab->fab$l_alq);
    printf("fab$b_bid=%x \t\t block identifier\n", fab->fab$b_bid);
    printf("fab$b_bks=%x \t\t bucket size\n", fab->fab$b_bks);
    printf("fab$b_bln=%x \t\t block length\n", fab->fab$b_bln);
    printf("fab$w_bls=%hu \t\t magnetic tape block size\n", fab->fab$w_bls);
    printf("fab$l_ctx=%ld \t\t context\n", fab->fab$l_ctx);			
    printf("fab$w_deq=%hd \t\t default file extension quantity\n", fab->fab$w_deq);
    printf("fab$l_dna=%s \t\t default file specification string address\n", fab->fab$l_dna);
    printf("fab$b_dns=%x \t\t default file specification string size\n", fab->fab$b_dns);
    printf("fab$b_fac=%x \t\t file access\n", fab->fab$b_fac);			
    printf("fab$l_fna=%s \t file specification string address\n", fab->fab$l_fna);
    printf("fab$b_fns=%x \t\t file specification string size\n", fab->fab$b_fns);	
    printf("fab$l_fop=%lu \t\t file-processing options\n", fab->fab$l_fop);			
    printf("fab$b_fsz=%x \t\t fixed-length control area size\n", fab->fab$b_fsz);	
    printf("fab$w_gbc=%hu \t\t global buffer count\n", fab->fab$w_gbc);			
    printf("fab$w_ifi=%hd \t\t internal file identifier\n", fab->fab$w_ifi);	
    printf("fab$b_journal=%x \t journal flags status\n", fab->fab$b_journal);	
    printf("fab$v_lnm_mode=%ld \t logical name translation access mode\n", fab->fab$v_lnm_mode);
    printf("fab$l_mrn=%lu \t\t maximum record number\n", fab->fab$l_mrn);			
    printf("=fab$w_mrs%hu \t\t maximum record size\n", fab->fab$w_mrs);		
    printf("fab$b_org=%x \t\t file organization\n", fab->fab$b_org);		
    printf("fab$b_rat=%x \t\t record attributes\n", fab->fab$b_rat);		
    printf("=fab$b_rfm%x \t\t record format\n", fab->fab$b_rfm);			
    printf("fab$b_rtv=%x \t\t retrieval window size\n", fab->fab$b_rtv);	
    printf("fab$l_sdc=%lu \t secondary device characteristics\n", fab->fab$l_sdc);
    printf("fab$b_shr=%x \t\t file sharing\n", fab->fab$b_shr);		
    printf("fab$l_sts=%lu \t completion status code\n", fab->fab$l_sts);
    printf("fab$l_stv=%lu \t\t status values\n", fab->fab$l_stv);
}

void printAccessConstants()
{
    printf("FAB$V_BRO:%#X\n", FAB$V_BRO);
    printf("FAB$V_DEL:%#X\n", FAB$V_DEL);
    printf("FAB$V_GET:%#X\n", FAB$V_GET);
    printf("FAB$V_PUT:%#X\n", FAB$V_PUT);
    printf("FAB$V_TRN:%#X\n", FAB$V_TRN);
    printf("FAB$V_UPD:%#X\n", FAB$V_UPD);
    //printf("FAB$V_SHRBRO:%#X\n",FAB$V_SHRBRO);
    printf("FAB$V_SHRDEL:%#X\n", FAB$V_SHRDEL);
    printf("FAB$V_SHRGET:%#X\n", FAB$V_SHRGET);
    printf("FAB$V_SHRPUT:%#X\n", FAB$V_SHRPUT);
    printf("FAB$V_SHRUPD:%#X\n", FAB$V_SHRUPD);
    printf("FAB$V_NIL :%#X\n", FAB$V_NIL);
    printf("FAB$V_UPI  :%#X\n", FAB$V_UPI);
    printf("FAB$V_MSE  :%#X\n", FAB$V_MSE);
}
