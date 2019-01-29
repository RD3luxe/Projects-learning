#pragma once
#include <SFML/Graphics.hpp>

class Animation
{
private:
	sf::IntRect uvRect;
	sf::Vector2u imageCount;
	sf::Vector2u currentImage;
	float totalTime, switchTime;
public:
	Animation(sf::Vector2u textureDimensions, sf::Vector2u imgCount, float switchTime);
	sf::IntRect& getRect() { return uvRect; }
	void PlayAnimation(int row, float deltaTime, bool repeat = false,bool idle = false)
	{
		// Set the current sprite to play
		currentImage.y = row;
		totalTime += deltaTime;
		// Check if the total time is bigger than switch time (for the animation)
		if (totalTime >= switchTime)
		{
			// Decrease the total time
			totalTime -= switchTime;
			// Play the next sprite on the x axis
			currentImage.x++;
			// Don't let the current image to be bigger that our sprite sheet
			if (currentImage.x >= imageCount.x && repeat)
			{
				// Reset it to 0
				currentImage.x = 0;
			}
			else if (currentImage.x >= imageCount.x && !repeat)
			{
				// Set to an previous sprite
				currentImage.x = 3;
			}
			// Set the idle image
			if (idle)
			{
				currentImage.x = 1;
			}
		}
		// Set our uvRect to match the current image
		uvRect.top = currentImage.y * uvRect.height;
		uvRect.left = currentImage.x * uvRect.width;
	}
};