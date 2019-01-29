
#include <stdio.h>

void shellSort(int s[],int n)
{
    int i,j,k,w,t;
    int h[3] = { 3,2,1 };
    for(w = 0;w < 3;w++)
    {
        k = h[w];
        for(i = k;i < n;i++)
        {
            t = s[i];
            j = i - k;
            while(j >= 0 && s[j] > t)
            {
                s[j+k] = s[j];
                j -= k;
            }
            s[j+k] = t;
        }
    }
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

	shellSort(arr, n);

	printf("Sorted array is \n");
	printArray(arr, n);
}
