#include "Entitys.h"
#include "GameManager.h"

//empty default constructor
Entity::Entity()
{
}

//constructor using list of initilizers
Entity::Entity(char Skin, int xPoz, int yPoz)
	: model(Skin), xCoord(xPoz), yCoord(yPoz)

{
	LOG("Entity created");
}

//print entity
void Entity::printEntity()
{
	std::cout << this->model;
}

//destructor 
Entity::~Entity() 
{
	xCoord = 0;
	yCoord = 0;
	LOG("Entity cleared ");
}

//get function for protected members
const int Entity::GetX() const
{
	return xCoord;
}

//for ycoord
const int Entity::GetY() const
{
	return yCoord;
}

//for model
const char Entity::GetModel() const
{
	return model;
}

//move function , made it virtual
void Entity::Move(int xAmount, int yAmount)
{
	xCoord += xAmount;
	yCoord += yAmount;
}

//overload == operator for every entity
const bool Entity::operator==(const Entity& obj) const
{
	return this->xCoord == obj.xCoord && this->yCoord == obj.yCoord;
}

/* Functions for player class */
Player::Player(char model, int pozX, int pozY)
{
	//bound checking for overflow
	if (pozX >= GameManager::Get().bounds[0])
	{
		pozX = GameManager::Get().bounds[0] - 1;
	}
	if (pozY >= GameManager::Get().bounds[1])
	{
		pozY = GameManager::Get().bounds[1] - 1;
	}
	//bound checking for underflow
	if (pozX <= 0)
	{
		pozX = 1;
	}
	if (pozY <= 0)
	{
		pozY = 1;
	}
	this->model = model;
	this->xCoord = pozX;
	this->yCoord = pozY;
	LOG("Player created");
}

/* Functions for obstacle class*/
std::vector<Obstacle> Obstacle::obstacleList;

Obstacle::Obstacle(char model, int pozX, int pozY) 
	: Entity(model, pozX, pozY)
{
	//set killing type as default
	type = KILLING;
}

//get the type of obstacle
Obstacle::obsType Obstacle::GetType() const
{
	return type;
}