#include <iostream>
#include <conio.h>
#include <string>
#include <vector>
using namespace std;

class Intalnire
{
private:
	const int m_nrPersoane;
	const string m_destinatie;
	string m_plecare;
	float m_distanta, m_oraIntalnire;
	string* m_numePersoane;
public:
	Intalnire();																											   // Constructor default
	Intalnire(int nrIntalnire, string dest, string plecare, float distanta, float oraInt, string* nP);						   // Constructor cu toti parametrii
	Intalnire(int nrIntalnire, string dest, string plecare = "Plecare Necunoscuta", float distanta = .0f, float oraInt = .0f); // Constructor cu parametrii default
	~Intalnire();																											   // Destructor	
	Intalnire(const Intalnire& copy);																						   // Copy Constructor
	void afisare();

	// Getters
	const int getNrPersoane();
	const string getDestinatie();
	string getPlecare();
	float getDistanta();
	float getOraIntalnire();
	string *getNumePersoane();

	// Setters
	void setPlecare(string plecare);
	void setDistanta(float dist);
	void setOraIntalnire(float ora);
	void setNumePersoane(string* nP);

	// Overloading operators	
	explicit operator string();
	int operator()();
	Intalnire& operator++();
	Intalnire& operator++(int);
	Intalnire& operator--();
	Intalnire& operator--(int);
	Intalnire& operator+=(const Intalnire& rhs);
	string operator[](int index);
	bool operator<(const Intalnire& rhs);
	bool operator>(const Intalnire& rhs);
	bool operator<=(const Intalnire& rhs);
	bool operator>=(const Intalnire& rhs);
	bool operator!();
	bool operator==(const Intalnire& rhs);									// Operator comparare
	Intalnire& operator=(const Intalnire& copy);							// Copy assigment operator
	Intalnire& operator+(const Intalnire& rhs);
	Intalnire& operator-(const Intalnire& rhs);
	friend ostream& operator<<(ostream& out, const Intalnire& intal);		// Output buffer overloading
	friend istream& operator>>(istream& in,Intalnire& intal);				// Input buffer overloading
};

Intalnire::Intalnire(int nrPers,string dest,string plecare,float distanta,float oraInt) : m_nrPersoane(nrPers), m_destinatie(dest)
{
	m_plecare = plecare;
	m_distanta = distanta;
	m_oraIntalnire = oraInt;
	m_numePersoane = NULL;
}

Intalnire::Intalnire() : m_nrPersoane(0) , m_destinatie("Destinatie necunoscuta")
{
	m_plecare = "Plecare Necunoscuta";
	m_distanta = .0f;
	m_oraIntalnire = .0f;
	m_numePersoane = NULL;
}

Intalnire::Intalnire(int nrPers, string dest, string plecare, float distanta, float oraInt, string* numePers) : m_nrPersoane(nrPers), m_destinatie(dest)
{
	m_plecare = plecare;
	m_distanta = distanta;
	m_oraIntalnire = oraInt;
	if (numePers != NULL)
	{
		this->m_numePersoane = new string[this->m_nrPersoane];
		for (int i = 0; i < this->m_nrPersoane; i++)
		{
			this->m_numePersoane[i] = numePers[i];
		}
	}
	else
	{
		this->m_numePersoane = NULL;
	}
}

Intalnire::~Intalnire()
{
	if (this->m_numePersoane != NULL)
	{
		delete[] m_numePersoane;
	}
}

Intalnire::Intalnire(const Intalnire& copy) : m_nrPersoane(copy.m_nrPersoane), m_destinatie(copy.m_destinatie)
{
	this->m_plecare = copy.m_plecare;
	this->m_distanta = copy.m_distanta;
	this->m_oraIntalnire = copy.m_oraIntalnire;

	if (this->m_numePersoane != NULL)
	{
		delete[] this->m_numePersoane;
	}
	if (copy.m_numePersoane != NULL)
	{
		this->m_numePersoane = new string[this->m_nrPersoane];
		for (int i = 0; i < this->m_nrPersoane; i++)
		{
			this->m_numePersoane[i] = copy.m_numePersoane[i];
		}
	}
}

void Intalnire::afisare()
{
	cout << "Afisarea unei intalniri" << endl;
	cout << *this;
}

// Getteri
const int Intalnire::getNrPersoane()
{
	return m_nrPersoane;
}
const string Intalnire::getDestinatie()
{
	return m_destinatie;
}
string Intalnire::getPlecare()
{
	return m_plecare;
}
float Intalnire::getDistanta()
{
	return m_distanta;
}
float Intalnire::getOraIntalnire()
{
	return m_oraIntalnire;
}
string* Intalnire::getNumePersoane()
{
	return m_numePersoane;
}

// Setteri
void Intalnire::setPlecare(string plecare)
{
	m_plecare = plecare;
}
void Intalnire::setDistanta(float dist)
{
	m_distanta = dist;
}
void Intalnire::setOraIntalnire(float oraInt)
{
	m_oraIntalnire = oraInt;
}
void Intalnire::setNumePersoane(string* nP)
{
	if (this->m_numePersoane != NULL)
		delete[] m_numePersoane;

	if (nP != NULL)
	{
		this->m_numePersoane = new string[this->m_nrPersoane];
		for (int i = 0; i < this->m_nrPersoane; i++)
		{
			this->m_numePersoane[i] = nP[i];
		}
	}
}

// Operator overloading
Intalnire::operator string()
{
	return this->m_destinatie;
}

// Numara persoanele care a caror prim nume incepe cu o vocala
int Intalnire::operator()()
{
	int nrPersVoc = 0;
	char vocVec[] = "aeiouAEIOU";
	if (this->m_numePersoane != NULL)
	{
		for (int i = 0; i < this->m_nrPersoane; i++)
		{
			char firstLetter = (this->m_numePersoane[i].c_str())[0];
			if (strchr(vocVec,firstLetter) != NULL)
				nrPersVoc++;
		}
	}
	return nrPersVoc;
}

Intalnire& Intalnire::operator++()
{
	++(this->m_oraIntalnire);
	return *this;
}

Intalnire& Intalnire::operator++(int)
{
	Intalnire temp(*this);
	++(this->m_oraIntalnire);
	return temp;
}

Intalnire& Intalnire::operator--()
{
	--(this->m_oraIntalnire);
	return *this;
}

Intalnire& Intalnire::operator--(int)
{
	Intalnire temp(*this);
	--(this->m_oraIntalnire);
	return temp;
}

Intalnire& Intalnire::operator+=(const Intalnire& rhs)
{
	this->m_oraIntalnire += rhs.m_oraIntalnire;
	return *this;
}

string Intalnire::operator[](int index)
{
	if (index >= 0 && index < this->m_nrPersoane && this->m_numePersoane != NULL)
	{
		return this->m_numePersoane[index];
	}
	return NULL;
}

bool Intalnire::operator<(const Intalnire& rhs)
{
	if (this->m_nrPersoane >= rhs.m_nrPersoane)
		return false;
	return true;
}

bool Intalnire::operator>(const Intalnire& rhs)
{
	if (this->m_nrPersoane <= rhs.m_nrPersoane)
		return false;
	return true;
}

bool Intalnire::operator<=(const Intalnire& rhs)
{
	if (this->m_nrPersoane > rhs.m_nrPersoane)
		return false;
	return true;
}

bool Intalnire::operator>=(const Intalnire& rhs)
{
	if (this->m_nrPersoane < rhs.m_nrPersoane)
		return false;
	return true;
}

bool Intalnire::operator!()
{
	if(this->m_numePersoane == NULL)
	{
		return false;
	}
	else
	{
		return true;
	}
}

bool Intalnire::operator==(const Intalnire& rhs)
{
	if (rhs.m_nrPersoane != this->m_nrPersoane)
		return false;
	return true;
}

Intalnire& Intalnire::operator=(const Intalnire& copy) 
{
	*const_cast<int*> (&this->m_nrPersoane) = copy.m_nrPersoane;
	*const_cast<string*> (&this->m_destinatie) = copy.m_destinatie;
	this->m_plecare = copy.m_plecare;
	this->m_distanta = copy.m_distanta;
	this->m_oraIntalnire = copy.m_oraIntalnire;

	if (this->m_numePersoane != NULL)
		delete[] m_numePersoane;

	if (copy.m_numePersoane != NULL)
	{
		this->m_numePersoane = new string[this->m_nrPersoane];
		for (int i = 0; i < this->m_nrPersoane; i++)
		{
			this->m_numePersoane[i] = copy.m_numePersoane[i];
		}
	}
	return *this;
}

Intalnire& Intalnire::operator+(const Intalnire& rhs)
{
	this->m_oraIntalnire = this->m_oraIntalnire + rhs.m_oraIntalnire;
	return *this;
}

Intalnire& Intalnire::operator-(const Intalnire& rhs)
{
	this->m_oraIntalnire = this->m_oraIntalnire - rhs.m_oraIntalnire;
	return *this;
}

ostream& operator<<(ostream& out, const Intalnire& intal)
{
	out << "Numar persoane : "<< intal.m_nrPersoane << endl;
	out << "Locatie plecare : "<< intal.m_plecare << endl;
	out << "Destinatie : " << intal.m_destinatie << endl;
	out << "Distanta (km) : " << intal.m_distanta << endl;
	out << "Ora : " << intal.m_oraIntalnire << endl;
	for (int i = 0; i < intal.m_nrPersoane; i++)
	{
		out << "Nume persoana "<<i+1<<" : " << intal.m_numePersoane[i] << endl;
	}
	return out;
}

istream& operator>>(istream& in,Intalnire& intal)
{
	int nrPers = 0;
	string dest, plecare;
	float dist, ora;
	string *pers;
	cout << "Numar persoane : "; in>>nrPers;
	in.ignore();
	cout << "Locatie plecare : "; getline(in,plecare);
	cout << "Destinatie : "; getline(in, dest);
	cout << "Distanta (km) : "; in >> dist;
	cout << "Ora : "; in >> ora;
	pers = new string[nrPers];
	in.ignore();
	for (int i = 0; i < nrPers; i++)
	{
		cout << "Nume persoana "<<i+1<<" : ";
		getline(in, pers[i]);
	}
	Intalnire temp(nrPers,dest,plecare,dist,ora,pers);
	intal = temp;
	return in;
}

// Cerinta 3
enum tipVestimentar
{
	FORMAL = 0,
	CASUAL
};

class ICodVestimentar
{
protected:
	tipVestimentar m_codVestimentar;
public:
	virtual void TipVestimentar() = 0;
};

// Am rescris clasa intalnire ca , clasa abstracta pentru a nu mai pune in comentariu
class IntalnireAbstract
{
protected:
	const int m_nrPersoane;
	const string m_destinatie;
	string m_plecare;
	float m_distanta, m_oraIntalnire;
	string* m_numePersoane;
public:
	IntalnireAbstract();																											   // Constructor default
	IntalnireAbstract(int nrIntalnire, string dest, string plecare, float distanta, float oraInt, string* nP);						   // Constructor cu toti parametrii
	IntalnireAbstract(int nrIntalnire, string dest, string plecare = "Plecare Necunoscuta", float distanta = .0f, float oraInt = .0f); // Constructor cu parametrii default
	virtual ~IntalnireAbstract();																									   // Destructor	
	IntalnireAbstract(const IntalnireAbstract& copy);																				   // Copy Constructor
	virtual void afisare() = 0;																										   
};

IntalnireAbstract::IntalnireAbstract(int nrPers, string dest, string plecare, float distanta, float oraInt) : m_nrPersoane(nrPers), m_destinatie(dest)
{
	m_plecare = plecare;
	m_distanta = distanta;
	m_oraIntalnire = oraInt;
	m_numePersoane = NULL;
}

IntalnireAbstract::IntalnireAbstract() : m_nrPersoane(0), m_destinatie("Destinatie necunoscuta")
{
	m_plecare = "Plecare Necunoscuta";
	m_distanta = .0f;
	m_oraIntalnire = .0f;
	m_numePersoane = NULL;
}

IntalnireAbstract::IntalnireAbstract(int nrPers, string dest, string plecare, float distanta, float oraInt, string* numePers) : m_nrPersoane(nrPers), m_destinatie(dest)
{
	m_plecare = plecare;
	m_distanta = distanta;
	m_oraIntalnire = oraInt;
	if (numePers != NULL)
	{
		this->m_numePersoane = new string[this->m_nrPersoane];
		for (int i = 0; i < this->m_nrPersoane; i++)
		{
			this->m_numePersoane[i] = numePers[i];
		}
	}
	else
	{
		this->m_numePersoane = NULL;
	}
}

IntalnireAbstract::~IntalnireAbstract()
{
	if (this->m_numePersoane != NULL)
	{
		delete[] m_numePersoane;
	}
}

IntalnireAbstract::IntalnireAbstract(const IntalnireAbstract& copy) : m_nrPersoane(copy.m_nrPersoane), m_destinatie(copy.m_destinatie)
{
	this->m_plecare = copy.m_plecare;
	this->m_distanta = copy.m_distanta;
	this->m_oraIntalnire = copy.m_oraIntalnire;

	if (this->m_numePersoane != NULL)
	{
		delete[] this->m_numePersoane;
	}
	if (copy.m_numePersoane != NULL)
	{
		this->m_numePersoane = new string[this->m_nrPersoane];
		for (int i = 0; i < this->m_nrPersoane; i++)
		{
			this->m_numePersoane[i] = copy.m_numePersoane[i];
		}
	}
}

class Formal : public IntalnireAbstract,public ICodVestimentar
{
private:
	string m_formulaDeSalut;
	bool m_intalnireSucces;
public:
	Formal(int nrIntalnire, string dest, string plecare, float distanta, float oraInt, string* nP,string formulaSal,bool succes) 
		  : IntalnireAbstract(nrIntalnire, dest,plecare,distanta,oraInt,nP)
	{
		m_formulaDeSalut = formulaSal;
		m_intalnireSucces = succes;
	}
	void TipVestimentar()
	{
		m_codVestimentar = FORMAL;
		cout << "Intalnire formala , business " << endl;
		cout << "Codul vestimentar trebuie sa fie formal" << endl;
	}
	void afisare()
	{
		cout << "Numar persoane : " << m_nrPersoane << endl;
		cout << "Locatie plecare : " << m_plecare << endl;
		cout << "Destinatie : " << m_destinatie << endl;
		cout << "Distanta (km) : " << m_distanta << endl;
		cout << "Cod vestimentar : " << ((m_codVestimentar == CASUAL) ? "Casual" : "Formal") << endl;
		cout << "Ora : " << m_oraIntalnire << endl;
		for (int i = 0; i < m_nrPersoane; i++)
		{
			cout << "Nume persoana " << i + 1 << " : " << m_numePersoane[i] << endl;
		}
		cout << "Formula de salut : "<<m_formulaDeSalut << endl;
		cout << "A avut succes intalnirea ? " <<(m_intalnireSucces ? "Da":"Nu")<< endl;
	}
};

class Informal : public IntalnireAbstract,public ICodVestimentar
{
private:
	int m_costulPentruBautura;
	int m_nrBeti;
public:
	Informal(int nrIntalnire, string dest, string plecare, float distanta, float oraInt, string* nP,int cost,int beti) 
		    : IntalnireAbstract(nrIntalnire, dest, plecare, distanta, oraInt, nP)
	{
		m_costulPentruBautura = cost;
		m_nrBeti = beti;
	}
	void TipVestimentar()
	{
		m_codVestimentar = CASUAL;
		cout << "Intalnire informala , cu prietenii " << endl;
		cout << "Codul vestimentar poate fii oricum, de preferat casual si cat mai comod." << endl;
	}
	void afisare()
	{
		cout << "Numar persoane : " << m_nrPersoane << endl;
		cout << "Locatie plecare : " << m_plecare << endl;
		cout << "Destinatie : " << m_destinatie << endl;
		cout << "Distanta (km) : " << m_distanta << endl;
		cout << "Ora : " << m_oraIntalnire << endl;
		cout << "Cod vestimentar : " <<((m_codVestimentar == CASUAL) ? "Casual" : "Formal") << endl;
		for (int i = 0; i < m_nrPersoane; i++)
		{
			cout << "Nume persoana " << i + 1 << " : " << m_numePersoane[i] << endl;
		}
		cout << "Costul pentru bautura : " << m_costulPentruBautura << endl;
		cout << "Numarul de persoane ce au avut nevoie de ajutor sa ajunga acasa : " << m_nrBeti << endl;
	}
};

class DynamicVectorIntalnire
{
public:
	vector<IntalnireAbstract*> intalniriAbs;
	void add(IntalnireAbstract* in)
	{
		intalniriAbs.push_back(in);
	}
	void quickAdd()
	{
		intalniriAbs.reserve(3);
		intalniriAbs.emplace_back(dynamic_cast<IntalnireAbstract*>(new Informal(5, "Parcul Rozelor", "Centrul Vechi", 100.2f, 22.22f, new string[5]{ "Cristina","Ionut","Robert","Dan","Vali" }, 200, 2)));
		intalniriAbs.emplace_back(dynamic_cast<IntalnireAbstract*>(new Informal(3, "Complex", "Centu", 120.2f, 21.22f, new string[3]{ "Valeriu","Danut","Cristi" }, 100, 0)));
		intalniriAbs.emplace_back(dynamic_cast<IntalnireAbstract*>(new Formal(2, "Politehnica", "Sediul Google", 120.21f, 13.30f, new string[2]{ "Ioan Cristea", "Denis Ion" }, "Buna ziua", true)));
	}
	void printVector()
	{
		for (unsigned int i = 0; i < intalniriAbs.size(); i++)
		{
			intalniriAbs[i]->afisare();
			if (dynamic_cast<Formal*>(intalniriAbs[i]) != NULL)
			{
				dynamic_cast<Formal*>(intalniriAbs[i])->TipVestimentar();
			}
			else
			{
				dynamic_cast<Informal*>(intalniriAbs[i])->TipVestimentar();
			}
			cout << "--------------------------------------------------------------------------------------" << endl;
		}
	}
	~DynamicVectorIntalnire()
	{
		for (unsigned int i = 0; i < intalniriAbs.size(); i++)
			delete intalniriAbs[i];
	}
};

int main()
{
	// Test commands
	Intalnire intal1; //default constructor;
	intal1.afisare();
	cout << "-----------------------------------------------------" << endl;
	cin >> intal1;
	cout << "-----------------------------------------------------" << endl;
	cout << intal1;
	cout << "-----------------------------------------------------" << endl;
	Intalnire intal2(2, "Timisoara", "Dr. Tr. Severin", 200.0f, 10.40f, new string[2]{ "Vali","Oana" });
	intal2.afisare();
	cout << "-----------------------------------------------------" << endl;
	// Test Setteri
	cout << "Setteri au fost folositi pentru obiectul 'intal1'" << endl;
	intal2.setPlecare("Bucuresti");
	intal2.setDistanta(200.50f);
	intal2.setOraIntalnire(12.00f);
	intal2.setNumePersoane(new string[2]{ "Andrei Popescu" , "Oana Pop" });
	cout << "-----------------------------------------------------" << endl;
	// Test Getteri
	cout << "Getteri" << endl;
	cout << "Numar persoane : " << intal2.getNrPersoane() << endl;
	cout << "Destinatie : " << intal2.getDestinatie() << endl;
	cout << "Locatie plecare : " << intal2.getPlecare() << endl;
	cout << "Distanta : " << intal2.getDistanta() << endl;
	cout << "Ora intalnire : " << intal2.getOraIntalnire() << endl;
	cout << "Persoane participante" << endl;
	string *pers = intal2.getNumePersoane();
	for (int i = 0; i < intal2.getNrPersoane(); i++)
	{
		cout << i + 1 << ")" << pers[i] << endl;
	}
	cout << "-----------------------------------------------------" << endl;
	// Test Operatori
	cout << "Operator overloading" << endl;
	cout << "String cast operator : " << (string)intal2 << endl;
	cout << "() operator(nume care incep cu vocala) : " << intal2() << endl;
	++intal2;
	cout << "++(pre) operator : " << intal2.getOraIntalnire() << endl;
	intal2++;
	cout << "(post)++ operator : " << intal2.getOraIntalnire() << endl;
	--intal2;
	cout << "--(pre) operator : " << intal2.getOraIntalnire() << endl;
	intal2--;
	cout << "(post)-- operator : " << intal2.getOraIntalnire() << endl;
	intal2 += intal1;
	cout << "+= operator : " << intal2.getOraIntalnire() << endl;
	cout << "[] operator : " << intal2[0] << endl;
	cout << "! operator : " << !intal2 << endl;
	cout << "== operator : " << (intal2 == intal1) << endl;
	cout << "> operator : " << (intal2 > intal1) << endl;
	cout << ">= operator : " << (intal2 >= intal1) << endl;
	cout << "< operator : " << (intal2 < intal1) << endl;
	cout << "<= operator : " << (intal2 <= intal1) << endl;
	intal2 = intal2 + intal1;
	cout << "+ operator : " << intal2.getOraIntalnire() << endl;
	intal2 = intal2 - intal1;
	cout << "- operator : " << intal2.getOraIntalnire() << endl;
	cout << "-----------------------------------------------------" << endl;
	// Vector alocat dinamic si media geometrica
	Intalnire *intalniri = new Intalnire[3];
	Intalnire intal3(3, "Cluj", "Bucuresti", 400.0f, 8.40f, new string[3]{ "Andrei Pop","Costel","Alexandru Cel Bun" });
	intalniri[0] = intal1;
	intalniri[1] = intal2;
	intalniri[2] = intal3;
	float media_geometrica = 1.0f;
	for (int i = 0; i < 3; i++)
	{
		media_geometrica *= intalniri[i].getDistanta();
	}
	media_geometrica = powf(media_geometrica, (float)1 / 3);
	cout << "Media geometrica este : " << media_geometrica << endl;
	cout << "--------------------------------------------------------------------------------------" << endl;
	// Cerinta 3 - Vector cu clasa abstracta
	DynamicVectorIntalnire intalAbstract;
	intalAbstract.quickAdd();
	intalAbstract.printVector();
	_getch();
	return 0;
}