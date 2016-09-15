#include <stdlib.h>
#include "btree.h"


int main( const int argc, const char *argv[] )
{
	PNode root = NULL;
	PNode node = NULL;
	PNode list = NULL;

	insertNode( &root, newNode(5) );
	insertNode( &root, newNode(1) );
	insertNode( &root, newNode(7) );
	insertNode( &root, newNode(6) );
	insertNode( &root, newNode(10) );
	insertNode( &root, newNode(9) );
	insertNode( &root, newNode(8) );
	insertNode( &root, newNode(3) );
	insertNode( &root, newNode(4) );
	insertNode( &root, newNode(2) );

	printTree( root );

	node = findNode( root, 4 );
	node = findNode( root, 8 );
	node = findNode( root, 6 );

	list = getOrderedList( NULL, root );
	printList( list );
	
	root = freeTree( root );
	list = freeList( list );

}