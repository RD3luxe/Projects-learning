#pragma once
#include <iostream>
#include "Entity.h"
#include "Animation.h"
#include "Resources.h"
#include <SFML/Graphics.hpp>

class Player : public Entity
{
private:
	unsigned int row = 0;
	Animation playerAnim;
	float health = 200.0f;
	bool isIdle;
public:
	int curDirection;
	float movementSpeed;
	Player(sf::Texture* texture, sf::Vector2u imageCount, float switchTime, float speed);
	void Input(float deltaTime);
	float getHealth() { return health; }
	void dealDamage(float amount) { health -= amount; }
};