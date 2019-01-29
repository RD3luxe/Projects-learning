package cacheMemory;

public class Basic extends Free
{
	private int m_basicSubs;
	Basic()
	{
		m_basicSubs = 0;
	}
	public int get_basicSubs() 
	{
		return m_basicSubs;
	}
	public void set_basicSubs(int m_basicSubs) 
	{
		this.m_basicSubs = m_basicSubs;
	}
}