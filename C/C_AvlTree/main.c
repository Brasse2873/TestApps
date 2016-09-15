#include <stdio.h>
#include "avlTree.h"


int onPrintItem( void *funcParam, unsigned long key, void *data )
{
	printf("Key = %d, value = %d\n",key, *(int*)data);
	return OK;
}


int main( const int argc, const char *argv[] )
{
	avlTree tree;
	int items[10] = {101,102,103,104,105,106,107,108,109,100};
	avlPNode node = NULL;

	avlInit( &tree );

	avlInsert( &tree, 1, &items[0] );
	avlInsert( &tree, 2, &items[1] );
	avlInsert( &tree, 3, &items[2] );
	avlInsert( &tree, 4, &items[3] );
	avlInsert( &tree, 5, &items[4] );
	avlInsert( &tree, 6, &items[5] );
	avlInsert( &tree, 7, &items[6] );
	avlInsert( &tree, 8, &items[7] );
	avlInsert( &tree, 9, &items[8] );
	avlInsert( &tree, 0, &items[9] );

	printf("\nTree info: Items=%d, levels=%d\n",tree.size, avlLevels(&tree) );
	avlTouchInOrder( &tree , onPrintItem, NULL );

	node = avlFind(&tree, 3);
	printf("\nSeach for nr:3, result: key=%d, value=%d\n", node->key, *(int*)node->data  );

	avlDisplay( &tree );

	avlDestroy( &tree, NULL );
}