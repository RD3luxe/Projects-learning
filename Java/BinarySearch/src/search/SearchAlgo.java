package search;

public class SearchAlgo 
{
	private final int maxElements = 100000;
	public int BinarySearch(int arr[],int st,int dr,int x)
	{
		if(st > dr)
		{
			int m = st + (dr - st) / 2;
			if(arr[m] == x)
			{
				return m;
			}
			if(arr[m] > x)
			{
				return BinarySearch(arr,st,m-1,x);
			}
			return BinarySearch(arr,m+1,dr,x);
		}
		return -1;
	}
	
	public int LinearSearch(int arr[],int x)
	{
		int length = arr.length;
		for(int i = 0;i < length;i++)
		{
			if(arr[i] == x)
				return i;
		}
		return -1;
	}
	
	public void PopulateArray(int arr[]) 
	{
		int j = 0;
		for(int i = 25;i <= maxElements;i += 2)
		{
			arr[j] = i;
			j++;
		}
	}
	
	public static void main(String[] args) 
	{
		SearchAlgo s = new SearchAlgo();
		int searched = 213;
		int arr[] = new int[s.maxElements + 10];
		s.PopulateArray(arr);
		int result = s.BinarySearch(arr, 0, arr.length - 1, searched);
		System.out.print("Binary search found the element "+searched+" at index "+result);
		result = s.LinearSearch(arr,searched);
		System.out.print("Linear search found the element "+searched+" at index "+result);
	}
}
