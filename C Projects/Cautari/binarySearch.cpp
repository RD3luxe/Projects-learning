// C++ code for fanion search x in arr[]. If x 
// is present then return its location, otherwise
// return n (size of the array)
#include<iostream>

int binarySearch(int arr[], int l, int r, int x)
{
    while (l <= r)
    {
        int m = (l+r)/2;
 
        // Check if x is present at mid
        if (arr[m] == x)
            return m;
 
        // If x greater, ignore left half
        if (arr[m] < x)
            l = m + 1;
 
        // If x is smaller, ignore right half
        else
            r = m - 1;
    }
 
    // if we reach here, then element was
    // not present
    return -1;
}
//recursiv way 
int recursivbinarySearch(int arr[], int l, int r, int x)
{
   if (r >= l)
   {
        int mid = (l+r)/2;
 
        // If the element is present at the middle 
        // itself
        if (arr[mid] == x)  
            return mid;
 
        // If element is smaller than mid, then 
        // it can only be present in left subarray
        if (arr[mid] > x) 
            return binarySearch(arr, l, mid-1, x);
 
        // Else the element can only be present
        // in right subarray
        return binarySearch(arr, mid+1, r, x);
   }
 
   // We reach here when element is not 
   // present in array
   return -1;
}
int main()
{
    int arr[] = { 1,4,5,12,16,26};
    int n = 6;
    int x = 26;
    int found = recursivbinarySearch(arr,0,n-1,x);
    if(found == -1)
        std::cout<<"Element nu exista in array.";
    else
        std::cout<<"Element gasit la indexul "<<found;
    return 0;
}