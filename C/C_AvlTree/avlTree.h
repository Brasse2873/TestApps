#ifndef INCL_AVLTREE
#define INCL_AVLTREE

enum avlResult { FAIL, OK };

typedef struct _avlNode{
	unsigned long	key;
	void*			data;
	int				balance;
	struct _avlNode	*left;
	struct _avlNode	*right;	
}avlNode, *avlPNode;


typedef struct _avlTree{
	avlPNode		root;
	unsigned long	size;
	avlPNode		lastInsertedNode;
	void			*funcParam;

	int (*activeFunction)( struct _avlTree*, struct _avlNode* );

	int (*onTouch)( void *funcParam, unsigned long key, void *data );
	int (*onDestroy)( void *funcParam, unsigned long key, void *data );
}avlTree, *avlPTree;


void avlInit( avlPTree tree );

void avlDestroy( avlPTree tree, 
				int (*onTouch)(void *func, unsigned long key, void *data) );

int onAvlDestroy( void *funcParam, unsigned long key, void *data );

avlPNode avlInsert( avlPTree tree, unsigned long key, void *data );	

avlPNode avlFind( const avlPTree tree, unsigned long key );

int avlTouchInOrder(	const avlPTree tree, 
						int (*onTouch)(void *func, unsigned long key, void *data),			
						void *funcParam );

void avlDisplay( const avlPTree tree );
int avlLevels( avlPTree tree );

#endif