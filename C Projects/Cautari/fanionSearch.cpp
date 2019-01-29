// C++ code for fanion search x in arr[]. If x 
// is present then return its location, otherwise
// return n (size of the array)
#include<iostream>

int fanionSearch(int arr[],int x)
{
	int i;
	while(arr[i] != x)
	    i++; 
	return i;
}
int main()
{
    int arr[6] = { 1,5,6,3,99 };
    int x = 939;
    arr[5] = x;
    int found = fanionSearch(arr,x);
    if(found == 5)
        std::cout<<"Element nu exista in array.";
    else
        std::cout<<"Element gasit la indexul "<<found;
    return 0;
}