import java.util.Random;

public class SearchAlgo 
{
	// Change here max elements of the array
	public final int maxElements = 100000000;
	public int BinarySearch(int arr[],int st,int dr,int x)
	{
		if(dr >= st)
		{
			int m = st + (dr - st)/2;
			if(arr[m] == x)
			{
				return m;
			}
			else if(arr[m] > x)
			{
				return BinarySearch(arr,st,m-1,x);
			}
			else return BinarySearch(arr,m+1,dr,x);
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
		for(int i = 0;i < maxElements;i++)
		{
			arr[i] = i;
		}
	}
	
	public void printResult(int searched,int res,boolean isBinary,long time)
	{
		// Transform the time in milliseconds
		time /= 1000000;
		if(res == -1)
		{
			System.out.println("Element not found in the array.");
		}
		else 
		{
			if(isBinary)
			{
				System.out.print("Binary search found the element "+searched+" in "+time+" milliseconds at index "+res+"\n");
			}else{
				System.out.print("Linear search found the element "+searched+" in "+time+" milliseconds at index "+res+"\n");
			}
		}
	}
	
	public static void main(String[] args) 
	{
		SearchAlgo algo = new SearchAlgo();
		// Create a random number to search for 
		//Random rand = new Random();
		int searched = algo.maxElements - 1;//rand.nextInt(algo.maxElements - 300) + 100;
		int arr[] = new int[algo.maxElements];
		// Populate the array
		algo.PopulateArray(arr);
		// Start timer for binary search
		long startTime = System.nanoTime();
		int result = algo.BinarySearch(arr,0,arr.length-1,searched);
		long endTime = System.nanoTime();
		// End timer for binary search and get the time lapsed
		long timeLapsed = endTime - startTime;
		// Print the results
		algo.printResult(searched, result, true,timeLapsed);
		// Start timer for linear search
		startTime = System.nanoTime();
		result = algo.LinearSearch(arr,searched);
		endTime = System.nanoTime();
		// End timer for linear search and the the time lapsed
		timeLapsed = endTime - startTime;
		// Print the results
		algo.printResult(searched, result, false,timeLapsed);
	}
}