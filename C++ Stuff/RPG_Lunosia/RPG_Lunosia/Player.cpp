#include "Player.h"

Player::Player(sf::Texture* texture, sf::Vector2u imageCount, float switchTime, float speed)
	: playerAnim(sf::Vector2u(texture->getSize().x, texture->getSize().y), imageCount, switchTime)
{
	movementSpeed = speed;
	isIdle = true;
	row = 0;
	curDirection = 1;
	Tag = "Player";
	health = 200.0f;
	velocity.x = 0.0f;
	velocity.y = 0.0f;

	// Set the body of the player
	body.setSize(sf::Vector2f(32.0f,32.0f));
	body.setOrigin(body.getSize() / 2.0f);
	body.setPosition(400.0f, 200.0f);
	body.setTexture(texture);
	std::cout << "Player created" << std::endl;
}

void Player::Input(float deltaTime)
{
	// reset velocity
	velocity.x = 0.0f;
	velocity.y = 0.0f;
	// Set idle animation
	if (velocity.x == 0.0f || velocity.y == 0.0f)
	{
		isIdle = true;
	}
	// Check the player input and set the animation row
	if (sf::Keyboard::isKeyPressed(sf::Keyboard::W))
	{
		velocity.y = -movementSpeed;
		curDirection = 0;
		isIdle = false;
		row = 3;
	}
	else if (sf::Keyboard::isKeyPressed(sf::Keyboard::S))
	{
		velocity.y = movementSpeed;
		curDirection = 1;
		isIdle = false;
		row = 0;
	}
	else if (sf::Keyboard::isKeyPressed(sf::Keyboard::A))
	{
		velocity.x = -movementSpeed;
		curDirection = 2;
		isIdle = false;
		row = 1;
	}
	else if (sf::Keyboard::isKeyPressed(sf::Keyboard::D))
	{
		velocity.x = movementSpeed;
		curDirection = 3;
		isIdle = false;
		row = 2;
	}
	// Play the animation for the current movement
	playerAnim.PlayAnimation(row,deltaTime,true,isIdle);
	// Set the current rectangle for that animation
	body.setTextureRect(playerAnim.getRect());
	// Move the body
	body.move(velocity * deltaTime);
}