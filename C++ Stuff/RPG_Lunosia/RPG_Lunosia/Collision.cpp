#include "Collision.h"

// 1 -> collision with player and enemy
// 2 -> collision with bullet and enemy
int Collision::IsColliding(Entity col1,Entity col2)
{
	// Check for collision bounds
	if (col1.GetBody().getGlobalBounds().intersects(col2.GetBody().getGlobalBounds()))
	{
		// Collision for player and enemy
		if (col1.GetTag() == "Player" && col2.GetTag() == "Enemy" || col2.GetTag() == "Player" && col1.GetTag() == "Enemy")
		{
			return 1;
		}
		// Collison for bullet and enemy
		if (col1.GetTag() == "Bullet" && col2.GetTag() == "Enemy" || col2.GetTag() == "Bullet" && col1.GetTag() == "Enemy")
		{
			return 2;
		}
	}
	// Return no collision
	return 0;
}