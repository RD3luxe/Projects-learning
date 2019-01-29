#include <iostream>
#include <string>
#include <conio.h>

#define ZOOLIMIT 100

class Animal
{
public:
	Animal()
	{
	}
	Animal(std::string name,std::string food ,int legs,int age,char gender) :
		m_name(name),m_favoriteFood(food),m_legs(legs),m_age(age),m_gender(gender)
	{
	}
	void introduction()
	{
		switch (m_gender)
		{
		case 'M' :
			std::cout << "Hi,I'm a male animal" << " ,my name is " << m_name << "\nMy favorite food is " << m_favoriteFood << "\nI have " << m_legs << " legs and I'm " << m_age << " years old." << std::endl;
			break;
		case 'F' :
			std::cout << "Hi,I'm a female animal" << " ,my name is " << m_name << "\nMy favorite food is " << m_favoriteFood << "\nI have " << m_legs << " legs and I'm " << m_age << " years old." << std::endl;
			break;
		case 'N' :
			std::cout << "Hi,I'm a neutral animal" << " ,my name is " << m_name << "\nMy favorite food is " << m_favoriteFood << "\nI have " << m_legs << " legs and I'm " << m_age << " years old." << std::endl;
			break;
		}
	}
	// Getters
	std::string getName()
	{
		return m_name;
	}
	std::string getFood()
	{
		return m_favoriteFood;
	}
	int getAge()
	{
		return m_age;
	}
	int getLegs()
	{
		return m_legs;
	}
	char getGender()
	{
		return m_gender;
	}
	// Setters
	void setName(std::string name)
	{
		m_name = name;
	}
	void setFood(std::string food)
	{
		m_favoriteFood = food;
	}
	void setAge(int age)
	{
		m_age = age;
	}
	void setLegs(int legs)
	{
		m_legs = legs;
	}
	void setGender(int g)
	{
		m_gender = g;
	}
private:
	std::string m_name, m_favoriteFood;
	int m_legs,m_age;
	char m_gender; // M - masculin , F - feminin , N - neutru we don't assume gender here 
};

class Erbivor : public Animal
{
public:
	Erbivor()
	{
	}
	Erbivor(std::string nume,std::string food,int legs,int age,char gender,int platsPerDay,int waterUsed) : 
			Animal(nume,food,legs,age, gender), m_plantsPerDay(platsPerDay), m_waterConsumed(waterUsed)
	{
	}
	// Getters
	int getPlants()
	{
		return m_plantsPerDay;
	}
	int getWater()
	{
		return m_waterConsumed;
	}
	// Setters
	void setPlants(int plants)
	{
		m_plantsPerDay = plants;
	}
	void setWater(int water)
	{
		m_waterConsumed = water;
	}
private:
	int m_plantsPerDay, m_waterConsumed;
};

class Carnivor : public Animal
{
public:
	Carnivor()
	{
	}
	Carnivor(std::string nume, std::string food, int legs, int age, char gender, int meatPerDay, bool isDangerous) :
		Animal(nume, food, legs, age, gender), m_meatPerDay(meatPerDay), m_isDangerous(isDangerous)
	{
	}
	// Getters
	int getMeat()
	{
		return m_meatPerDay;
	}
	bool getDanger()
	{
		return m_isDangerous;
	}
	// Setters
	void setMeat(int meat)
	{
		m_meatPerDay = meat;
	}
	void setDanger(int d)
	{
		m_isDangerous = d;
	}
private:
	int m_meatPerDay;
	bool m_isDangerous;
};

class Omnivor : public Animal
{
public:
	Omnivor()
	{
	}
	Omnivor(std::string nume, std::string food, int legs, int age, char gender,int meat,int platsPerDay) :
		Animal(nume, food, legs, age, gender), m_meatEated(meat), m_plantsEated(platsPerDay)
	{
	}
	// Getters
	int getPlants()
	{
		return m_plantsEated;
	}
	int getMeat()
	{
		return m_meatEated;
	}
	// Setters
	void setPlants(int plants)
	{
		m_plantsEated = plants;
	}
	void setMeat(int m)
	{
		m_meatEated = m;
	}
private:
	int m_meatEated, m_plantsEated;
};

class Iepure : public Erbivor
{
public:
	Iepure()
	{
	}
	Iepure(std::string nume, std::string food, int legs, int age, char gender, int platsPerDay, int waterUsed,std::string colour) :
		Erbivor(nume, food, legs, age, gender,platsPerDay,waterUsed), m_color(colour)
	{
	}
	// GETTERS
	std::string getColor()
	{
		return m_color;
	}
	// Setters
	void setColor(std::string col)
	{
		m_color = col;
	}
	friend std::ostream& operator<<(std::ostream& os, const Iepure& iep);
	friend std::istream& operator>>(std::istream& is, Iepure& iep);
private:
	std::string m_color;
};

class Lup : public Carnivor
{
public:
	Lup()
	{
	}
	Lup(std::string nume, std::string food, int legs, int age, char gender, int meat, bool isDangerous,bool alone) :
		Carnivor(nume, food, legs, age, gender, meat, isDangerous),m_isAlone(alone)
	{
	}
	// GETTERS
	bool getAlone()
	{
		return m_isAlone;
	}
	// Setters
	void setAlone(bool a)
	{
		m_isAlone = a;
	}
	friend std::ostream& operator<<(std::ostream& os, const Lup& lu);
	friend std::istream& operator>>(std::istream& is, Lup& lu);
private:
	bool m_isAlone;
};

class Leu : public Carnivor
{
public:
	Leu()
	{
	}
	Leu(std::string nume, std::string food, int legs, int age, char gender, int meat, bool isDangerous,int teeths) :
		Carnivor(nume, food, legs, age, gender, meat, isDangerous), m_teeths(teeths)
	{
	}
	// GETTERS
	int getTeeths()
	{
		return m_teeths;
	}
	// Setters
	void setTeeths(int t)
	{
		m_teeths = t;
	}
	friend std::ostream& operator<<(std::ostream& os, const Leu& le);
	friend std::istream& operator>>(std::istream& is, Leu& le);
private:
	int m_teeths;
};

class Corb : public Omnivor
{
public:
	Corb()
	{
	}
	Corb(std::string nume, std::string food, int legs, int age, char gender, int meat, int platsPerDay,int feather) :
		Omnivor(nume, food, legs, age, gender, meat, platsPerDay), m_feathersNumber(feather)
	{
	}
	// GETTERS
	int getFeathers()
	{
		return m_feathersNumber;
	}
	// Setters
	void setFeathers(int f)
	{
		m_feathersNumber = f;
	}
	friend std::ostream& operator<<(std::ostream& os, const Corb& co);
	friend std::istream& operator>>(std::istream& is, Corb& co);
private:
	int m_feathersNumber;
};

// friend methods for istream and ostream | Iepure,Lup,Corb si Leu

// IEPURE
std::ostream& operator<<(std::ostream& os,const Iepure& iep)
{
	static_cast<Animal>(iep).introduction();
	std::cout << "I'm also a "<< iep.m_color << " rabbit."<<std::endl;
	std::cout << "I eat "<< static_cast<Erbivor>(iep).getPlants() << " plants per day." << std::endl;
	std::cout << "I drink " << static_cast<Erbivor>(iep).getWater() <<" L everyday."<< std::endl;
	return os;
}

std::istream& operator>>(std::istream& is, Iepure& iep)
{
	std::string name, food;
	char gender;
	int picioare, age, plants, water;
	std::cout << "Nume : "; is >> name; 
	iep.setName(name);
	std::cout << "Mancare preferata : "; is >> food;
	iep.setFood(food);
	std::cout << "Nr picioare : "; is >> picioare;
	iep.setLegs(picioare);
	std::cout << "Varsta : "; is >> age;
	iep.setAge(age);
	std::cout << "Gender : "; is >> gender;
	iep.setGender(gender);
	std::cout << "Plante consumate pe zi : "; is >> plants;
	iep.setPlants(plants);
	std::cout << "Litrii de apa consumati pe zi : "; is >> water;
	iep.setWater(water);
	std::cout << "Culoare : "; is >> iep.m_color;
	return is;
}

// LUP
std::ostream& operator<<(std::ostream& os, const Lup& lu)
{
	static_cast<Animal>(lu).introduction();
	std::cout << "I'm a "<<(lu.m_isAlone? "lonely":"not lonely")<<" wolf." << std::endl;
	std::cout << "I eat " << static_cast<Carnivor>(lu).getMeat()<< " kg of meat per day." << std::endl;
	std::cout << "I am " <<( static_cast<Carnivor>(lu).getDanger() ? "dangerous" : "not dangerous" )<< std::endl;
	return os;
}

std::istream& operator>>(std::istream& is, Lup& lu)
{
	std::string name, food;
	char gender;
	int picioare, age, meat;
	bool danger;
	std::cout << "Nume : "; is >> name;
	lu.setName(name);
	std::cout << "Mancare preferata : "; is >> food;
	lu.setFood(food);
	std::cout << "Nr picioare : "; is >> picioare;
	lu.setLegs(picioare);
	std::cout << "Varsta : "; is >> age;
	lu.setAge(age);
	std::cout << "Gender : "; is >> gender;
	lu.setGender(gender);
	std::cout << "Carne consumata pe zi : "; is >> meat;
	lu.setMeat(meat);
	std::cout << "Dangerous ? (1/0) : "; is >> danger;
	lu.setDanger(danger);
	std::cout << "Walks alone? (1/0) : "; is >> lu.m_isAlone;
	return is;
}

// LEU
std::ostream& operator<<(std::ostream& os, const Leu& le)
{
	static_cast<Animal>(le).introduction();
	std::cout << "I'm a lion and I have " << le.m_teeths << " teeths." << std::endl;
	std::cout << "I eat " << static_cast<Carnivor>(le).getMeat() << " kg of meat per day." << std::endl;
	std::cout << "I am " << (static_cast<Carnivor>(le).getDanger() ? "dangerous" : "not dangerous") << std::endl;
	return os;
}

std::istream& operator>>(std::istream& is, Leu& le)
{
	std::string name, food;
	char gender;
	int picioare, age, meat;
	bool danger;
	std::cout << "Nume : "; is >> name;
	le.setName(name);
	std::cout << "Mancare preferata : "; is >> food;
	le.setFood(food);
	std::cout << "Nr picioare : "; is >> picioare;
	le.setLegs(picioare);
	std::cout << "Varsta : "; is >> age;
	le.setAge(age);
	std::cout << "Gender : "; is >> gender;
	le.setGender(gender);
	std::cout << "Carne consumata pe zi : "; is >> meat;
	le.setMeat(meat);
	std::cout << "Dangerous ? (1/0) : "; is >> danger;
	le.setDanger(danger);
	std::cout << "Teeths : "; is >> le.m_teeths;
	return is;
}

// CORB
std::ostream& operator<<(std::ostream& os, const Corb& co)
{
	static_cast<Animal>(co).introduction();
	std::cout << "I'm a raven and I have " << co.m_feathersNumber << " black feathers." << std::endl;
	std::cout << "I eat " << static_cast<Omnivor>(co).getMeat() << " kg of meat per day." << std::endl;
	std::cout << "I eat " << static_cast<Omnivor>(co).getPlants() << " plants everyday." << std::endl;
	return os;
}

std::istream& operator>>(std::istream& is,Corb& co)
{
	std::string name, food;
	char gender;
	int picioare, age, meat, plant;
	std::cout << "Nume : "; is >> name;
	co.setName(name);
	std::cout << "Mancare preferata : "; is >> food;
	co.setFood(food);
	std::cout << "Nr picioare : "; is >> picioare;
	co.setLegs(picioare);
	std::cout << "Varsta : "; is >> age;
	co.setAge(age);
	std::cout << "Gender : "; is >> gender;
	co.setGender(gender);
	std::cout << "Carne consumata pe zi : "; is >> meat;
	co.setMeat(meat);
	std::cout << "Plante consumate pe zi : "; is >> plant;
	co.setPlants(plant);
	std::cout << "Feathers : "; is >> co.m_feathersNumber;
	return is;
}

int main()
{
	Iepure rabbits[ZOOLIMIT];
	Lup wolfes[ZOOLIMIT];
	Leu lions[ZOOLIMIT];
	Corb ravens[ZOOLIMIT];
	int opt = 0;
	int type;
	std::string name;
	int countRabbits = 0, countLions = 0, countWolfes = 0, countRavens = 0;
	int found = 0;
	do
	{
		std::cout << "[1] Adauga animal in gradina" << std::endl;
		std::cout << "[2] Cauta un animal" << std::endl;
		std::cout << "[3] Sterge animal" << std::endl;
		std::cout << "[4] Afisare toate animalele" << std::endl;
		std::cout << "[0] Exit" << std::endl;
		std::cout << "Optiune : "; std::cin >> opt;
		switch (opt)
		{
			case 1 :
				std::cout << "Tip animal adaugat : "; std::cin >> type; // 1 - rabbit,2 - lup, 3 - leu, 4 - corb
				switch (type)
				{
					case 1 :
						if (countRabbits >= ZOOLIMIT)
						{
							std::cout << "Sunt deja prea multi iepuri introdusi in gradina." << std::endl;
							break;
						}
						std::cin >> rabbits[countRabbits];
						countRabbits++;
						break;
					case 2 :
						if (countWolfes >= ZOOLIMIT)
						{
							std::cout << "Sunt deja prea multi lupi introdusi in gradina." << std::endl;
							break;
						}
						std::cin >> wolfes[countWolfes];
						countWolfes++;
						break;
					case 3 :
						if (countLions >= ZOOLIMIT)
						{
							std::cout << "Sunt deja prea multi lei introdusi in gradina." << std::endl;
							break;
						}
						std::cin >> lions[countLions];
						countLions++;
						break;
					case 4 :
						if (countRavens >= ZOOLIMIT)
						{
							std::cout << "Sunt deja prea multi corbi introdusi in gradina." << std::endl;
							break;
						}
						std::cin >> ravens[countRavens];
						countRavens++;
						break;
					default :
						opt = 0;
						break;
				}
				break;
			case 2 : 
				std::cout << "Tip animal cautat : "; std::cin >> type; // 1 - rabbit,2 - lup, 3 - leu, 4 - corb
				std::cout << "Nume animal cautat : "; std::cin >> name; 
				found = 0;
				switch (type)
				{
					case 1:
						for (int i = 0; i < countRabbits; i++)
						{
							if (name == rabbits[i].getName())
							{
								found = 1;
								std::cout << "Iepure gasit : " << std::endl;
								std::cout << rabbits[i] << std::endl;
								break;
							}
						}
						break;
					case 2:
						for (int i = 0; i < countWolfes; i++)
						{
							if (name == wolfes[i].getName())
							{
								found = 1;
								std::cout << "Lup gasit : " << std::endl;
								std::cout << wolfes[i] << std::endl;
								break;
							}
						}
						break;
					case 3:
						for (int i = 0; i < countLions; i++)
						{
							if (name == lions[i].getName())
							{
								found = 1;
								std::cout << "Leu gasit : " << std::endl;
								std::cout << lions[i] << std::endl;
								break;
							}
						}
						break;
					case 4:
						for (int i = 0; i < countRavens; i++)
						{
							if (name == ravens[i].getName())
							{
								found = 1;
								std::cout << "Corb gasit : " << std::endl;
								std::cout << ravens[i] << std::endl;
								break;
							}
						}
						break;
					default:
						opt = 0;
						break;
				}
				if (found == 0)
				{
					std::cout << "Animalul cu numele " << name << " nu a fost gasit in gradina zoologica." << std::endl;
				}
				break;
			case 3 :
				std::cout << "Tip animal de sters : "; std::cin >> type; // 1 - rabbit,2 - lup, 3 - leu, 4 - corb
				std::cout << "Nume animal de sters : "; std::cin >> name;
				found = 0;
				switch (type)
				{
					case 1:
						for (int i = 0; i < countRabbits; i++)
						{
							if (rabbits[i].getName() == name)
							{
								found = 1;
								for (int j = i; j < countRabbits; j++)
								{
									rabbits[j] = rabbits[j + 1];
								}
								countRabbits--;
							}
						}
						break;
					case 2:
						for (int i = 0; i < countWolfes; i++)
						{
							if (wolfes[i].getName() == name)
							{
								found = 1;
								for (int j = i; j < countWolfes; j++)
								{
									wolfes[j] = wolfes[j + 1];
								}
								countWolfes--;
							}
						}
						break;
					case 3:
						for (int i = 0; i < countLions; i++)
						{
							if (lions[i].getName() == name)
							{
								found = 1;
								for (int j = i; j < countLions; j++)
								{
									lions[j] = lions[j + 1];
								}
								countLions--;
							}
						}
						break;
					case 4:
						for (int i = 0; i < countRavens; i++)
						{
							if (ravens[i].getName() == name)
							{
								found = 1;
								for (int j = i; j < countRavens; j++)
								{
									ravens[j] = ravens[j + 1];
								}
								countRavens--;
							}
						}
						break;
					default:
						opt = 0;
						break;
				}
				if (found == 0)
				{
					std::cout << "Animalul cu numele " << name << " nu a fost gasit in gradina zoologica." << std::endl;
				}
				else
				{
					std::cout << "Animalul cu numele " << name << " a fost sters cu succes din gradina zoologica." << std::endl;
				}
				break;
			case 4: 
				// Print rabbits
				std::cout << "Iepuri : " << std::endl;
				for (int i = 0; i < countRabbits; i++)
				{
					std::cout <<i<<" ) "<< rabbits[i] << std::endl;
				}
				// Print wolfes
				std::cout << "Lupi : " << std::endl;
				for (int i = 0; i < countWolfes; i++)
				{
					std::cout << i << " ) " << wolfes[i] << std::endl;
				}
				// Print lions
				std::cout << "Lei : " << std::endl;
				for (int i = 0; i < countLions; i++)
				{
					std::cout << i << " ) " << lions[i] << std::endl;
				}
				// Print ravens
				std::cout << "Corbi : " << std::endl;
				for (int i = 0; i < countRavens; i++)
				{
					std::cout << i << " ) " << ravens[i] << std::endl;
				}
				break;
			case 0:
				opt = 0;
			default :
				exit(0);
				break;
		}
	}while (opt > 0);
	_getch();
	return 0;
}