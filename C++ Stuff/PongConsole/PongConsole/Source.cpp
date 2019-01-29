#include "Player.h"
#include <Windows.h>
#define FRAME_RATE 2

int main()
{
	Player *player = new Player();
	// Game loop
	while (true)
	{
		system("cls");
		player->draw(std::cout);
		Sleep(FRAME_RATE * 60);
	}
	delete player;
	return 0;
}