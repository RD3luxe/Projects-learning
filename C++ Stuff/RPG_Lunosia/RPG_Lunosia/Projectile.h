#pragma once
#include "Entity.h"
#include "Animation.h"
#include "Player.h"

class Projectile : public Entity
{
private: 
	Animation projectileAnimation;
	float totalTime;
	float movementSpeed;
	float damage;
public:
	bool destroy = false;
	int projectileDirection;
	Projectile(sf::Texture* texture,sf::Vector2u imageCount,float switchTime,float speed,float damage);
	void MoveProjectile(float deltaTime);
};