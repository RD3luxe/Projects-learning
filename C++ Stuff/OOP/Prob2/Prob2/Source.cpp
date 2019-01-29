#include <iostream>
#include <conio.h>
#include <string>

#define MAX 100

class Electronic
{
public:
	Electronic()
	{
	}
	Electronic(int voltage, int cost) :
		m_voltage(voltage), m_cost(cost)
	{
	}
	void test() { std::cout << "Diamond shape problem here." << std::endl; }
	// Getters
	int getVoltage()
	{
		return m_voltage;
	}
	int getCost()
	{
		return m_cost;
	}
	// Setters
	void setVoltage(int v)
	{
		m_voltage = v;
	}
	void setCost(int cost)
	{
		m_cost = cost;
	}
private:
	int m_voltage,m_cost;
};

class Scanner : public Electronic
{
public:
	Scanner()
	{
	}
	Scanner(int voltage, int cost, int speed, std::string model) :
		Electronic(voltage, cost), m_speed(speed), m_model(model)
	{
	}
	void printInfoScanner()
	{
		std::cout << "Viteza de plotare : " << m_speed<<std::endl;
		std::cout << "Model : " << m_model << std::endl;
	}
	// Getters
	int getSpeed()
	{
		return m_speed;
	}
	std::string getModel()
	{
		return m_model;
	}
	// Setters
	void setSpeed(int v)
	{
		m_speed = v;
	}
	void setModel(std::string mdl)
	{
		m_model = mdl;
	}
private:
	int m_speed;
	std::string m_model;
};

class Imprimanta : public Electronic
{
public:
	Imprimanta()
	{
	}
	Imprimanta(int voltage, int cost, std::string tipFoaie, bool color) :
		Electronic(voltage, cost), m_isColor(color), m_tipFoaie(tipFoaie)
	{
	}
	void printInfoImprimanta()
	{
		std::cout << "Voltaj : " << getVoltage() << std::endl;
		std::cout << "Cost : " << getCost() << std::endl;
		std::cout << "Tip foaie : " << m_tipFoaie<<std::endl;
		std::cout << "E color ? : " << m_isColor << std::endl;
	}
	// Getters
	std::string getTipFoaie()
	{
		return m_tipFoaie;
	}
	bool getIsColor()
	{
		return m_isColor;
	}
	// Setters
	void setTipFoaie(std::string v)
	{
		m_tipFoaie = v;
	}
	void setIsColor(bool beg)
	{
		m_isColor = beg;
	}
private:
	std::string m_tipFoaie;
	bool m_isColor;
};

class Xerox : public Scanner, public Imprimanta
{
public:
	Xerox()
	{
	}
	Xerox(int voltage, int cost, std::string tipFoaie, bool isColor, int speed, std::string model, std::string color, int stroke) :
		Scanner(voltage, cost, speed, model), Imprimanta(voltage, cost, tipFoaie, isColor), m_color(color), m_stroke(stroke)
	{
	}
	// Getters
	std::string getColor()
	{
		return m_color;
	}
	int getStroke()
	{
		return m_stroke;
	}
	// Setters
	void setColor(int v)
	{
		m_color = v;
	}
	void setStroke(int cost)
	{
		m_stroke = cost;
	}
	friend std::ostream& operator<<(std::ostream& os, const Xerox& xe);
	friend std::istream& operator>>(std::istream& is, Xerox& xe);
private:
	std::string m_color;
	int m_stroke;
};

std::ostream& operator<<(std::ostream& os, const Xerox& xe)
{
	os << "Culoare : " << xe.m_color << std::endl;
	os << "Grosime linii : " << xe.m_stroke << std::endl;
	static_cast<Imprimanta>(xe).printInfoImprimanta();
	static_cast<Scanner>(xe).printInfoScanner();
	return os;
}

std::istream& operator>>(std::istream& is, Xerox& xe)
{
	std::string model;
	std::cout << "Model : ";
	is >> model;
	xe.setModel(model);
	int speed;
	std::cout << "Viteza de plotare : ";
	is >> speed;
	xe.setSpeed(speed);
	std::string tip_foaie;
	std::cout << "Tip foaie : ";
	is >> tip_foaie;
	xe.setTipFoaie(tip_foaie);
	bool e_color;
	std::cout << "E color?(1/0) : ";
	is >> e_color;
	xe.setIsColor(e_color);
	int volt_cost;
	std::cout << "Voltaj : ";
	is >> volt_cost;
	xe.Imprimanta::setVoltage(volt_cost);
	std::cout << "Cost : ";
	is >> volt_cost;
	xe.Imprimanta::setCost(volt_cost);
	std::cout << "Culoare : ";
	is >> xe.m_color;
	std::cout << "Grosime linii : ";
	is >> xe.m_stroke;
	return is;
}

int main()
{
	Xerox x[MAX];
	int countXerox = 0;
	// Diamond shape problems apare pentru ca clasa Electronics este base class pentru clasele scanner si imprimata care sunt base class-uri pt Xerox 
	// Astfel avem implementarea unei anumite fctii de 2 din Electronics , 1 data din membri mosteniti de Imprimanta si inca odata de membrii mosteniti de Scanner
	//x.test();
	int opt;
	bool found = false;
	std::string xeroxModel;
	do
	{
		std::cout << "[1] Adauga xerox in vectorul de xeroxuri." << std::endl;;
		std::cout << "[2] Cauta xerox in vectorul de xeroxuri." << std::endl;;
		std::cout << "[3] Afisare toate xerox-urile" << std::endl;;
		std::cout << "[4] Stergere" << std::endl;;
		std::cout << "[0] Exit" << std::endl;
		std::cout << "Optiune : "; std::cin >> opt;
		switch (opt)
		{
		case 1:
			if (countXerox >= MAX)
			{
				std::cout << "Capacitatea maxima a fost atinsa." << std::endl;
				break;
			}
			std::cin >> x[countXerox];
			countXerox++;
			break;
		case 2:
			std::cout << "Xerox cautat : ";
			std::cin >> xeroxModel;
			found = false;
			for (int i = 0; i < countXerox; i++)
			{
				if (x[i].getModel() == xeroxModel)
				{
					found = true;
					std::cout << "Xerox found : " << x[i] << std::endl;
					break;
				}
			}
			if (!found)
			{
				std::cout << "Modelul " + xeroxModel + " nu a fost gasit." << std::endl;
			}
			break;
		case 3:
			for (int i = 0; i < countXerox; i++)
			{
				std::cout << i+1<<")"<< x[i] << std::endl;
			}
			break;
		case 4:
			std::cout << "Xerox cautat pt stergere : ";
			std::cin >> xeroxModel;
			found = false;
			for (int i = 0; i < countXerox; i++)
			{
				if (x[i].getModel() == xeroxModel)
				{
					found = true;
					for (int j = i; j < countXerox; j++)
					{
						x[j] = x[j + 1];
					}
					countXerox--;
					std::cout << "Xerox sters." << std::endl;
					break;
				}
			}
			if (!found)
			{
				std::cout << "Modelul " + xeroxModel + " nu a fost gasit." << std::endl;
			}
			break;
		case 0:
			opt = 0;
		default:
			exit(0);
		}
	} while (opt != 0);
	_getch();
	return 0;
}