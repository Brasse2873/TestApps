#include <stdio.h>
#include "bst.h"

void onBstNodeTouch( bst_PNode node );
void onBstNodeDestroy( bst_PNode node );


typedef struct _myData{
	int ival;
} MyData;

int main( const int argc, const char *argv[] )
{
	Bst tree;
	MyData d1 = {1};
	MyData d2 = {2};
	MyData d3 = {3};

	bst_init( &tree, onBstNodeTouch, onBstNodeDestroy );

	bst_insert( &tree, d1.ival, &d1 );
	bst_insert( &tree, d2.ival, &d2 );
	bst_insert( &tree, d3.ival, &d3 );

	bst_touchInOrder( &tree );

	bst_destroy( &tree );
}


void onBstNodeTouch( bst_PNode node )
{
	printf("Touch node: %d\n",bst_nodeKey(node) );
}


void onBstNodeDestroy( bst_PNode node )
{
	printf("Destroy node: %d\n",bst_nodeKey(node) );
}