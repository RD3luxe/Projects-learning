#pragma once
#include "Entitys.h"
#include <Windows.h>

//singleton class
class GameManager
{
public:
	int score = 0;
	int bounds[2];
	enum keys { NONE = 0x00, UP = 0x57, DOWN = 0x53, LEFT = 0x41, RIGHT = 0x44 };
	keys input;
private:
	keys GetInput();
	bool gameStarted = false;
	void AddBorder();
	int fruitPos[2];
	char FruitModel = (char)254; //ascii code for a square
	void boundCheckFruit(Obstacle &fruit);
	int generateRandom(int limit);
	void hideCursor();
	void generateConsoleColor();
public:
	static GameManager& Get()
	{
		static GameManager manager;
		return manager;
	}
	void InitGame(const int& gH, const int& gL);
	void CheckCollision(Player& pl,std::vector<Obstacle>& obj);
	bool IsGameRunning() const;
	void SetInput(Player& pl);
	void AddWalkable();
	void showScore();
	//template function used to draw the grid
	template<int HEIGHT, int LENGTH>
	void DrawGrid(Player& pl,std::vector<Obstacle> obs)
	{
		if (!gameStarted)
			return;

		int i, j;
		bool found = false;
		unsigned int contorObs = 0;
		system("cls");
		Obstacle fruit(FruitModel, fruitPos[0], fruitPos[1]);
		fruit.SetType(fruit.EAT);
		boundCheckFruit(fruit);
		for (i = 0; i <= HEIGHT; i++)
		{
			found = false;
			for (j = 0; j <= LENGTH; j++)
			{
				if (i == pl.GetX() && j == pl.GetY() && fruit.GetX() == i && fruit.GetY() == j)
				{
					score++;
					pl.playerTrail.push_back({ 'o',fruitPos[0],fruitPos[1] });
					fruitPos[0] = generateRandom(HEIGHT);
					fruitPos[1] = generateRandom(LENGTH);
					fruit.SetPositions(fruitPos[0], fruitPos[1]);
					boundCheckFruit(fruit);
					generateConsoleColor();
					found = true;
				}
				if (i == pl.GetX() && j == pl.GetY())
				{
					pl.printEntity();
					found = true;
				}
				if (pl.playerTrail.size() > 0)
				{
					for (Obstacle trailCell : pl.playerTrail)
					{
						if (i == trailCell.GetX() && j == trailCell.GetY())
						{
							trailCell.printEntity();
							found = true;
						}
					}
				}
				if (contorObs < obs.size() && !found)
				{
					if (i == obs[contorObs].GetX() && j == obs[contorObs].GetY())
					{
						obs[contorObs].printEntity();
						contorObs++;
						found = true;
					}
				}
				if (fruit.GetX() == i && fruit.GetY() == j)
				{
					fruit.printEntity();
					found = true;
				}
				if (!found)
				{
					std::cout << " ";
				}
				found = false;
			}
			std::cout <<std::endl;
		}
	}
};