#ifndef INCL_BTREE
#define INCL_BTREE

typedef struct _node {
    int data;
    struct _node *left;
    struct _node *right;
}Node, *PNode;



extern PNode findNode(PNode tree, int value);
extern void printList(PNode node);
extern void printTree(PNode node);
extern PNode getOrderedList(PNode listNode, PNode treeNode);
extern void insertNode(PNode *tree, PNode node);
extern PNode newNode(int value);
extern PNode freeList(PNode list);
extern PNode freeTree(PNode tree);



#endif