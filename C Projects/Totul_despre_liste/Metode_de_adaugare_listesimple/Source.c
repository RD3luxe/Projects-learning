#include<stdio.h>
#include<stdlib.h>
#include<string.h>

//directive catre preprocesor pentru numele fisierulu si dimensiunea buffer-ului
#define NUME_FISIER "users.txt"
#define B_SIZE 65 

//structura folosita pentru a tine informatiile pe care le folosim
typedef struct data
{
	int nr;
	char *name;
}data;

//structura pentru lista(nod)
typedef struct lista
{
	data info;
	struct lista *urm;
}lista;

//prototipurile tuturor functiilor pentru a rezolva eroarea aia de cacat in care nu imi gaseste definirea FML VS
lista *adaugare_inceput(lista *l, data dt);
lista *adaugare_sfarsit(lista *l, data dt);
lista *adaugare_ordonata(lista *l, data dt);

void readList(lista **l, char *fileName);
lista *add_element_tastatura(lista *l);
void DestroyList(lista **l);
void actualizareFisier(lista *l, char *fileName);

lista *cauta_data(lista *l, int index_cautat);
void stergeElement(lista **l, int index_cautat);
void afisareLista(lista *l);
//end prototipuri

//						  //
//  METODELE DE ADAUGARE  //
//						  //

//adaugare la inceput in lista 
lista *adaugare_inceput(lista *l,data dt)
{
	lista *nod_nou = (lista*)malloc(sizeof(lista));
	if (nod_nou == NULL)
	{
		//return error
		printf("Alocarea memorie pentru elementul din lista a esuat.\n");
		exit(-1);
		return NULL;
	}
	//adaug informatiile in lista
	nod_nou->info = dt;
	//adaugare la inceput in lista
	nod_nou->urm = l;
	l = nod_nou;
	return l;
}

//adaugare la sfarsit in lista 
lista *adaugare_sfarsit(lista *l,data dt)
{
	//crearea elementului nou si alocarea memoriei
	lista *new_node = (lista*)malloc(sizeof(lista));
	if (new_node == NULL)
	{
		printf("Alocarea memorie dinamica esuata.\n");
		exit(-1);
		return NULL;
	}
	//adaugarea informatiior
	new_node->info = dt;
	new_node->urm = NULL;
	//adaugarea propriu zisa
	lista *q1 = l, *q2 = NULL;
	//mergem prin toata lista si cautam nodul de final pentru a putea adauga noul element la el
	for (q1 = l; q1 != NULL; q2 = q1, q1 = q1->urm);
	if(q2 == NULL)//cazul in care nu e nici un element in lista => lista e goala
	{
		l = new_node;
	}
	else
	{
		q2->urm = new_node;
	}
	return l;
}

//adaugarea ordonata intr-o lista 
lista *adaugare_ordonata(lista *l,data dt)
{
	//creez nodul care sa tina data 
	lista *nod_nou = (lista*)malloc(sizeof(lista));
	//ii adaug informatiile mele
	nod_nou->info = dt;
	nod_nou->urm = NULL;
	//creez doua noduri cu care sa trec prin lista
	lista *q1, *q2;
	//caut locul unde trebuie sa introduc nodul nou
	for (q1 = q2 = l; q1 != NULL && q1->info.nr < dt.nr; q2 = q1, q1 = q1->urm);
	if (q1 == q2) //daca sunt egale adica lista nu are nici un element sau ambele sunt NULL
	{
		//facem adaugarea la inceput 
		nod_nou->urm = q2;
		l = nod_nou;
	}
	else
	{
		//adaugam nodul nou intre q1 si q2
		q2->urm = nod_nou;
		nod_nou->urm = q1;
	}
	return l;
}

//														   //
//  CITIREA UNEI LISTE SIMPLE INLANTUITE DIN FISIER TEXT,  //
//          CREAREA UNEI LISTE DE LA TASTATURA,			   //
//        DISTRUGEREA LISTEI (ELIBERAREA MEMORIEI)	       //
//			ACTUALIZARE FISIER CU NOUA LISTA			   //

//citirea din fisier a unei liste
void readList(lista **l, char *fileName)
{
	FILE *f;
	fopen_s(&f, fileName, "rt");
	if (f != NULL)
	{
		data user_data;
		int index;
		char name_temp[B_SIZE];
		//daca imi citeste din fisier fix 2 campuri atunci inseamna ca nu a ajuns la final
		//feof cateodata are probleme cand vine vorba de verificarea ultimei linii din fisier si returneaza duplicate
		while (fscanf(f, "%d %s",&index,name_temp) == 2)
		{
			//citire nume si alocare dinamica nume 
			user_data.name = (char*)malloc(strlen(name_temp) + 1);
			if (user_data.name == NULL)
			{
				printf("Allocation fail.\n");
				exit(-1);
			}
			//copiere nume in informatii daca alocarea a reusit
			user_data.nr = index;
			strcpy(user_data.name, name_temp);
			//3 tipuri de adaugari , choose your weapon :P
			//l = adaugare_inceput(l, user_data);
			//l = adaugare_sfarsit(l, user_data);
			*l = adaugare_ordonata(*l,user_data);
		}
		fclose(f);
		printf("Datele au fost incarcate din fisier.\n");
	}
	else 
	{
		printf("Eroare la deschiderea fisierului %s.\n",fileName);
		exit(-1);
	}
}

//adaugare element citit de la tastatura/modificare daca exista deja
lista *add_element_tastatura(lista *l)
{
	lista *nod_cur = l;
	data user_data;
	char name_temp[B_SIZE];
	printf("Index user : ");
	scanf("%d", &user_data.nr);
	printf("Nume user : ");
	//citire nume si alocare dinamica nume 
	scanf("%s", name_temp);
	user_data.name = (char*)malloc(strlen(name_temp) + 1);
	if (user_data.name == NULL)
	{
		printf("Allocation fail.\n");
		exit(-1);
	}
	//copiere nume in informatii daca alocarea a reusit
	strcpy(user_data.name, name_temp);
	//daca nr exista in lista il modificam sau consideram nr ca fiind un key unic si modificam toate campurile structurii
	if ((nod_cur = cauta_data(l, user_data.nr)) != NULL)
	{
		printf("Userul %s din lista a fost modificat cu %s.\n", nod_cur->info.name, user_data.name);
		//modific doar datele din nodul ala cu datele noi
		nod_cur->info = user_data;
		//easy
	}
	else // il adaugam daca nu exista 
	{
		printf("Userul %s a fost adaugat in lista .\n", user_data.name);
		//3 tipuri de adaugari , choose your weapon :P
		//l = adaugare_inceput(l, user_data);
		//l = adaugare_sfarsit(l, user_data);
		l = adaugare_ordonata(l, user_data);
	}
	return l;
}

//distruge lista -> elibereaza memoria
void DestroyList(lista **l)
{
	//eliberez mai intai memoria pentru sirurile de caractere
	//dupa se elibereaza pentru celula curenta pana ajunge la null
	lista *aux;
	while (*l)
	{
		aux = *l;
		*l = aux->urm;
		free(aux->info.name);
		free(aux);
	}
	*l = NULL;
}

//functie pentru scrierea listei noi in fisier
void actualizareFisier(lista *l, char *fileName)
{
	FILE *f;
	fopen_s(&f, fileName, "wt");
	lista *cont = l;
	for (cont = l; cont != NULL; cont = cont->urm)
	{
		fprintf(f, "%d %s\n",cont->info.nr, cont->info.name);
	}
	fclose(f);
}

//											//
//        CAUTARE,AFISARE SI STERGERE		//
//											//

//functie pentru cautarea unui element de lista dupa indexul acestuia
lista *cauta_data(lista *l,int index_cautat)
{
	//nodul cu care facem cautarea in lista
	lista *searcher = l;
	for (searcher = l; searcher != NULL;searcher = searcher->urm)
	{
		if (searcher->info.nr == index_cautat)
		{
			return searcher;
		}
	}
	return NULL;
}

//functie pentru afisare lista
void afisareLista(lista *l)
{
	lista *nod = l;
	for (nod = l; l != NULL; l = l->urm)
	{
		printf("Index : %d | Nume : %s \n",l->info.nr, l->info.name);
	}
	printf("\n");
}

//functia pentru stergerea unui nod din lista dupa index-ul acestuia(nr)
void stergeElement(lista **l, int index)
{
	lista *q1, *q2;
	for (q1 = q2 = *l; q1 != NULL && q1->info.nr != index; q2 = q1, q1 = q1->urm);
	if (q1 != NULL && q1->info.nr == index)
	{
		if (q1 != q2)
			q2->urm = q1->urm;
		else
			*l = (*l)->urm;
		//afisez mesajul
		printf("Userul %s a fost sters cu succes din lista.\n", q1->info.name);
		//dupa eliberez sirul de caractere si nodul
		free(q1->info.name);
		free(q1);
	}
	else
	{
		printf("Userul cu indexul \"%d\" nu apare in lista.\n", index);
	}
}
//				  \\	
//	FUNCTII MENIU \\
//                \\

//afisare meniu
void meniu()
{
	printf("\n0)Citeste lista din fisier\n");
	printf("1)Adauga in lista de la tastatura\n");
	printf("2)Afisare lista\n");
	printf("3)Cauta data\n");
	printf("4)Stergere dp index\n");
	printf("5)Actualizare fisier\n");
	printf("6)Iesire\n");
	printf("Optiune ta : ");
}

int main()
{
	lista *new_list = NULL;
	int opt,nr_s;
	do
	{
		//afisare meniu
		meniu();
		//optiunea userului de la tastatura
		scanf("%d", &opt);
		//meniu handler
		switch (opt)
		{
			case 0:
				readList(&new_list, NUME_FISIER);
				break;
			case 1 :
				new_list = add_element_tastatura(new_list);
				break;
			case 2 : 
				afisareLista(new_list);
				break;
			case 3 :
				printf("Index cautat in lista : ");
				scanf("%d",&nr_s);
				lista *s = NULL;
				if ((s = cauta_data(new_list,nr_s)) != NULL)
				{
					printf("Index : %d | Nume %s \n", s->info.nr, s->info.name);
				}
				else
				{
					printf("Userul cu indexul cautat nu exista.\n");
				}
				break;
			case 4 :
				printf("Sterge userul cu indexul : ");
				scanf("%d", &nr_s);
				stergeElement(&new_list, nr_s);
				afisareLista(new_list);
				break;
			case 5:
				actualizareFisier(new_list,NUME_FISIER);
				printf("Fisierul a fost actualizat cu noile date.\n");
				break;
			case 6 : 
				//elibereaza memoria pentru a preveni leak-urile de memorie
				DestroyList(&new_list);
				exit(0);
				break;
			default:
				opt = 6;
				break;
		}
	}while (opt != 6);
	return 0;
}