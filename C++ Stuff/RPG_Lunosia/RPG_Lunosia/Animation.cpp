#include "Animation.h"

Animation::Animation(sf::Vector2u textureDimensions, sf::Vector2u imgCount, float switchTime)
{
	imageCount = imgCount;
	this->switchTime = switchTime;
	totalTime = 0.0f;
	currentImage.x = 0;

	uvRect.width = textureDimensions.x / imageCount.x;
	uvRect.height = textureDimensions.y / imageCount.y;
}