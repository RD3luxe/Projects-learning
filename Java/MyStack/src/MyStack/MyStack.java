package MyStack;
import java.util.ArrayList;

class MyStack
{
	private int size = 0;
	private ArrayList<Object> list;
	
	public MyStack()
	{
		list = new ArrayList<Object>();
	}
	public void push(Object o)
	{
		list.add(size,o);
		size++;
	}
	public int search(Object o)
	{
		if(!list.isEmpty())
		{
			if(list.contains(o))
				return list.lastIndexOf(o);
			else
				return -1;
		}
		return -1;
	}
	public Object pop()
	{
		if(!list.isEmpty())
		{
			size--;
			Object ob = list.get(list.size() - 1);
			list.remove(list.size()-1);
			return ob;
		}
		return null;
	}
	public Object peek()
	{
		if(!list.isEmpty())
		{
			return list.get(list.size()-1);
		}
		return null;
	}
	public int getSize()
	{
		return size;
	}
	public Boolean isEmpty()
	{
		return size == 0 ? true:false;
	}
	public String toString()
	{
		String s = new String();
		for(int i = size-1;i >= 0;i--)
		{
			s += list.get(i).toString() + " ";
		}
		return s;
	}
	public static void main(String[] args)
	{
		MyStack stack = new MyStack();
		System.out.println(stack.isEmpty());
		stack.push(10);
		stack.push(15);
		stack.push(18);
		stack.push(20);
		stack.push(21);
		System.out.println(stack.isEmpty());
		System.out.println(stack.toString());
		System.out.println(stack.getSize());
		Object elem = stack.pop();
		System.out.println(stack.toString());
		System.out.println(stack.getSize());
		System.out.println(stack.peek());
		System.out.println(stack.search(20));
		System.out.println(elem.toString());
	}
}