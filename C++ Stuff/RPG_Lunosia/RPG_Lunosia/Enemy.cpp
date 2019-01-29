#include "Enemy.h"

Enemy::Enemy(sf::Texture* texture,sf::Vector2u imgCount, float switchTime, float speed,float damage) :
	enemyAnimation(sf::Vector2u(texture->getSize().x, texture->getSize().y), imgCount, switchTime)
{
	row = 0;
	velocity.x = 0.0f;
	velocity.y = 0.0f;
	movementSpeed = speed;
	Tag = "Enemy";
	destroy = false;
	this->damage = damage;
	stateSwith = Resources().Get().GetRandom(2.8f, 5.5f);
	direction = Resources().Get().GetRandom(0, 4);
	contor = 0.0f;
	body.setSize(sf::Vector2f(65.0f,45.0f));
	body.setOrigin(body.getSize() / 2.0f);
	body.setTexture(texture);
}

void Enemy::MoveEnemy(float deltaTime)
{
	velocity.x = 0.0f;
	velocity.y = 0.0f;
	// Increase our current state contor
	contor += deltaTime;
	if (contor >= stateSwith)
	{
		// The "AI" for enemy
		contor = 0.0f;
		direction = Resources().Get().GetRandom(0, 10);
		stateSwith = Resources().Get().GetRandom(2.2f, 4.5f);
	}
	switch (direction)
	{
		case 0 :
			// UP
			row = 3;
			isIdle = false;
			velocity.y -= movementSpeed;
			break;
		case 1 :
			// DOWN
			row = 0;
			isIdle = false;
			velocity.y += movementSpeed;
			break;
		case 2 :
			// LEFT
			row = 1;
			isIdle = false;
			velocity.x -= movementSpeed;
			break;
		case 3 :
			// RIGHT
			row = 2;
			isIdle = false;
			velocity.x += movementSpeed;
			break;
		default :
			// Random state
			isIdle = true;
			break;
	}
	// Play the animation
	enemyAnimation.PlayAnimation(row, deltaTime, true, isIdle);
	body.setTextureRect(enemyAnimation.getRect());
	body.move(velocity * deltaTime);
}