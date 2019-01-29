
#include <stdio.h>

void swap(int *a,int *b)
{
    int t = *a;
    *a = *b;
    *b = t;
}
void shakeSort(int s[],int n)
{
    int j,k,l,r;
    l = 1;
    r = n - 1;
    k = n -1;
    do
    {
        //prima partitie
        for(j = r;j >= l;j--)
        {
            if(s[j-1] > s[j])
            {
                swap(&s[j-1],&s[j]);
                k = j;
            }
        }
        l = k+1;
        //a 2-a
        for(j = l;j <= r;j++)
        {
            if(s[j-1] > s[j])
            {
                swap(&s[j-1],&s[j]);
                k = j;
            }
        }
        r = k-1;
    }while(l <= r);
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
	int arr[] = {12, 11, 9, 5, 6, 7};
	int n = sizeof(arr)/sizeof(arr[0]);

	shakeSort(arr, n);

	printf("Sorted array is \n");
	printArray(arr, n);
}
