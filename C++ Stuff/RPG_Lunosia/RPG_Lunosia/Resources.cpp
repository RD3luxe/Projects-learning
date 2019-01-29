#include "Resources.h"

// Some utility methods
void Resources::InitCamera(sf::Vector2f plPos)
{
	view.setCenter(plPos);
	view.setSize(sf::Vector2f(VIEW_WEIGHT, VIEW_HEIGHT));
}

void Resources::ResizeView(sf::RenderWindow& window)
{
	float aspectRatio = (float)window.getSize().x / (float)window.getSize().y;
	view.setSize(VIEW_HEIGHT * aspectRatio, VIEW_HEIGHT);
}

void Resources::SetIcon(sf::RenderWindow& window)
{
	sf::Image icon;
	if (!icon.loadFromFile(SpritesPath + iconSprite))
	{
		return;
	}
	window.setIcon(icon.getSize().x, icon.getSize().y, icon.getPixelsPtr());
}

int Resources::GetRandom(int rangeA, int rangeB)
{
	auto seed = std::chrono::steady_clock::now().time_since_epoch().count();
	std::default_random_engine engine((unsigned)seed);
	std::uniform_int_distribution<int> distribution(rangeA,rangeB);
	return distribution(engine);
}

float Resources::GetRandom(float rangeA, float rangeB)
{
	auto seed = std::chrono::steady_clock::now().time_since_epoch().count();
	std::default_random_engine engine((unsigned)seed);
	std::uniform_real_distribution<float> distribution(rangeA, rangeB);
	return distribution(engine);
}