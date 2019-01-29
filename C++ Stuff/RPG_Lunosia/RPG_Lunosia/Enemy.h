#pragma once
#include <SFML/Graphics.hpp>
#include <iostream>
#include "Animation.h"
#include "Entity.h"
#include "Resources.h"

class Enemy : public Entity
{
public:
	bool destroy;
	Enemy(sf::Texture* texture, sf::Vector2u imgCount, float switchTime, float speed,float damage);
	void MoveEnemy(float deltaTime);
	float getDamage() { return damage; }
private:
	int row;
	int direction;
	bool isIdle = false;
	Animation enemyAnimation;
	float movementSpeed;
	float contor = 0.0f;
	float stateSwith;
	float damage;
};