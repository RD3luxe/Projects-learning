#include <iostream>
#include <SFML/Graphics.hpp>
#include "Resources.h"
#include "Player.h"
#include "Projectile.h"
#include "Enemy.h"
#include "Collision.h"
#include "Tile.h"
#include <fstream>

// Spawn enemy method
void enemySpawner(const sf::RenderWindow& window,std::vector<Enemy>& enemies,sf::Texture enemyTexture[3], float deltaTime)
{
	// Check if the vector is full
	if (enemies.size() >= Resources().Get().maxEnemy)
	{
		// Return , we can't spawn more
		return;
	}
	// Calculate the spawn time
	Resources().Get().m_timerSpawnEnemies += deltaTime;
	if (Resources().Get().m_timerSpawnEnemies >= Resources().Get().timeSpawn)
	{
		// Reset the timer
		Resources().Get().m_timerSpawnEnemies = 0.0f;
		//Create the enemy
		int type = Resources().Get().GetRandom(0, Resources().Get().maxEnemyType - 1);
		Enemy e1(&enemyTexture[type], sf::Vector2u(3, 4), 0.3f, 100.0f,10.0f);
		// Set to a random map position and push back to the vector
		sf::Vector2f pos(Resources().Get().GetRandom(1.0f,(float)window.getSize().x), Resources().Get().GetRandom(1.0f,(float)window.getSize().y));
		e1.GetBody().setPosition(pos);
		// Message
		std::cout << "New enemy created" << std::endl;
		// push in vector
		enemies.push_back(e1);
	}
}

void CreateMap(sf::Texture* texture,std::vector<Tile>& t,int x, int y)
{
	for (int i = 0; i < x; i++)
	{
		for (int j = 0; j < y; j++)
		{
			Resources().Get().Coordonates.x = Resources().Get().Coordonates.x + 32;
			Tile current_tile(texture, Resources().Get().Coordonates);
			current_tile.SetTile(sf::Vector2u(0, 0), true);
			t.push_back(current_tile);
		}
		Resources().Get().Coordonates.y = Resources().Get().Coordonates.y + 32;
	}
}

int main()
{
	// Spell cooldown
	bool m_Cooldown = false;
	float m_totalTime = 0.0f;

	// Create the main window
	sf::RenderWindow window(sf::VideoMode((unsigned int)Resources().Get().VIEW_WEIGHT,(unsigned int)Resources().Get().VIEW_HEIGHT), "Fantasy RPG ~ Lunosia");

	// Set an event
	sf::Event m_event;

	// Set the game window icon
	Resources().Get().SetIcon(window);

	// Create our player
	sf::Texture playerTexture;
	playerTexture.loadFromFile(Resources().Get().SpritesPath + Resources().Get().playerSprite);
	Player player(&playerTexture, sf::Vector2u(3, 4), 0.3f, 200.0f);

	// Create the default projectile
	sf::Texture projectileTexture;
	projectileTexture.loadFromFile(Resources().Get().SpritesPath + Resources().Get().projectile1);
	Projectile proj(&projectileTexture, sf::Vector2u(6,1), 0.3f, 200.0f, 10.0f);

	// Projectiles and enemies arrays
	std::vector<Projectile> projectiles;
	std::vector<Enemy> enemies;

	// Init the view
	Resources().Get().InitCamera(player.GetPosition());

	// Create the delta time for smooth movement
	float deltaTime = 0.0f;
	sf::Clock clock;

	// Create the textures for all enemies
	sf::Texture enemyTexture[3];
	for (int i = 0; i < 3; i++)
	{
		enemyTexture[i].loadFromFile(Resources().Get().SpritesPath + Resources().Get().enemiesName[i]);
	}

	// Create the texture for tiles
	sf::Texture tile;
	tile.loadFromFile(Resources().Get().SpritesPath + Resources().Get().tiles);

	// Array of tiles
	std::vector<Tile> tiles;
	CreateMap(&tile,tiles,20,20);

	// Start the game loop
	while (window.isOpen())
	{
		// delta time for smooth movement
		deltaTime = clock.restart().asSeconds();

		// To cap the framerate
		if (deltaTime > 1.0f / 20.0f)
			deltaTime = 1.0f / 20.0f;

		while (window.pollEvent(m_event))
		{
			// Close the window
			if (m_event.type == sf::Event::Closed)
			{
				window.close();
			}
			if (m_event.type == sf::Event::KeyPressed && m_event.key.code == sf::Keyboard::Escape)
			{
				window.close();
			}
			// Catch the resize events
			if (m_event.type == sf::Event::Resized)
			{
				// Update the view to the new size of the window
				Resources().Get().ResizeView(window);
			}
		}

		// Clear screen
		window.clear(sf::Color::Black);

		// Get the input 
		player.Input(deltaTime);

		// Cooldown Timer
		m_totalTime += deltaTime;
		if (m_totalTime >= 1.0f)
		{
			m_Cooldown = false;
			m_totalTime = 0.0f;
		}

		// Increase the timer
		Collision().Get().collisionTimer += deltaTime;

		// Collision timer
		if (Collision().Get().collisionTimer >= Collision().Get().collideAgain)
		{
			Collision().Get().collisionTimer = 0.0f;
			std::cout << "Collision timer reset." << std::endl;
			// Reset colliders
			player.setCollider(false);
			for (unsigned int j = 0; j < projectiles.size(); j++)
			{
				projectiles[j].setCollider(false);
			}
			for (unsigned int j = 0; j < enemies.size(); j++)
			{
				enemies[j].setCollider(false);
			}
		}

		// Enemy spawner
		enemySpawner(window,enemies,enemyTexture,deltaTime);

		// Attack Input
		if (sf::Keyboard::isKeyPressed(sf::Keyboard::Space) && !m_Cooldown)
		{
			m_Cooldown = true;
			proj.GetBody().setPosition(player.GetPosition());
			proj.projectileDirection = player.curDirection;
			projectiles.push_back(proj);
			std::cout << "Projectile fired , Position : " << proj.GetPosition().x << " " << proj.GetPosition().y << " Player position :"
				<< player.GetPosition().x << " " << player.GetPosition().y << std::endl;
		}

		// Do check collision for wall and enemies
		//for (unsigned int j = 0; j < tiles.size(); j++)
		//{
		//	for (unsigned int i = 0; i < enemies.size(); i++)
		//	{
		//		int colHappend = Collision().Get().IsColliding(tiles[j], enemies[i]);
		//		if (colHappend != 3)
		//		{
		//			colHappend = Collision().Get().IsColliding(enemies[i],tiles[j]);
		//			std::cout << "An enemy collided with the wall" << std::endl;
		//		}
		//		else if (colHappend == 3)
		//		{
		//			std::cout << "An enemy collided with the wall" << std::endl;
		//		}
		//	}
		//}

		// Do check collision for player and enemies
		for (unsigned int i = 0; i < enemies.size(); i++)
		{
			if (!player.getCollider() && !enemies[i].getCollider() && Collision().Get().IsColliding(player,enemies[i]) == 1)
			{
				Collision().Get().collisionTimer += deltaTime;
				// Decrease the player's health
				player.dealDamage(enemies[i].getDamage());
				// Set the collider true
				player.setCollider(true);
				enemies[i].setCollider(true);
				// Check for death
				if (player.getHealth() <= 0)
				{
					// Game over
					std::cout << "Player dead" << std::endl;
				}
				std::cout << "Player health : " << player.getHealth()<<std::endl;
			}
		}

		// Do check collision for bullet and enemies
		for (unsigned int j = 0; j < projectiles.size(); j++)
		{
			for (unsigned int i = 0; i < enemies.size(); i++)
			{
				if (!projectiles[j].getCollider() && !enemies[i].getCollider() && Collision().Get().IsColliding(projectiles[j], enemies[i]) == 2)
				{
					// Set the collider 
					enemies[i].setCollider(true);
					projectiles[j].setCollider(true);
					// Destroy the enemy and the projectile
					enemies[i].destroy = true;
					projectiles[j].destroy = true;
					std::cout << "Enemie collided with the bullet" << std::endl;
				}
			}
		}

		// Destroy the projectile that are marked as destroyed
		for (auto it = projectiles.begin(); it != projectiles.end();)
		{
			if (it->destroy)
			{
				it = projectiles.erase(it);
			}else{
				++it;
			}
		}

		// Destroy the enemies that are marked as destroyed
		for (auto it = enemies.begin(); it != enemies.end();)
		{
			if (it->destroy)
			{
				it = enemies.erase(it);
			}
			else {
				++it;
			}
		}

		// Draw the tiles
		for (auto it = tiles.begin(); it != tiles.end(); it++)
		{
			it->Draw(window);
		}

		// Move the projectile and draw them
		for (auto it = projectiles.begin(); it != projectiles.end(); it++)
		{
			it->MoveProjectile(deltaTime);
			it->Draw(window);
		}

		// Draw the enemies
		for (auto it = enemies.begin(); it != enemies.end(); it++)
		{
			it->MoveEnemy(deltaTime);
			it->Draw(window);
		}

		// Reposition the view acording to the player
		Resources().Get().view.setCenter(player.GetPosition());

		// Set the view
		window.setView(Resources().Get().view);

		// Draw the player
		player.Draw(window);

		// Update the window
		window.display();
	}
	return EXIT_SUCCESS;
}