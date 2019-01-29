#include <iostream>
#include <Windows.h>
#include <string>

//Invisible whitespace can fuck this up
#define FANCY \
	system("PAUSE");\
	return 0; }

//cool debuging method
#define DEBUG 1
#if DEBUG
	#define LOG(x) std::cout<<x<<std::endl;
#else
	#define LOG(x)
#endif

//extern variables can't be initialize , also if we don't use extern we will get a linker error
extern int extern_test;

//static variable
int test_static = 16;

//Singleton class
class Singleton
{
public :
	//returning by refrence
	static Singleton& Get()
	{
		static Singleton instance;
		return instance;
	}
	void Hello()
	{
		LOG("Hey, I'm single.");
	}
};

class Entity
{
private :
	int X, Y;
public :
	Entity()
	{

	}
	Entity(int x,int y) : X(x) , Y(y)
	{
		std::cout << "Entity constructor called." <<x<<" : "<<y<< std::endl;
	}
	~Entity()
	{
		//std::cout << "Entity destructor called." << std::endl;
	}
	void Move()
	{
		X++;
		Y++;
	}
};

//declaring a class
class Player : public Entity
{
private:
	int x, y;
public:
	Player()
	{

	}
	//explicit used on constructor lul..
	Player(int X, int Y) : x(X), y(Y)
	{
		//2 ways for initializing
		//this->x = x;
		//this->y = y;
		std::cout << "Player constructor called " <<x<<" : "<<y<<std::endl;
	}
	void print() 
	{
		std::cout << this->x << " : " << this->y << std::endl;
	}
	int getX() const { return x; }
	int getY() const { return y; }
};

//class for static example
class GameManager
{
	private : 
		bool gameStarted = false;
	public :
		static Player Users[3];
		static void showPlayers()
		{
			for (static int i = 0; i < 3; i++)
			{
				Users[i].print();
			}
		}
		//this will not work !!!
		//static functions work only with static members
		static bool IsRunning()
		{
			//return gameStarted;
		}
};

//static members of a class need to be initialized outside or we will get a linker error
Player GameManager::Users[3];

//stuct can have inheritance from a class ?? Lol
//Well... the only difference between a class and a struct is their default FKING MEMBER ACCES
//struct -> public
//class -> private
//lol?
struct Vector3 //: public Player
{
	private :
		float x, y, z;
	public:
		Vector3(float pozX, float pozY, float pozZ)
		{
			x = pozX;
			y = pozY;
			z = pozZ;
		}
		float getX()
		{
			return x;
		}
};

//const 
int adder(const int& a,const int& b) 
{
	//a++; -> can't do that bcs it's a constant 
	//function passed via refrence are much faster than function that uses value 
	return a + b;
}

int main()
{
	//Array don't have bounds , we don't get a out of bound error
#if 0
	int arr[5];
	std::cout << arr[60] << std::endl;
	LOG(adder(2, 5));
	//Objects can be pointers or not
	Player p(4, 3);
	Player *p2 = new Player(3, 2);
	p2->print();
	p.print();
	delete p2;
	//Pointer to a pointer
	char *buffer = new char[8];
	memset(buffer, 0, 8);
	char **ptr = &buffer;
	*(*ptr) = 'A';
	LOG((int)*(*ptr));
	delete[] buffer;
	//structs are the same as class in C++,they just don't have a level protection
	Vector3 position(15.2f, 23.3f, 12.3f);
	LOG(position.getX());
	//extern variables
	LOG(extern_test);
	extern_test = 6;
	LOG(extern_test);
	//static vars
	LOG(test_static);
	//static class
	Player p1(2, 4), p4(6,4),p3(5,2);
	GameManager::Users[0] = p1;
	GameManager::Users[1] = p3;
	GameManager::Users[2] = p4;
	GameManager::showPlayers();
	//singleton using static
	Singleton::Get().Hello();
	//Windows.h keypressing stuff
	//0x30 - 0x39 --> 0-9
	//0x41 - 0x5A --> A-Z
	while (true)
	{
		if (GetAsyncKeyState(0x41))
		{
			std::cout << "Aaaaaaa pressed" << std::endl;
			break;
		}
	}
	Entity e(2, 5);
	Entity *pll = new Player(5, 3);
#endif

	std::
FANCY
