#include <SFML/Graphics.hpp>
#include <iostream>
#include <vector>
#include "Player.h"
#include "Platform.h"

static const float VIEW_HEIGHT = 512.0f;

void ResizeView(sf::RenderWindow& window, sf::View& view)
{
	float aspectRatio = (float)window.getSize().x / (float)window.getSize().y;
	view.setSize(VIEW_HEIGHT * aspectRatio, VIEW_HEIGHT);
}

int main()
{
	sf::Event m_event;
	sf::RenderWindow window(sf::VideoMode(512, 512), "Game Test", sf::Style::Close | sf::Style::Titlebar | sf::Style::Resize);
	sf::View view(sf::Vector2f(0.0f,0.0f), sf::Vector2f(VIEW_HEIGHT, VIEW_HEIGHT));

	sf::Texture playerTexture;
	playerTexture.loadFromFile("player.png");
	Player player(&playerTexture, sf::Vector2u(3, 9),0.3f,100.0f,240.0f);
	Collider playerCol = player.GetCollider();
	sf::Vector2f direction;

	float deltaTime = 0.0f;
	sf::Clock clock;

	sf::Texture platformTexture;
	platformTexture.loadFromFile("platform.png");
	std::vector<Platform> platforms;
	platforms.emplace_back(&platformTexture, sf::Vector2f(1000.0f,90.0f), sf::Vector2f(1000.0f, 200.0f));
	platforms.emplace_back(&platformTexture, sf::Vector2f(1000.0f,100.0f), sf::Vector2f(500.0f, 0.0f));
	platforms.emplace_back(nullptr, sf::Vector2f(1000.0f, 500.0f), sf::Vector2f(200.0f, 600.0f));

	while (window.isOpen())
	{
		deltaTime = clock.restart().asSeconds();
		if (deltaTime > 1.0f / 20.0f)
			deltaTime = 1.0f / 20.0f;

		while (window.pollEvent(m_event))
		{
			switch (m_event.type)
			{
				case sf::Event::Closed:
					window.close();
					break;
				case sf::Event::Resized:
					ResizeView(window, view);
					break;
				//case sf::Event::TextEntered:
				//	if (m_event.text.unicode < 128)
				//	{
				//		std::cout << static_cast<char>(m_event.text.unicode);
				//	}
				//	break;
			}
		}

		//if (sf::Mouse::isButtonPressed(sf::Mouse::Left))
		//{
		//	sf::Vector2i mPos = sf::Mouse::getPosition(window);
		//	// C style cast and C++ cast
		//	player.setPosition((float)mPos.x,static_cast<float>(mPos.y));
		//}

		player.Update(deltaTime);
		for (Platform& platform : platforms)
		{
			if (platform.GetCollider().CheckCollision(playerCol, direction, 1.0f))
			{
				player.OnCollision(direction);
			}
		}
		if (direction.y < 0)
		{
			player.SetInAir(false);
		}
		else
		{
			player.SetInAir(true);
		}
		view.setCenter(player.GetPosition());

		window.clear(sf::Color::Red);
		window.setView(view);
		player.Draw(window);
		for (Platform& platform : platforms)
		{
			platform.Draw(window);
		}
		window.display();
	}
	system("Pause");
	return 0;
}