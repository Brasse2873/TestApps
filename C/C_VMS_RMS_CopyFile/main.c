
#include <rms.h>
#include <starlet.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>

typedef struct FAB Fab;
typedef struct RAB Rab;

Fab InFab, OutFab;
Rab InRab, OutRab;

#define REC_SIZE 200
char RecordBuffer[REC_SIZE];

void InitInFab(const char *fileName );
void InitInRab();
void InitOutFab(const char *fileName);
void InitOutRab();
int OpenInFile();
int CreateOutFile();
void CloseFiles();
int CopyRecords();

int main(int argc, const char *argv[])
{
    int result;
    int lib$signal();

    if (argc != 3)
    {
        printf("Usage: Main <infile> <outfiles>\n");
        return EXIT_FAILURE;
    }

    InitInFab( argv[1] );
    InitInRab();
    if( !(OpenInFile() & 1 ) )
        return EXIT_FAILURE;
    printf("Infile open\n");

    InitOutFab( argv[2] );
    InitOutRab();
    if( !(CreateOutFile() & 1) )
        return EXIT_FAILURE;
    
    printf("Outfile created\n");


    result = CopyRecords();

    CloseFiles();
    printf("Files are closed\n");


    return result;
}

void InitInFab(const char *fileName )
{
    //Init struct (manditory)
    InFab = cc$rms_fab;

    //Set file name and size
    InFab.fab$l_fna = (char*)fileName;
    InFab.fab$b_fns = strlen(fileName);
}

void InitOutFab(const char *fileName)
{
    //Init struct (manditory)
    OutFab = cc$rms_fab;

    //Set file name and size
    OutFab.fab$l_fna = (char*)fileName;
    OutFab.fab$b_fns = strlen(fileName);

    //Set fields from original file (InFab)
    OutFab.fab$l_alq = InFab.fab$l_alq; /* Set proper size for output */
    OutFab.fab$w_mrs = InFab.fab$w_mrs;

    //Set other fields
    OutFab.fab$v_ctg = 1;           // Allocate contigeously
    OutFab.fab$v_put = 1;           // Write access (default on create)
    OutFab.fab$v_nil = 1;           // No sharing (default on create)
    OutFab.fab$b_rat = FAB$M_CR;    // Set option using bitMask
}

void InitInRab()
{
    InRab = cc$rms_rab;

    InRab.rab$l_fab = &InFab;

    InRab.rab$v_rah = 1;
    InRab.rab$l_ubf = RecordBuffer;
    InRab.rab$w_usz = REC_SIZE;
}

void InitOutRab()
{
    OutRab = cc$rms_rab;

    OutRab.rab$l_fab = &OutFab;
    OutRab.rab$v_wbh = 1;            // Write Ahead
    OutRab.rab$l_rbf = RecordBuffer;
}

int OpenInFile()
{
    int stat = sys$open( &InFab );
    if (stat & 1)    {
        stat = sys$connect( &InRab );
        if (!(stat & 1))        {
            printf("OpenInFile:connect failed\n");
        }
    }
    else    {
        printf("OpenInFile:Open failed\n");
    }

    return stat;
}

int CreateOutFile()
{
    int stat = sys$create( &OutFab );
    if (stat & 1) {
        stat = sys$connect(&OutRab);
        if (!(stat & 1)) {
            printf("CreateOutFile:connect failed\n");
        }
    }
    else {
        printf("CreateOutFile:create failed\n");
    }

    return stat;
}

void CloseFiles()
{
    sys$close( &InFab );
    sys$close( &OutFab );
}

int CopyRecords()
{
    int stat = 1;
    int lineCount = 0;
    while (stat & 1)
    {
        memset(RecordBuffer, 0, REC_SIZE );
        if ((stat = sys$get( &InRab )) & 1)
        {
            OutRab.rab$w_rsz = InRab.rab$w_rsz; // set correct size
            stat = sys$put( &OutRab );
            lineCount++;
        }
    }

    if (stat != RMS$_EOF)
    {
        printf("CopyRecords failed: stat=%d\n",stat );
    }

    printf("Copied lines: %d\n", lineCount );
    return stat;
}