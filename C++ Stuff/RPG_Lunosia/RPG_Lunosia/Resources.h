#pragma once
#include <string>
#include <random>
#include <chrono>
#include <vector>
#include "SFML/Graphics.hpp"

class Resources
{
public:
	// Stuff for resurces 
	const std::string SpritesPath = "Art/";
	const std::string AudioPath = "Audio/";
	
	// Music management, sprite management
	const std::string iconSprite = "icon.png";
	const std::string playerSprite = "rpg_player.png";
	const std::string projectile1 = "projectile_1.png";
	const std::string enemiesName[3] = { "enemy_1.png" , "enemy_2.png", "enemy_3.png" };
	const std::string tiles = "tiles.png";
	const float VIEW_WEIGHT = 1000.0f;
	const float VIEW_HEIGHT = 600.0f;
	sf::Vector2f Coordonates = { 270.0f,200.0f };

	// Game mechanics management
	// Enemy Spawner
	float m_timerSpawnEnemies = 0.0f;
	float timeSpawn = 2.0f;
	unsigned int maxEnemy = 100;
	int maxEnemyType = 3;

	// Delete the copy constructor & assign operator bcs we use this as an singletone class
	Resources(const Resources& res) = delete;
	void operator=(const Resources& rightRes) = delete;

	// Constructor
	Resources() = default;
	// The Get Singletone method
	static Resources& Get()
	{
		static Resources singletone;
		return singletone;
	}
	// Create a view for that rpg feel
	sf::View view;
	// Initialize the view
	void InitCamera(sf::Vector2f plPos);
	// Resize window bug , solved
	void ResizeView(sf::RenderWindow& window);
	// Initialize the icon window
	void SetIcon(sf::RenderWindow& window);
	// Random int and float method
	int GetRandom(int RangeA, int RangeB);
	float GetRandom(float rangeA, float rangeB);
};