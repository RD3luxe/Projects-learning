#include "Platform.h"

Platform::Platform(sf::Texture* texture, sf::Vector2f size, sf::Vector2f position)
{
	platform.setSize(size);
	platform.setOrigin(size / 2.0f);
	platform.setTexture(texture);
	platform.setPosition(position);
}

void Platform::Draw(sf::RenderWindow& window)
{
	window.draw(platform);
}

Platform::~Platform()
{
}