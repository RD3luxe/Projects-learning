package cacheMemory;

public class FIFOCache implements Cache
{	
	private Premium mem[];
	private int counter;
	private int maxDimension;
	public FIFOCache(int maxCacheDim)
	{
		mem = new Premium[maxCacheDim];
		maxDimension = maxCacheDim;
		counter = 0;
	}
	public Premium[] getCache()
	{
		return mem;
	}
	@Override
	public void add(Premium m_ObjName)
	{	
		if(counter >= maxDimension)
		{
			for(int i = 0;i < counter-1;i++)
			{
				mem[i] = mem[i+1];
			}
			counter--;
		}
		mem[counter++] = m_ObjName;
	}
	@Override
	public void remove(Premium m_ObjName) 
	{
		for(int i = 0;i < counter;i++)
		{
			if(mem[i].get_titularName().contains(m_ObjName.get_titularName()))
			{
				for(int j = 0;j < counter-1;j++)
				{
					mem[j] = mem[j+1];
				}
			}
		}
		counter--;
		if(counter <= 0)
			counter = 0;
	}
	@Override
	public int exist(String name) 
	{
		for(int i = 0;i < counter;i++)
		{
			if(mem[i] != null && mem[i].get_titularName().contains(name))
			{
				return i;
			}
		}
		return -1;
	}
}