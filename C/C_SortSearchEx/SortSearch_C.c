#include <stdlib.h>
#include <stdio.h>

typedef struct _item
{
	int intField;
	char *strField;
}Item;


int cmpItems( const void *item1, const void *item2 )
{
	if( ((Item*)item1)->intField < ((Item*)item2)->intField )
	{
		return -1;
	}
	if( ((Item*)item1)->intField > ((Item*)item2)->intField )
	{
		return 1;
	}
	else
	{
		return 0;
	}
}

void printItems( Item items[], int count )
{
	int ix;
	for( ix = 0; ix < count; ++ix )
	{
		printf("%d, %s\n", items[ix].intField, items[ix].strField );
	}
}

int main( int argc, char* argv[] )
{
	Item item;
	Item *pitem;
	Item items[] = { {4,"Item 4"}, {2,"Item 2"}, {5, "Item 5"}, {3,"Item 3"}, {1, "Item 1"} };

	printf("Initial organization\n");
	printItems( items, 5 );

	qsort( items, 5, sizeof(Item), cmpItems );
	printf("\nAfter qsort\n");
	printItems( items, 5 );

	item.intField = 3;
	pitem = (Item*)bsearch( &item, items, 5, sizeof(Item), cmpItems );
	if( pitem )
	{
		printf("\nFound item: %d, %s\n", pitem->intField, pitem->strField );
	}
	else
	{
		printf("\nItem 6 not found");
	}

	return EXIT_SUCCESS;
}