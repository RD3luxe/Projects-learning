#include "Player.h"
#define GRAVITY 981.0f // 9.81 * 100(units on game)

Player::Player(sf::Texture* texture, sf::Vector2u imageCount, float switchTime, float speed,float jumpHeiht)
	: animation(texture,imageCount,switchTime)
{
	this->speed = speed;
	canJump = false;
	isInAir = true;
	row = 0;
	faceRight = true;
	this->jumpHeight = jumpHeiht;

	body.setSize(sf::Vector2f(60.5f, 100.5f));
	body.setOrigin(body.getSize() / 2.0f);
	body.setPosition(1.0f, 1.0f);
	body.setTexture(texture);
}

Player::~Player()
{
}

void Player::Update(float deltaTime)
{
	velocity.x = 0.0f;

	if (sf::Keyboard::isKeyPressed(sf::Keyboard::A))
		velocity.x -= speed;
	
	if (sf::Keyboard::isKeyPressed(sf::Keyboard::D))
		velocity.x += speed;

	if (sf::Keyboard::isKeyPressed(sf::Keyboard::W) && canJump && !isInAir)
	{
		canJump = false;
		isInAir = true;
		row = 2;
		//square root(2.0f * gravity * jumpHeight)
		velocity.y = -sqrtf(2.0f * GRAVITY * jumpHeight);
	}

	//gravity
	if(!canJump || isInAir)
		velocity.y += GRAVITY * deltaTime;

	if (velocity.x == 0.0f)
	{
		if (isInAir || !canJump)
			row = 2;
		else
			row = 0;
	}
	else
	{
		if (isInAir || !canJump)
			row = 2;
		else
			row = 1;
		if (velocity.x > 0.0f)
			faceRight = true;
		else
			faceRight = false;
	}
	animation.Update(row, deltaTime, faceRight);
	body.setTextureRect(animation.uvRect);
	body.move(velocity * deltaTime);
}

void Player::Draw(sf::RenderWindow& window)
{
	window.draw(body);
}

void Player::OnCollision(sf::Vector2f direction)
{
	if (direction.x < 0.0f)
	{
		//collision on the left
		velocity.x = 0.0f;
	}
	else if (direction.x > 0.0f)
	{
		//collision on the right
		velocity.x = 0.0f;
	}
	if (direction.y < 0.0f)
	{
		//collision on the bottom
		velocity.y = 0.0f;
		canJump = true;
		isInAir = false;
	}
	else if(direction.y > 0.0f)
	{
		//collision on the top
		velocity.y = 0.0f;
	}
}
