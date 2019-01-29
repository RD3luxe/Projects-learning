#include "Projectile.h"

Projectile::Projectile(sf::Texture* texture, sf::Vector2u imageCount, float switchTime, float speed, float damage) :
	projectileAnimation(sf::Vector2u(texture->getSize().x, texture->getSize().y),imageCount,switchTime)
{
	movementSpeed = speed;
	this->damage = damage;
	Tag = "Bullet";
	totalTime = 0;

	body.setSize(sf::Vector2f(35.0f,30.0f));
	body.setOrigin(body.getSize() / 2.0f);
	body.setPosition(0.0f,0.0f);
	body.setTexture(texture);
}

void Projectile::MoveProjectile(float deltaTime)
{
	sf::Vector2f velocity;
	totalTime += deltaTime;
	if (totalTime >= 2.0f)
	{
		totalTime = 0;
		destroy = true;
		return;
	}
	// Get the direction for projectiles
	switch (projectileDirection)
	{
		case 0 :
			body.rotate(body.getRotation() + 90);
			velocity.y -= movementSpeed;
			break;
		case 1 :
			body.rotate(body.getRotation() - 90);
			velocity.y += movementSpeed;
			break;
		case 2 :
			body.rotate(body.getRotation() + 180);
			velocity.x -= movementSpeed;
			break;
		case 3 :
			//default rotation
			body.rotate(body.getRotation());
			velocity.x = movementSpeed;
			break;
		default:
			break;
	}
	// Play the animation
	projectileAnimation.PlayAnimation(0, deltaTime);
	body.setTextureRect(projectileAnimation.getRect());
	body.move(velocity * deltaTime);
}