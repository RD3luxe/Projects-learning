// C++ code for fanion search x in arr[]. If x 
// is present then return its location, otherwise
// return n (size of the array)
#include<iostream>

int interpolationSearch(int a[],int n, int x)
{
    int l,r,m;
    l = 0; r = (n-1);
    while (l <= r && x >= a[l] && x <= a[r])
    {
        m = (x-a[l])/(a[r]-a[l])*(r-l) + l;

        if (a[m] == x)
            return m;

        if (a[m] < x)
            l = m + 1;
        else
            r = m - 1;
    }
    return -1;
}
int main()
{
    int arr[] = { 1,4,5,12,16,26};
    int n = sizeof(arr)/sizeof(arr[0]);
    int x = 12;
    int found = interpolationSearch(arr,n,x);
    if(found == -1)
        std::cout<<"Element nu exista in array.";
    else
        std::cout<<"Element gasit la indexul "<<found;
    return 0;
}