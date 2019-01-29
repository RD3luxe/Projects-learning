class Test4 extends GeometricObject
{
	public double getPerimeter()
	{
		return 2.3 * 31;
	}

	@Override
	public double getArea() {
		// TODO Auto-generated method stub
		return 0;
	}

	@Override
	public void display() {
		// TODO Auto-generated method stub
		
	}
}

public class Main {
	public static void main(String[] args)
	{
		Test t = new Test(3.0);
		Test t2 = new Test(2.0);
		Test4 t4 = new Test4();
		t2.TDs();
		System.out.println(t2.compareTo(t4));
	
	}
}