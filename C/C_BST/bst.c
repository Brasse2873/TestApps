#include <stdlib.h>
#include <string.h>
#include "bst.h"


bst_PNode bst_newNode( unsigned long key, void *data );
void bst_insertNode( bst_PNode *node, bst_PNode newNode );
void bst_inorder( PBst tree, bst_PNode node );
void bst_postorder( PBst tree, bst_PNode node );

void bst_destroyNode( PBst tree, bst_PNode node );
void bst_touchNodeInOrder( PBst tree, bst_PNode node );


void bst_init( PBst tree, void (*touch)(bst_PNode), void (*destroy)(bst_PNode) )
{
	tree->activeFunction = NULL;
	tree->touch = touch;
	tree->destroy = destroy;
	tree->root = NULL;
	tree->size = 0;
}

void bst_destroy( PBst tree )
{
	if( !tree )
		return;

	tree->activeFunction = bst_destroyNode; 
	bst_postorder( tree, tree->root );
	memset( tree, 0, sizeof( Bst ) );
}

void bst_destroyNode( PBst tree, bst_PNode node )
{
	tree->destroy( node );
	free( node );
}

bst_PNode bst_newNode( unsigned long key, void *data )
{
	bst_PNode node;
	node = (bst_PNode)calloc( 1, sizeof( bst_Node ) );
	node->data = data;
	node->key = key;

	return node;
}

bst_PNode bst_insert( PBst tree, unsigned long key, void *data )
{
	bst_PNode node = NULL;

	if( !tree )
		return NULL;

	node = bst_newNode( key, data );
	bst_insertNode( &tree->root, node );
	tree->size++;

	return node;
}

void bst_insertNode( bst_PNode *node, bst_PNode newNode )
{
	if( *node==NULL )
	{
		*node = newNode;
		return;
	}

	if( newNode->key < (*node)->key )
		bst_insertNode( &(*node)->left, newNode );

	if( newNode->key > (*node)->key )
		bst_insertNode( &(*node)->right, newNode );

}

void bst_touchInOrder( PBst tree )
{
	if( !tree->root )
		return;

	tree->activeFunction = bst_touchNodeInOrder;
	bst_inorder( tree, tree->root );
}

void bst_touchNodeInOrder( PBst tree, bst_PNode node )
{
	tree->touch( node );
}

void bst_inorder( PBst tree, bst_PNode node )
{
	if( node->left )
		bst_inorder( tree, node->left );

	if( tree->activeFunction )
		tree->activeFunction( tree, node );

	if( node->right )
		bst_inorder( tree, node->right );
}

void bst_postorder( PBst tree, bst_PNode node )
{
	if( !node )
		return;

	bst_postorder( tree, node->left );
	bst_postorder( tree, node->right );
	tree->activeFunction( tree, node );
}