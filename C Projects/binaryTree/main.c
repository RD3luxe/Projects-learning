#include<stdio.h>
#include<stdlib.h>

typedef struct node {
	int value;
	struct node *left, *right;
} *BinaryIntTree;

BinaryIntTree emptyBinaryIntTree = NULL;

BinaryIntTree tree(BinaryIntTree left, int root, BinaryIntTree right) {
	BinaryIntTree tmp = malloc(sizeof(struct node));
	tmp->value = root;
	tmp->left = left;
	tmp->right = right;
	return tmp;
}

BinaryIntTree left(BinaryIntTree a) {
	if(a == emptyBinaryIntTree) {
		printf("You try to access left for an empty tree!\n");
		exit(0);
	}
	return a->left;
}

BinaryIntTree right(BinaryIntTree a) {
	if(a == emptyBinaryIntTree) {
		printf("You try to access right for an empty tree!\n");
		exit(0);
	}
	return a->right;
}

int root(BinaryIntTree a) {
	if(a == emptyBinaryIntTree) {
		printf("You try to acess the root for an empty tree!\n");
		exit(0);
	}
	return a->value;
}

void printBinaryIntTree(BinaryIntTree a) {
	static int last = 0;
	last++;
	printf("(");
	if(a != emptyBinaryIntTree) {
		printBinaryIntTree(a->left);
		printf(",%d,",a->value);
		printBinaryIntTree(a->right);
	}
	last--;
	printf(")");
	if(last == 0) printf("\n");
}
void postOrdine(BinaryIntTree t)
{
   if(t != emptyBinaryIntTree)
   {
        postOrdine(left(t));
        postOrdine(right(t));
        printf("%d ",root(t));
   }
}
int height(BinaryIntTree t)
{
    int l = 0,r = 0;
    if(t == emptyBinaryIntTree)
    {
        return 0;
    }
    else
    {
        l = height(left(t));
        r = height(right(t));
        if( l > r || l == r)
        {
            return (l + 1);
        }
        else
        {
            return (r + 1);
        }
    }
}
int main() {
	BinaryIntTree a = tree(tree(emptyBinaryIntTree,2,emptyBinaryIntTree),1,tree(tree(emptyBinaryIntTree,4,emptyBinaryIntTree),3,tree(emptyBinaryIntTree,5,emptyBinaryIntTree)));
	printBinaryIntTree(a);
	printf("%d\n",height(a));
	postOrdine(a);
	return 0;
}


