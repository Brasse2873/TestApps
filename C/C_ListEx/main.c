#include<stdlib.h>
#include<stdio.h>

typedef struct _ListItem
{
	struct _ListItem *prev;
	struct _ListItem *next;

	int data;
} ListItem;


ListItem*  removeItem( ListItem *item )
{
	ListItem *prev;
	ListItem *next;
	ListItem *result = NULL;

	if( item )
	{
		next = item->next;
		prev = item->prev;

		if( next ) 
			next->prev = prev;

		if( prev )
			prev->next = next;

		free( item );
	}

	if( prev )
		result = prev;
	else if( next )
		result = next;

	return result;
}

void removeAll( ListItem *item )
{
	while( ( item = removeItem( item ) ) ); 
}

ListItem*  add( ListItem *item, ListItem *at )
{
	ListItem *next = at->next;

	at->next = item;
	item->prev = at;
	if( next )
	{
		next->prev = item;
		item->next = next;
	}

	return item;
}

ListItem* newItem( int value )
{
	ListItem *item = (ListItem*)calloc( 1, sizeof(ListItem) );
	item->data = value;
	return item;
}

void print( ListItem *list )
{
	while( list != NULL )
	{
		printf( "%d, ", list->data );
		list = list->next;
	}
	printf("\n");
}

int main( int argc, char *argv[] )
{
	ListItem *list = newItem( 1 );
	ListItem *currItem = list;
	currItem = add( newItem( 2 ), currItem );
	printf("List from start:");
	print( list );

	printf("List from currItem: ");
	print( currItem );

	add( newItem( 3 ), list );
	printf("List from start:");
	print( list );

	removeAll( list );
}