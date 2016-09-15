#include <Windows.h>
#include <stdio.h>
#include <signal.h>


void SignalHandler( int signal );



int main()
{
    int sig = 0;

    if (signal(SIGINT, SignalHandler) == SIG_ERR)
        printf("\ncan't catch SIGINT\n");
    if (signal(SIGILL, SignalHandler) == SIG_ERR)
        printf("\ncan't catch SIGILL\n");
    if (signal(SIGFPE, SignalHandler) == SIG_ERR)
        printf("\ncan't catch SIGFPE\n");
    if (signal(SIGSEGV, SignalHandler) == SIG_ERR)
        printf("\ncan't catch SIGSEGV\n");
    if (signal(SIGTERM, SignalHandler) == SIG_ERR)
        printf("\ncan't catch SIGTERM\n");
    if (signal(SIGBREAK, SignalHandler) == SIG_ERR)
        printf("\ncan't catch SIGBREAK\n");
    if (signal(SIGABRT, SignalHandler) == SIG_ERR)
        printf("\ncan't catch SIGABRT\n");
 
     while(1) 
     {
        Sleep(1);
        printf("Typ number of signal to send\n \
            SIGINT   2 \n \
            SIGILL   4 \n \
            SIGFPE   8 \n \
            SIGSEGV  11\n \
            SIGTERM  15\n \
            SIGBREAK 21\n \
            SIGABRT  22 \n :");
        scanf("%d", &sig );
        raise(sig);
     }
   
}

void SignalHandler( int signal )
{
    switch( signal )
    {
    case SIGINT:/* interrupt */
        printf("Signal SIGINT received. Value=%d\n", signal );
        break;

    case SIGILL:/* illegal instruction - invalid function image */
        printf("Signal SIGILL received. Value=%d\n", signal );
        break;

    case SIGFPE: /* floating point exception */
        printf("Signal SIGFPE received. Value=%d\n", signal );
        break;

    case SIGSEGV:/* segment violation */
        printf("Signal SIGSEGV received. Value=%d\n", signal );
        break;

    case SIGTERM:/* Software termination signal from kill */
        printf("Signal SIGTERM received. Value=%d\n", signal );
        break;

    case SIGBREAK:/* Ctrl-Break sequence */
        printf("Signal SIGBREAK received. Value=%d\n", signal );
        break;

    case SIGABRT:/* abnormal termination triggered by abort call */
        printf("Signal SIGABRT received. Value=%d\n", signal );
        break;
    }

}