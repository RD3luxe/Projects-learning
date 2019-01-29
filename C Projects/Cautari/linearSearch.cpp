// C++ code for linearly search x in arr[]. If x 
// is present then return its location, otherwise
// return -1
#include<iostream>

int linearSearch(int arr[], int n, int x)
{
	int i = 0;
	while(i < n && arr[i] != x)
		i++;
	return i;
}
int main()
{
    int arr[5] = { 1,5,6,3,99 };
    int x = 2;
    int found = linearSearch(arr,5,x);
    if(found == 5)
        std::cout<<"Element nu exista in array.";
    else
        std::cout<<"Element gasit la indexul "<<found;
    return 0;
}