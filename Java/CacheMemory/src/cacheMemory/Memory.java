package cacheMemory;
import java.util.ArrayList;

public class Memory 
{
	private ArrayList<Premium> myMemory = new ArrayList<Premium>();
	public ArrayList<Premium> getMyMemory() 
	{
		return myMemory;
	}
	public boolean search(String name)
	{
		for(int i = 0;i < myMemory.size();i++)
		{
			//System.out.println(myMemory.get(i).get_titularName() +" : "+ name);
			if(myMemory.get(i).get_titularName().contains(name))
			{
				return true;
			}
		}
		return false;
	}
	public int getByTitluar(String name)
	{
		for(int i = 0;i < myMemory.size();i++)
		{
			if(myMemory.get(i).get_titularName().contains(name))
			{
				return i;
			}
		}
		return -1;
	}
}