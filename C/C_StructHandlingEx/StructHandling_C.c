#include <stdio.h>
#include <stdlib.h>

typedef struct SItem
{
	int ifield;
	double dfield;
	char cfield[10];
}Item;

void printItem( char *itemName, Item *item )
{
	printf("%s: %d, %1.1f, %s\n",itemName, item->ifield, item->dfield, item->cfield );
}

int main( int argv, char *arvc[] )
{
	Item item1 = { 1, 1.0, "item 1" };
	Item item2 = { 2, 2.0, "item 2" };

	printItem( "item1", &item1 );
	
	//if( item1 == item2 ) Not OK


	item1 = item2; //OK
	printItem( "item1", &item1 );

	return EXIT_SUCCESS;
}