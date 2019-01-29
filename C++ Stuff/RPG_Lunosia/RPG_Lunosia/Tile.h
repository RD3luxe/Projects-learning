#pragma once
#include "Entity.h"
#include <SFML/Graphics.hpp>

class Tile : public Entity
{
private:
	sf::IntRect uvRect;
	sf::Vector2u tilesMax;
public:
	// 0 -> UP, 1 -> DOWN, 2 -> LEFT, 3 -> RIGHT
	int currentTileDirection; 
	Tile(sf::Texture* texture, sf::Vector2f pos);
	void SetTile(sf::Vector2u tilePosition, bool isWalkable);
	sf::IntRect &getRect() { return uvRect; }
};