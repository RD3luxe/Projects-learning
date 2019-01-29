#pragma once
#include <SFML/Graphics.hpp>
#include <string>

class Entity
{
protected:
	sf::RectangleShape body;
	sf::Text text;
	std::string Tag;
	bool isColliding = false;
public:
	// Create a velocity variable
	sf::Vector2f velocity;
	bool isWall;
	void Draw(sf::RenderWindow& window);
	sf::Vector2f GetPosition() { return body.getPosition(); }
	sf::RectangleShape &GetBody() { return body; }
	std::string GetTag() { return Tag; }
	void setCollider(bool val) { isColliding = val; }
	bool getCollider() { return isColliding; }
};