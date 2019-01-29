#include "Tile.h"

Tile::Tile(sf::Texture* texture,sf::Vector2f pos)
{
	tilesMax.x = 10;
	tilesMax.y = 5;
	Tag = "Tile";
	currentTileDirection = 0;

	uvRect.width = texture->getSize().x / tilesMax.x;
	uvRect.height = texture->getSize().y / tilesMax.y;

	body.setSize(sf::Vector2f(32.0f, 32.0f));
	body.setOrigin(body.getSize() / 2.0f);
	body.setPosition(pos.x,pos.y);
	body.setTexture(texture);
}

void Tile::SetTile(sf::Vector2u tilePosition,bool isWalkable)
{
	isWall = isWalkable;
	uvRect.left = tilePosition.x * uvRect.width;
	uvRect.top = tilePosition.y * uvRect.height;
	body.setTextureRect(uvRect);
}