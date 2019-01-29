#include "GameManager.h"
#include <random>
#include <chrono>

//initialize the game
void GameManager::InitGame(const int& gH,const int& gL)
{
	generateConsoleColor();
	hideCursor();
	bounds[0] = gH;
	bounds[1] = gL;
	fruitPos[0] = generateRandom(gH);
	fruitPos[1] = generateRandom(gL);
	AddBorder();
	gameStarted = true;
}

//generate console color
void GameManager::generateConsoleColor()
{
	char colorNr[2];
	int random_color = generateRandom(9);
	_itoa_s(random_color, colorNr, 10);
	char* command = new char[10];
	strcpy_s(command, 10, "color ");
	strcat_s(command, 10, colorNr);
	//or just system(command.c_str()); and use command as a string , meh
	system(command);
	//clear memory
	delete command;
}

//create the border of the map with the obstacles
void GameManager::AddBorder()
{
	char defaultGridModel = (char)178;
	for (int i = 0; i <= bounds[0]; i++)
	{
		for (int j = 0; j <= bounds[1]; j++)
		{
			if (i == 0 || i == bounds[0] || j == 0 || j == bounds[1])
			{
				Obstacle::obstacleList.push_back({ defaultGridModel,i,j });
			}
		}
	}
}

//generate random number
int GameManager::generateRandom(int limit)
{
	auto seed = std::chrono::system_clock::now().time_since_epoch().count();
	std::default_random_engine generator((unsigned int)seed);
	std::uniform_int_distribution<int> distribution(1, limit-1);
	return distribution(generator);
}

//check if the player is colliding with an obstacle or his tail
void GameManager::CheckCollision(Player& pl ,std::vector<Obstacle>& obj)
{
	//obstacle collision
	for (Obstacle o : obj)
	{
		if (o.GetX() == pl.GetX() && o.GetY() == pl.GetY())
		{
			switch (o.GetType())
			{
			case o.KILLING:
				//call game over here
				gameStarted = false;
				system("cls");
				break;
			case o.WALKABLE:
				//move the player in the opposite direction
				switch (input)
				{
					case GameManager::UP:
						pl.SetPositions(GameManager::Get().bounds[0] - 1, pl.GetY());
						break;
					case GameManager::DOWN:
						pl.SetPositions(1, pl.GetY());
						break;
					case GameManager::LEFT:
						pl.SetPositions(pl.GetX(), GameManager::Get().bounds[1] - 1);
						break;
					case GameManager::RIGHT:
						pl.SetPositions(pl.GetX(),1);
						break;
					default:
						break;
				}
				break;
			}
		}
	}
	//trail collision
	for (Obstacle t : pl.playerTrail)
	{
		if (pl.GetX() == t.GetX() && pl.GetY() == t.GetY())
		{
			//game over
			gameStarted = false;
			system("cls");
		}
	}
}

//check fruit positions
void GameManager::boundCheckFruit(Obstacle &fruit)
{
	//bound checking
	if (fruit.GetX() >= bounds[0] || fruit.GetY() >= bounds[1] 
		|| fruit.GetX() <= 0 || fruit.GetY() <= 0)
	{
		fruitPos[0] = generateRandom(bounds[0]);
		fruitPos[1] = generateRandom(bounds[1]);
		fruit.SetPositions(fruitPos[0], fruitPos[1]);
	}
}

//player input manager
GameManager::keys GameManager::GetInput()
{
	keys input = NONE;
	if (GetAsyncKeyState(UP))
	{
		input = UP;
	}
	else if (GetAsyncKeyState(DOWN))
	{
		input = DOWN;
	}
	else if (GetAsyncKeyState(LEFT))
	{
		input = LEFT;
	}
	else if (GetAsyncKeyState(RIGHT))
	{
		input = RIGHT;
	}
	return input;
}

//move the player
void GameManager::SetInput(Player& pl)
{
	input = GetInput();
	switch (input)
	{
	case GameManager::UP:
		pl.Move(-1, 0);
		break;
	case GameManager::DOWN:
		pl.Move(1, 0);
		break;
	case GameManager::LEFT:
		pl.Move(0, -1);
		break;
	case GameManager::RIGHT:
		pl.Move(0, 1);
		break;
	default:
		break;
	}
}

//show Score
void GameManager::showScore()
{
	std::cout << "Score : " << GameManager::Get().score << std::endl;
}

//walkable obstacles
void GameManager::AddWalkable()
{
	int index = generateRandom(10);
	Obstacle::obstacleList[index].SetModel('-');
	Obstacle::obstacleList[index].SetType(Obstacle::obstacleList[0].WALKABLE);
	index = Obstacle::obstacleList.size() - generateRandom(bounds[0]);
	Obstacle::obstacleList[index].SetModel('-');
	Obstacle::obstacleList[index].SetType(Obstacle::obstacleList[0].WALKABLE);
	index = Obstacle::obstacleList.size() / 3 + generateRandom(10);
	Obstacle::obstacleList[index].SetModel('|');
	Obstacle::obstacleList[index].SetType(Obstacle::obstacleList[0].WALKABLE);
	//sometimes this 'gate' wont appear :D
	index = Obstacle::obstacleList.size() / 3 + generateRandom(12);
	Obstacle::obstacleList[index].SetModel('|');
	Obstacle::obstacleList[index].SetType(Obstacle::obstacleList[0].WALKABLE);
}

//function to hide cursor
void GameManager::hideCursor()
{
	HANDLE consoleHandle = GetStdHandle(STD_OUTPUT_HANDLE);
	CONSOLE_CURSOR_INFO info;
	info.dwSize = 100;
	info.bVisible = FALSE;
	SetConsoleCursorInfo(consoleHandle, &info);
}

//get game status
bool GameManager::IsGameRunning() const
{
	return gameStarted;
}