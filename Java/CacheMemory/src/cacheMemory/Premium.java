package cacheMemory;

public class Premium extends Basic
{
	private int m_premiumSubs;
	Premium(String titularName)
	{
		m_premiumSubs = 0;
		super.set_titularName(titularName);
	}
	public int get_premiumSubs() 
	{
		return m_premiumSubs;
	}
	public void set_premiumSubs(int m_premiumSubs) 
	{
		this.m_premiumSubs = m_premiumSubs;
	}
}