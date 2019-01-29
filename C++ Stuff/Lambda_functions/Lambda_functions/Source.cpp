#include <iostream>
#include <vector>
#include <algorithm>
#include <chrono>
#include <random>

//function for generating random numbers
int generateRandom(int min,int max)
{
	auto seed = std::chrono::system_clock::now().time_since_epoch().count();
	std::default_random_engine engine(seed);
	std::uniform_int_distribution<int> distribution(min, max);
	return distribution(engine);
}

//simple point class
class Point
{
public :
	int X, Y;
	Point()
	{
		X = generateRandom(0, 100);
		Y = generateRandom(0, 100);
		//std::cout << "Point created" << std::endl;
	}
	void print()
	{
		std::cout << "( " << X << " " << Y << " )" << std::endl;
	}
};

int main()
{
	int aa = 5;
	int i = 10;
	// -> int represents the returned type
	auto lambda = [aa](int a, int b) -> int
	{
		return a + b + aa;
	};
	// = add automatically vars to capture list
	// & everything is captured by reference
	auto lambda2 = [=]() -> int
	{
		return aa + i;
	};
	//u can capture some var by variable and one or more by reference
	auto lambda3 = [=,&i]() -> int
	{
		i = 10;
		return aa + i;
	};
	std::cout << lambda(10, 10) << std::endl;
	std::cout << lambda3()<<" "<<i<<" "<< lambda2()<< std::endl;
	//lambda can be user with foreach or in place for loops
	std::vector<int> arr = { 1,6,3,2,7,10 };
	//get the total using a for_each with lambda function
	int total = 0;
	std::for_each(begin(arr), end(arr), [&](int x) { total += x; });
	std::cout << total << std::endl;
	//use lambda functions with sorting/algorithms
	std::vector<Point> points;
	points.reserve(10);
	for (int i = 0; i < 10; i++)
	{
		points.emplace_back(Point());
	}
	for (Point p : points)
	{
		p.print();
	}
	std::cout << "After sorting : " << std::endl;
	std::sort(points.begin(), points.end(), 
		[](const Point& a, const Point& b) -> bool
		{ 
			return a.X > b.X; 
		}
	);
	for (Point p : points)
	{
		p.print();
	}
	std::getchar();
	return 0;
}