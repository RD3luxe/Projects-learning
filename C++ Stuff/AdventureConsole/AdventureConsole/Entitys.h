#pragma once
#include <iostream>
#include <string>
#include <vector>

/* Quick Logging System */
#define DEBUG 0
#if DEBUG
#define LOG(x) std::cout<<"DEBUG : "<<x<<std::endl
#else
#define LOG(x)
#endif

//base class for all entitys
class Entity
{
protected:
	char model;
	int xCoord, yCoord;
public:
	Entity();
	Entity(char model, int x, int y);
    virtual ~Entity();
	virtual void Move(int xAmount, int yAmount);
	void printEntity();
	const bool operator==(const Entity& obj) const;
	const int GetX() const;
	const int GetY() const;
	const char GetModel() const;
	void SetModel(char mdl) { model = mdl; }
};

//subclass of entity -> obstacle
class Obstacle : public Entity
{
public:
	static std::vector<Obstacle> obstacleList;
	enum obsType { WALKABLE = 2, KILLING = 3 , EAT };
	Obstacle(char model, int pozX, int pozY);
private:
	obsType type;
public:
	obsType GetType() const;
	void SetType(obsType tp) { type = tp; }
	void SetPositions(int x, int y)
	{
		xCoord = x;
		yCoord = y;
	}
};

//subclass of entity -> player
class Player : public Entity
{
public:
	std::vector<Obstacle> playerTrail;
	Player(char model, int pozX, int pozY);
	void SetPositions(int x, int y)
	{
		xCoord = x;
		yCoord = y;
	}
};