#include <stdlib.h>
#include <stdio.h>
#include "btree.h"


PNode freeTree(PNode tree)
{
    if (tree->left)
        tree->left = freeTree(tree->left);
    if (tree->right)
        tree->right = freeTree(tree->right);
    free(tree);

    return NULL;
}

PNode freeList(PNode list)
{
    if (list->right)
        list->right = freeList(list->right);
    free(list);
    return NULL;
}

PNode newNode(int value)
{
    PNode node;
    node = (PNode)calloc(1, sizeof(Node));
    node->data = value;
    return node;
}

void insertNode(PNode *tree, PNode node)
{
    if (*tree == NULL)
    {
        *tree = node;
        return;
    }

    if (node->data < (*tree)->data)
        insertNode(&(*tree)->left, node);
    else if (node->data >(*tree)->data)
        insertNode(&(*tree)->right, node);
}

PNode findNode(PNode tree, int value)
{
    PNode node = NULL;
    if (tree)
    {
        if (value < tree->data)
            node = findNode(tree->left, value);
        else if (value > tree->data)
            node = findNode(tree->right, value);
        else
            node = tree;
    }
    return node;
}

PNode getOrderedList(PNode listNode, PNode treeNode)
{
    PNode node;

    if (treeNode->right)
        listNode = getOrderedList(listNode, treeNode->right);

    node = newNode(treeNode->data);
    if (listNode)
    {
        listNode->left = node;
        node->right = listNode;
    }
    listNode = node;

    if (treeNode->left)
        listNode = getOrderedList(listNode, treeNode->left);

    return listNode;
}

void printTree(PNode node)
{
    if (node->left)
        printTree(node->left);
    printf("%d ", node->data);
    if (node->right)
        printTree(node->right);
}

void printList(PNode node)
{
    printf("%d ", node->data);
    if (node->right)
        printList(node->right);
}
