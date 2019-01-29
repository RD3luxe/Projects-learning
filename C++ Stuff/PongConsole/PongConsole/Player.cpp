#include "Player.h"

Player::Player()
{
}

Player::~Player()
{
}

void Player::addScore()
{
	this->m_score++;
}

void Player::draw(std::ostream& out)
{
	out << m_model;
}