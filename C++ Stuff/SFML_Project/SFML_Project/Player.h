#pragma once
#include <SFML\Graphics.hpp>
#include "Animation.h"
#include "Collider.h"

class Player
{
private:
	sf::RectangleShape body;
	Animation animation;
	unsigned int row;
	float speed;
	bool faceRight;

	bool canJump;
	bool isInAir;
	sf::Vector2f velocity;
	float jumpHeight;

public:
	Player(sf::Texture* texture, sf::Vector2u imageCount,float switchTime,float speed,float jumpHeiht);
	~Player();
	void Update(float deltaTime);
	void Draw(sf::RenderWindow& window);
	void OnCollision(sf::Vector2f direction);
	sf::Vector2f GetPosition() { return body.getPosition(); }
	Collider GetCollider() { return Collider(body); }
	bool IsInAir() { return isInAir; }
	void SetInAir(bool val) { isInAir = val; }
};