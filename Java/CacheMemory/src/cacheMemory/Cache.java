package cacheMemory;

public interface Cache
{
	public abstract void add(Premium m_ObjName);
	public abstract void remove(Premium m_ObjName);
	public abstract Premium[] getCache();
	public abstract int exist(String name);
}