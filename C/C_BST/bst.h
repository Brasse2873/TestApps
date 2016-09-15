#ifndef INCL_BST_H
#define INCL_BST_H

typedef struct _bst_Node{
	unsigned long key;
	void *data;
	struct _bst_Node *left;
	struct _bst_Node *right;
}bst_Node, *bst_PNode;

typedef struct _bst{
	bst_Node *root;
	unsigned long size;

	void (*activeFunction)( PBst, bst_PNode );
	void (*touch)( bst_PNode );
	void (*destroy)( bst_PNode );
}Bst, *PBst;


void bst_init( PBst tree, void (*touch)(bst_PNode), void (*destroy)(bst_PNode) );
void bst_destroy( PBst tree );
bst_PNode bst_insert( PBst tree, unsigned long key, void *data );
void bst_touchInOrder( PBst tree );


#define bst_nodeData( node ) ((node)->data)
#define bst_nodeKey( node ) ((node)->key)
#define bst_size( tree ) ((tree)->size)


#endif //INCL_BST_H