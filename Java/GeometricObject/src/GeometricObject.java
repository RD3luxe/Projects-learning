import java.util.Date;
public abstract class GeometricObject implements Comparable
{
	private String color;
	private boolean filled;
	private Date dateCreated;
	
	protected GeometricObject() 
	{
		color = "red";
		filled = false;
		dateCreated = new Date();
	}
	protected GeometricObject(String color, boolean filled) {
		this.color = color;
		this.filled = filled;
	}
	public String getColor() {
		return color;
	}
	public void setColor(String color) {
		this.color = color;
	}
	public boolean isFilled() {
		return filled;
	}
	public void setFilled(boolean filled) {
		this.filled = filled;
	}
	public Date getDateCreated() {
		return dateCreated;
	}
	public abstract double getArea();
	public abstract double getPerimeter();
	public abstract void display();
	public void TDs()
	{
		System.out.println("Base here");
	}
	public int compareTo(Object o)
	{
		if(getPerimeter() > ((GeometricObject)o).getPerimeter())
			return 1;
		else if(getPerimeter() < ((GeometricObject)o).getPerimeter())
			return -1;
		return 0;
	}
}

class Test extends GeometricObject
{
	double perim;
	public Test()
	{
		super();
	}
	public Test(double d)
	{
		super();
		perim = d;
	}
	public double getArea()
	{
		return 1.0 * perim;
	}
	public double getPerimeter()
	{
		return 2.3 * perim;
	}
	public void display()
	{
		System.out.println(getDateCreated());
	}
	public void TDs()
	{
		//super.TDs();
		//System.out.println("Derived here");
	}
}
interface Comparable
{
	public abstract int compareTo(Object o);
}