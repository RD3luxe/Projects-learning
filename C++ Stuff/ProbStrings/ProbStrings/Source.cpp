#include<iostream>
#include<string>
#include<stack>

bool evaluateExp(const std::string& exp)
{
	std::stack<char> paranthesis;
	for (char c : exp)
	{
		switch (c)
		{
			//add every left paranthesis
			case '[' :
			case '(' :
			case '{' :
				paranthesis.push(c);
				break;
			//check for the right paranthesis
			case '}' :
				if (!paranthesis.empty() )
				{
					char top = paranthesis.top();
					if (top == '{')
						paranthesis.pop();
					else
						return false;
				}
				else
				{
					return false;
				}
				break;
			case ')' :
				if (!paranthesis.empty())
				{
					char top = paranthesis.top();
					if (top == '(')
						paranthesis.pop();
					else
						return false;
				}
				else
				{
					return false;
				}
				break;
			case ']' :
				if (!paranthesis.empty())
				{
					char top = paranthesis.top();
					if (top == '[')
						paranthesis.pop();
					else
						return false;
				}
				else
				{
					return false;
				}
				break;
			default:
				return false;
				break;
		}
	}
	return true;
}

int main()
{
	std::string exp;
	std::cin >> exp;
	std::cout << (evaluateExp(exp) == 1 ? "true":"false")<< std::endl;
	system("pause");
	return 0;
}