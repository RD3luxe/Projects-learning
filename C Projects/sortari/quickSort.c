
#include <stdio.h>

// To heapify a subtree rooted with node i which is
// an index in arr[]. n is size of heap
void swap(int *a,int *b)
{
    int t = *a;
    *a = *b;
    *b = t;
}
void qs(int s[],int st,int dr)
{
    int i = st;
    int j = dr;
    int x = s[(st+dr)/2];
    do
    {
        while(i < dr && s[i] < x) i++;
        while(j > st && x < s[j]) j--;
        
        if(i <= j)
        {
            swap(&s[i],&s[j]);
            i++;
            j--;
        }
        
    }while(i <= j);
    if(st < j) qs(s,st,j);
    if(i < dr) qs(s,i,dr);
}
void quick_sort(int a[],int n)
{
    qs(a,0,n-1);
}
/* A utility function to print array of size n */
void printArray(int arr[], int n)
{
    int i;
	for (i=0; i<n; ++i)
		printf("%d ",arr[i]);
	printf("\n");
}

// Driver program
int main()
{
	int arr[] = {12, 11, 13, 5, 6, 7};
	int n = sizeof(arr)/sizeof(arr[0]);
	quick_sort(arr, n);
	printf("Sorted array is \n");
	printArray(arr, n);
}
