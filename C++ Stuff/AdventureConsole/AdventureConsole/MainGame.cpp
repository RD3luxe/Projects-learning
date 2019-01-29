#include "GameManager.h"
#include "Entitys.h"

//defines for game management
#define WIDTH 10
#define HEIGHT 20
#define SPAWN_POSITION_X 0
#define SPAWN_POSITION_Y 2
#define FRAME_RATE 120

//entry point for the game
int main()
{
	//initialize the game
	GameManager::Get().InitGame(WIDTH, HEIGHT);
	//spawn the player
	Player pl('O', SPAWN_POSITION_X, SPAWN_POSITION_Y);
	//create some walkable obstacles
	GameManager::Get().AddWalkable();
	//game loop
	while (GameManager::Get().IsGameRunning())
	{
		//Get the Player Input and move him
		GameManager::Get().SetInput(pl);
		//check for collision with any object
		GameManager::Get().CheckCollision(pl, Obstacle::obstacleList);
		//redraw the grid after we got the input
		GameManager::Get().DrawGrid<WIDTH, HEIGHT>(pl, Obstacle::obstacleList);
		//show the score
		GameManager::Get().showScore();
		//sleep for controlling the flow of the game / difficulty 
		Sleep(FRAME_RATE);
	}
	//refresh the screen
	system("cls");
	//show the score and game over after the player lost
	std::cout << "Game over\nYour score : "<<GameManager::Get().score<< std::endl;
	system("Pause");
	return 0;
}