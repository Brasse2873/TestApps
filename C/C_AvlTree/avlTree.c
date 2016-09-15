
#include <stdio.h>
#include <stdlib.h>
#include <memory.h>
#include "avlTree.h"

#define FALSE	0
#define TRUE	1

avlPNode	avlNewNode( unsigned long key, void *data );
int			avlDestroyNode( avlPTree tree, avlPNode node );
int			avlPostOrder( const avlPTree tree, const avlPNode node );
int			avlInOrder( const avlPTree tree, const avlPNode node );
avlPNode	avlInsertNode( avlPTree tree, avlPNode node, unsigned long key, void *data, int *balanced );
int			avlTouchNodeInOrder( const avlPTree tree, const avlPNode node );
avlPNode	avlFindNode( avlPNode node, unsigned long key );
void avlDisplayNode( const avlPNode ptr, int level, char levelSign );


void avlInit( avlPTree tree )
{
	memset( tree, 0, sizeof( avlTree ) );
}

avlPNode avlNewNode( unsigned long key, void *data )
{
	avlPNode node;
	node = (avlPNode)calloc( 1, sizeof( avlNode ) );
	node->data = data;
	node->key = key;

	return node;
}

void avlDestroy( avlPTree tree,
				int (*onDestroy)(void *func, unsigned long key, void *data) )
{
	if( !tree )
		return;

	tree->activeFunction = avlDestroyNode; 
	tree->onDestroy = onDestroy;
	avlPostOrder( tree, tree->root );
	memset( tree, 0, sizeof( avlTree ) );
	tree->activeFunction = NULL;
}

int avlDestroyNode( avlPTree tree, avlPNode node )
{
	if( tree->onDestroy )
		tree->onDestroy( tree->funcParam, node->key, node->data );
	if( node )
		free( node );

	return OK;
}

int onAvlDestroy( void *funcParam, unsigned long key, void *data )
{
	if(data)
		free( data );

	return OK;
}

avlPNode avlInsert( avlPTree tree, unsigned long key, void *data )
{
	int balanced;

	if( !tree )
		return NULL;

	tree->lastInsertedNode = NULL;
	tree->root = avlInsertNode( tree, tree->root, key, data, &balanced );
	if( tree->lastInsertedNode )
		tree->size++;

	return tree->lastInsertedNode;
}

avlPNode	avlInsertNode( avlPTree tree, avlPNode node, unsigned long key, void *data, int *balanced )
{
	avlPNode aptr;
	avlPNode bptr;

	if(node==NULL)
	{
		tree->lastInsertedNode = node = avlNewNode( key, data );
		*balanced = TRUE;
		return node;
	}

	if(key < node->key)
	{
		node->left = avlInsertNode( tree, node->left, key, data, balanced);
		if(*balanced==TRUE)
		{
			switch(node->balance)
			{
			case -1: /*Right heavy*/
				node->balance = 0;
				*balanced = FALSE;
				break;
			case 0: /*Balanced*/
				node->balance = 1;
				break;
			case 1: /*Right heavy*/
				aptr = node->left;
				if( aptr->balance == 1 )
				{
					/* Left to Left Rotation */
					node->left=aptr->right;
					aptr->right = node;
					node->balance = 0;
					aptr->balance = 0;
					node = aptr;
				}
				else
				{
					/* Left to Right rotation */
					bptr = aptr->right;
					aptr->right = bptr->left;
					bptr->left = aptr;
					node->left = bptr->right;
					bptr->right = node;
					switch( bptr->balance )
					{
					case 1:
						node->balance = -1;
						aptr->balance = 0;
						break;
					case 0:
						node->balance = 0;
						aptr->balance = 0;
						break;
					case -1:
						node->balance = 0;
						aptr->balance =  1;
						break;
					}
					bptr->balance = 0;
					node = bptr;
				}
				*balanced = FALSE;
			}
		}
	}

	if( key > node->key )
	{
		node->right = avlInsertNode( tree, node->right, key, data, balanced);
		if( *balanced == TRUE )
		{
			switch(node->balance)
			{
			case 1: /*Left heavy*/
				node->balance = 0;
				*balanced = FALSE;
				break;
			case 0: /*balanced*/
				node->balance = -1;
				break;
			case -1: /*Right heavy*/
				aptr = node->right;
				if( aptr->balance == -1 )
				{
					/* Right to right rotation */
					node->right = aptr->left;
					aptr->left = node;
					node->balance = 0;
					aptr->balance = 0;
					node = aptr;					
				}
				else
				{
					/* Right to left rotation */
					bptr = aptr->left;
					aptr->left = bptr->right;
					bptr->right = aptr;
					node->right = bptr->left;
					bptr->left = node;

					switch( bptr->balance )
					{
					case 1:
						node->balance = 0;
						aptr->balance = -1;
						break;
					case 0:
						node->balance = 0;
						aptr->balance = 0;
						break;
					case -1:
						node->balance = 1;
						aptr->balance =  0;
						break;
					}
					bptr->balance = 0;
					node = bptr;				
				}
				*balanced = FALSE;
			}
		}
	}

	return node;
}

int avlTouchInOrder( 	const avlPTree tree, 
						int (*onTouch)(void *funcParam, unsigned long key, void *data),			
						void *funcParam )
{
	int result;

	if( !tree->root )
		return FALSE;

	tree->onTouch = onTouch;
	tree->funcParam = funcParam;
	tree->activeFunction = avlTouchNodeInOrder;
	result = avlInOrder( tree, tree->root );
	tree->activeFunction = NULL;
	return result;
}

int avlTouchNodeInOrder( const avlPTree tree, const avlPNode node )
{
	if( !tree->onTouch )
		return FAIL;

	return tree->onTouch( tree->funcParam, node->key, node->data  );
}

avlPNode avlFind( const avlPTree tree, unsigned long key )
{
	return avlFindNode( tree->root, key );
}

avlPNode avlFindNode( avlPNode node, unsigned long key )
{
	avlPNode result = NULL;

	if( node )
	{
		if( key < node->key )
			result = avlFindNode( node->left, key );
		else if( key > node->key )
			result = avlFindNode( node->right, key );
		else
			result = node;
	}
	return result;
}

int avlInOrder( const avlPTree tree, const avlPNode node )
{
	if( node->left )
		if( avlInOrder( tree, node->left ) == FAIL )
			return FAIL;

	if( tree->activeFunction )
		if( tree->activeFunction( tree, node ) == FAIL )
			return FAIL;

	if( node->right )
		if( avlInOrder( tree, node->right ) == FAIL )
			return FAIL;

	return OK;
}

int avlPostOrder( const avlPTree tree, const avlPNode node )
{
	if( !node )
		return FAIL;

	if( node->left )
		if( avlPostOrder( tree, node->left ) == FAIL )
			return FAIL;

	if( node->right )
		if( avlPostOrder( tree, node->right )== FAIL )
			return FAIL;

	if( tree->activeFunction )
		if( tree->activeFunction( tree, node )== FAIL )
			return FAIL;

	return OK;
}

void avlLevelCount( avlPNode node,  int *count )
{
	if(!node)
		return;

	(*count)++;
	if( node->balance == -1)
		avlLevelCount( node->right, count );
	else
		avlLevelCount( node->left, count );

}

int avlLevels( avlPTree tree )
{
	int count = 0;

	if( !tree )
		return -1;

	avlLevelCount( tree->root, &count );

	return count;
}

void avlDisplayNode( const avlPNode node, int level, char levelSign )
{
	int i;

	if( !node )
		return;

	avlDisplayNode(node->right, level+1, '/' );
	printf("\n");
	for (i=0;i<level; ++i )
		printf("  ");		
	printf("%c%d", levelSign, node->key);
	avlDisplayNode(node->left, level+1, '\\' );
}

void avlDisplay( const avlPTree tree )
{
	avlDisplayNode(tree->root, 0, '-' );
}
