#include <iostream>
#include <thread>
#include <string>
#include <future> //lul
#include <mutex>

#define EXAMPLE_NUM 5 //I count from 0, btw

#if EXAMPLE_NUM == 0
#pragma region FIRST_EXAMPLE - SIMPLE THREAD PROGRAM
//first child thread 
void printConsole()
{
	std::cout << "I'm child " << std::this_thread::get_id() << std::endl;
}

//main thread -> main function
int main()
{
	std::thread childThread(printConsole);
	//now do sth with main too
	std::cout << "I'm main " << std::this_thread::get_id() << " and my child has id : " << childThread.get_id() << std::endl;
	//if we detach from the main thread then we can't call join
	childThread.detach();
	//check if we can join
	if (childThread.joinable())
		//join the thread don't abouse your child
		childThread.join();

	//this return how many threads we can use
	std::cout << std::thread::hardware_concurrency() << std::endl;
	system("Pause");
	return 0;
}
#pragma endregion
#endif

#if EXAMPLE_NUM == 1
#pragma region SECOND_EXAMPLE - MUTEX && LOCK GUARD

//create a mutex
std::mutex _mu;

//function used for threads
void printConsole(std::string whois)
{
	//lock the ofstream buffer , let 1 thread use it a time
	std::lock_guard<std::mutex> guard(_mu);
	std::cout << "I'm "<< whois <<" " << std::this_thread::get_id() << std::endl;
}

//main thread -> main function
int main()
{
	//create a string and call the thread
	std::string me = "child";
	std::thread childThread(printConsole,me);
	//now do sth with main too
	me = "main";
	printConsole(me);
	childThread.join();
	system("Pause");
	return 0;
}
#pragma endregion
#endif

#if EXAMPLE_NUM == 2
#pragma region THIRD_EXAMPLE - unique_lock && usuage of a class used by 2 threads + once_flag

#include <stack>

//safe stack class used for threads
class safe_stack
{
private:
	//stack of integers
	std::stack<int> st;
	//mutex used to check the lock a function until that thread that is using it is done
	std::mutex _mu;
	std::once_flag _flag;
public:
	//constructor used to initialize the stack
	safe_stack(int nr)
	{
		for (int i = 1; i <= nr; i++)
		{
			st.push(i);
		}
	}
	//safe pop function
	void s_pop(std::string t_name)
	{
		//lock the mutex and don't let another thread to use this until the current thread is done
		//unique lock is better than lock_guard bcs we can move it , lock/unlock it when we want , but it is using more resurses
		std::unique_lock<std::mutex> guard(_mu);
		//if the stack is empty return
		if (IsEmpty())
			return;
		auto thread_ID = std::this_thread::get_id();
		//call once method , this will be called one time by the first thread
		std::call_once(_flag, [&]() { std::cout << "Called once by " << thread_ID << std::endl; });
		int top = st.top();
		st.pop();
		std::cout << t_name << " id "<<thread_ID<<" popped "<<top<< std::endl;
	}
	//check if the stack is empty
	bool IsEmpty()
	{
		return st.size() == 0;
	}
};

//child thread function
void sstack(safe_stack& st,const std::string& na)
{
	//while the stack is not empty pop items from it
	while(!st.IsEmpty())
		st.s_pop(na);
}

//main
int main()
{
	safe_stack stac(37);
	std::string name = "Child";
	std::thread child(sstack,std::ref(stac), name);
	//do with main too
	//main function can still use the child thread funtion
	name = "Main";
	sstack(stac, name);
	child.join();
	system("Pause");
	return 0;
}
#pragma endregion
#endif

#if EXAMPLE_NUM == 3
#pragma region Region condition_variable and relationship between 2 threads

#include <random>
#include <chrono>
#include <deque>

class Funct
{
private:
	//create a mutex
	std::mutex _mu;
	//create a condition variable
	std::condition_variable cond;
	//a deque with stuff
	std::deque<int> stuff;
	//max numbers , count is not syncronized with the threads so the process won't terminate
	int count = 10;
	//method for random num (hard to remember but it's quite good)
	int generateRandom(int minRange, int maxRange)
	{
		auto seed = std::chrono::system_clock::now().time_since_epoch().count();
		std::default_random_engine generator((unsigned)seed);
		std::uniform_int_distribution<int> distribution(minRange, maxRange);
		return distribution(generator);
	}
public:
	//method to add numbers to deque used by main thread
	void addNumbers()
	{
		while (count > 0)
		{
			//lock the thread
			std::unique_lock<std::mutex> guard(_mu);
			//generate a random number everytime
			int num = generateRandom(10, 99);
			//push element
			stuff.push_front(num);
			//unlock it
			guard.unlock();
			//notify other thread that about this		
			cond.notify_one();
			//sleep for 1 second
			std::this_thread::sleep_for(std::chrono::seconds(1));
			//decrease the count
			count--;
		}
	}

	//method to print numbers from it used by child thread
	void print()
	{
		//async problems here that's why I compare count with 1
		while (count != 1)
		{
			//lock the thread
			std::unique_lock<std::mutex> locker(_mu);
			//wait and if the condition is meet wake the thread
			//or just wait to be notify
			cond.wait(locker, [&]() { return !stuff.empty(); }); //spurious wake
			//get data from deque
			int data = stuff.back();
			//pop back the data
			stuff.pop_back();
			//unlock the locker
			locker.unlock();
			//print message
			std::cout << "T2 got " << data << " from t1 " << std::endl;
		}
	}
};

//function runned by thread 1
void thread1(Funct &f)
{
	f.addNumbers();
}

//function runned by thread 2
void thread2(Funct &f)
{
	f.print();
}

int main()
{
	Funct f;
	std::thread childThread(thread1, std::ref(f));
	std::thread childThread2(thread2, std::ref(f));
	childThread.join();
	childThread2.join();
	system("Pause");
	return 0;
}
#pragma endregion
#endif

#if EXAMPLE_NUM == 4
#pragma region future,promise && async
#include<chrono>

//function used for child thread (simple factorial function)
int fact(std::future<int>& f)
{
	//promise our function that he will get this var in the future
	int N = f.get();
	std::cout << "The child thread got the promise " << N << std::endl;
	int rez = 1;
	for (int i = N; i > 1; i--)
	{
		rez *= i;
	}
	return rez;
}

int main()
{
	//the returned var
	int x;
	//declare a promise
	std::promise<int> p;
	//declare a future and promise 
	std::future<int> f = p.get_future();
	//create a async variable which will return a future var (our variable from the child thread)
	std::future<int> fu = std::async(std::launch::async, fact, std::ref(f));
	//sleep for 20 ms
	std::this_thread::sleep_for(std::chrono::milliseconds(20));
	//keep our promise and send the variable to the child thread
	p.set_value(4);
	//exception
	p.set_exception(std::make_exception_ptr(std::runtime_error("Promise broken")));
	//get the result from the child thread
	x = fu.get();
	//print it
	std::cout <<"The main thread got the result from the child thread "<< x << std::endl;
	system("PAUSE");
	return 0;
}
#pragma endregion
#endif

#if EXAMPLE_NUM == 5
#pragma region shared_future
#include<chrono>

//function used for child thread (simple factorial function)
int fact(std::shared_future<int> f)
{
	//promise our function that he will get this var in the future
	int N = f.get();
	std::cout << "The child thread got the promise " << N << std::endl;
	int rez = 1;
	for (int i = N; i > 1; i--)
	{
		rez *= i;
	}
	return rez;
}

int main()
{
	int x[3];
	std::promise<int> p;
	std::future<int> f = p.get_future();
	std::shared_future<int> sf = f.share();
	//create 3 different async threads
	std::future<int> fu1 = std::async(std::launch::async, fact, sf);
	std::future<int> fu2 = std::async(std::launch::async, fact, sf);
	std::future<int> fu3 = std::async(std::launch::async, fact, sf);
	//this will set the val for all threads
	p.set_value(3);
	//get all the vars
	x[0] = fu1.get() + 1;
	x[1] = fu2.get() + 2;
	x[2] = fu3.get() + 3;
	//print them
	for (int i = 0; i < 3; i++)
	{
		std::cout << "The main thread got the result from the child thread "<<i<<" "<< x[i] << std::endl;
	}
	system("PAUSE");
	return 0;
}
#pragma endregion
#endif

#if EXAMPLE_NUM == 6
#pragma region packaged task
#include<chrono>

//function used for child thread (simple factorial function)
int sleep()
{
	std::this_thread::sleep_for(std::chrono::seconds(3));
	return 13;
}

int main()
{
	//create a packaged task 
	std::packaged_task<int()> pt(sleep);
	//create a future and get the var in the future
	std::future<int> fu = pt.get_future();
	//print a message
	std::cout << "You need to wait 3 seconds." << std::endl;
	//call the packaged task who is binded to a function that will wait 3 seconds
	pt();
	//show the message and a number from that function using the future
	std::cout << "Thread can be used " <<fu.get()<< std::endl;
	system("PAUSE");
	return 0;
}
#pragma endregion
#endif