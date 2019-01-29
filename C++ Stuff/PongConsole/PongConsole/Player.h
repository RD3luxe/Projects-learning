#pragma once
#include <iostream>

class Player
{
public:
	Player();
	~Player();
	void addScore();
	void draw(std::ostream& buf);
private:
	const char m_model = '|'; // ASCII code
	int m_score = 0;
};