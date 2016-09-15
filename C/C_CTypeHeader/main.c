#include <ctype.h>
#include <stdio.h>

void testIsalnum()
{
	char *data = "1234567890abcdefghijklmnopqrstuvwxyzåäö";
	char *pos = data;
	
	while( *pos != '\0' )
	{
		isalnum( *pos & 0xff )? printf("%c is alphanumeric\n", *pos & 0xff ):printf("%c is not alphanumeric\n", *pos & 0xff ); 
		pos++;
	}
}

void testIsalpha()
{
}

void testIscntrl()
{
}

void testIsdigit()
{
}

void testIsgraph()
{
}

void testIslower()
{
}

void testIsprint()
{
}

void testIspunct()
{
}

void testIsspace()
{
}

void testIsupper()
{
}

void testIsxdigit()
{
}

void testTolower()
{
}

void testToupper()
{
}
int main(int argc, char *argv[] )
{
	testIsalnum();	
}

