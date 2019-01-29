#include<iostream>
#include<chrono>
#include<string>

void generateProb(int sumDices)
{
	int probNr = 1;
	int dice1 = 0, dice2 = 0;
	for (int i = 1; i <= sumDices; i++)
	{
		if (i > 6 || sumDices - i <= 0 || sumDices - i > 6)
			continue;

		dice1 = i;
		dice2 = sumDices - i;
		std::cout << "Probability number - " << probNr << std::endl;
		std::cout << "Dice 1 : " << dice1 << std::endl;
		std::cout << "Dice 2 : " << dice2 << std::endl;
		probNr++;
	}
	std::cout << "\n******************************************\n" << std::endl;
}

void simulateDices(int simulation_numbers, int data[])
{
	int simNr = 1, i = 0;
	//init array
	for (i = 0; i < 13; i++)
	{
		data[i] = 0;
	}
	//start simulations
	for (i = 0; i < simulation_numbers; i++)
	{
		std::cout << "**** Simulation number - " << simNr << std::endl;
		int dicesSum = rand() % 11 + 2; // suma celor 2 zaruri este intre 2 si 12
		std::cout << "**** Sum of dices : " << dicesSum << std::endl;
		data[dicesSum]++;
		generateProb(dicesSum);
		simNr++;
	}
}

int main()
{
	//some data
	int data[13];
	int sim_nr = 0;
	std::cout << "Number of simulations : "; std::cin >> sim_nr;
	unsigned int seed = (unsigned)std::chrono::steady_clock::now().time_since_epoch().count();
	srand(seed);
	std::chrono::steady_clock::time_point start = std::chrono::steady_clock::now();
	simulateDices(sim_nr, data);
	std::chrono::steady_clock::time_point end = std::chrono::steady_clock::now();
	std::chrono::steady_clock::duration duration = end - start;
	std::cout << "Simulation took : " << std::chrono::duration_cast<std::chrono::milliseconds>(duration).count() << " ms" << std::endl;
	std::cout << "Data(dice's sums) for " << sim_nr << " simulations : " << std::endl;
	for (int i = 2; i <= 12; i++)
	{
		if (data[i] == 0)
			continue;

		std::cout << i << " : " << std::string(data[i], '*') << std::endl;
	}
	system("Pause");
	return 0;
}