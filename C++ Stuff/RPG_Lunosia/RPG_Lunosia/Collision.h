#pragma once
#include "SFML/Graphics.hpp"
#include "Entity.h"

class Collision
{
public:
	// Collision for walls
	void WallCollision(Entity& otherL, Entity& other);
	// Timer for collision
	float collisionTimer = 0.0f;
	// Timer to collide again
	float collideAgain = 3.2f;
	// Check for collisions
	int IsColliding(Entity col1,Entity col2);
	// Singletone method
	static Collision& Get()
	{
		static Collision singleton;
		return singleton;
	}
};