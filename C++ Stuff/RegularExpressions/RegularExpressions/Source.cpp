#include<iostream>
#include<string>
#include<regex>
/*
Types of regular expression grammar :
ex : std::regex_constant::grep , ...etc
- ECMAScript -> default
- basic
- extended
- awk
- grep
- egrep
*/
//regex_iterator
//regex_token_iterator
//***** regex expressions , regex_search , regex_match , regex_constant , regex_replace,
//smatch -> for finding the data from each group of our matching string

int main()
{
	//std::string str;
	//while (true)
	//{
	//	std::cin >> str;
	//	std::regex r("abc.",std::regex_constants::icase);// . -> any character after except newline
	//	std::regex r("^abc.");// ^ -> appears at the begining for searching
	//	std::regex r("abc$"); // $ -> appears at the end for searching
	//	std::regex r("abc?"); // ? -> 0 or 1 preceding character
	//	std::regex r("abc*"); // * -> 0 or any number of preceding character
	//	std::regex r("abc+"); // + -> 1 or more preceding character
	//	std::regex r("ab[cd]"); // [....] -> any character from here
	//	std::regex r("ab[^cd]"); // [^..] -> any character that is not here
	//	std::regex r("abc[cd]{3,5}"); // {} -> 3 or more preceding[5 in this case] character
	//	std::regex r("abc|de[\\]fg]"); // | -> or && \\] -> match for square bracket
	//	std::regex r("(abc)c(de+)"); //() -> grouping 
	//	std::regex r("([[:w:]]+)@([[:w:]]+)\\.com"); //[:w:] -> word character : digit , number or _

	//	bool match = std::regex_match(str, r); //is matching the whole string
	//	std::smatch m; //this will store the result of the match
	//	bool match = std::regex_search(str,m,r); //search for a substring and save the results in m
	//	std::cout << "m.size() " << m.size() << std::endl;
	//	m[0] will be the matched string
	//	m[1...size()-1] will be the groups
	//	for (int i = 0; i < m.size(); i++)
	//	{
	//		std::cout << "m[" << i << "]: " << m[i].str() << std::endl;
	//	}
	//	std::cout << "Prefix : " << m.prefix() << std::endl; //this will store what is in front of the matched string
	//	std::cout << "Sufix : " << m.suffix() << std::endl; //this will store what is in the end of the matched string
	//	std::cout << (match ? "Matched" : "Not matched") << std::endl;
	//}

	//*****If we want to search more substring with the same regex patter we need to use a regex iterator or regex_token_iterator
	std::string str = "test@yahoo.com/-   test2@gmail.com,-   test1@hotmail.com;"; //our string with all emails to extract
	std::regex e("([[:w:]]+)@([[:w:]]+)\\.com"); //create our regular expression for an email
	//std::sregex_iterator pos(str.cbegin(), str.cend(), e); //we initialize our iterator
	//std::sregex_iterator end; //default constructor defines past the end iterator -> with this we can check when the iterator it's ended
	//for (; pos != end; pos++)
	//{
	//	std::cout << "Found : " << pos->str(0) << std::endl;
	//	std::cout << "User name : " << pos->str(1) << std::endl;
	//	std::cout << "Domain : " << pos->str(2) << std::endl;
	//	std::cout << std::endl;
	//}

	//sregex_token_iterator
	//std::sregex_token_iterator pos(str.cbegin(), str.cend(), e, 0); 
	//std::sregex_token_iterator end; 
	//0 -> is default parameter for token_iterator and will show the matched string
	//-1 will show the unmatched string 
	//1 ... n will show the string group of the matched string from de regular expression
	//cbegin -> c (constant iterator pointing to the begining)
	//for (; pos != end; pos++)
	//{
	//	std::cout <<"Found : "<< pos->str() << std::endl; //this will show only one result based on what parameter we used in the token_iterator
	//}
	
	//regex replace -> it will replace all the matched string with another string
	std::cout << std::regex_replace(str, e, "$1 use $2\n", std::regex_constants::format_no_copy);
	//std::regex_constants::format_no_copy  -> will not copy the chars that are not a match 
	//std::regex_constants::format_first_only -> will show only the first result
	system("Pause");
	return 0;
}