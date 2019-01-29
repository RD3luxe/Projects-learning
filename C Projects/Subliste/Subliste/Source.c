#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#define FILE_NAME "autori.txt"  
#define FILE_NAME2 "carti.txt"  
#define BUFFER 69  //  dimensiunea bufferului :)) 

//tipul de date pentru sublista
typedef struct book
{
	char *nume_autor;
	char *nume_carte;
	int nr_pagini, an_publicare;
	struct book *urm;
}book;

//tipul de date pentru lista in sine
typedef struct autor
{
	char *nume_autor;
	char *e_viu;
	int an_nasterii, nr_carti, varsta;
	struct autor *urm; //pointer catre urmatorul nod din lista
	struct book *sl;//pointer la primul nod din sublista
}autor;

//prototipuri pt  a scapa de eroarea cu definirea
autor *adauga_autor(autor *a, autor *new_node);
book *adauga_carte(book *m, book *new_book);
void readDB(char *nume_fisier, char *nume_fisier2, autor **lst);

autor *adauga_lista(autor *l, char *nume_autor);
autor *cauta_autor(autor *l, char *nume_cautat);
book *cauta_carte(autor *l, char *nume_cautat);
void cautare_conditionat(autor *a, int nr_carti);

void updateFisiere(char *f1, char *f2, autor *l);

void afisareLista(autor *a);
void printBooks(autor *a);

autor *sterge_autor(autor *l, char *nume);
autor *sterge_carte(autor *l, char *nume_cautat);

void DestroyList(autor **a);
void DestroySublist(book **m);
//end prototipuri

//																		 			//								
//		 FUNCTII PENTRU ADAUGAREA IN LISTA PRINCIPALA SI IN LISTA SECUNDARA			//
//																		 			//

//adaugarea unui autor in lista ordonata de autori
autor *adauga_autor(autor *a, autor *new_node)
{
	autor *q1, *q2;
	for (q1 = q2 = a; q1 != NULL && strcmp(q1->nume_autor, new_node->nume_autor) < 0; q2 = q1, q1 = q1->urm);
	if (q1 == q2) 
	{
		new_node->urm = a;
		a = new_node;
	}
	else
	{
		q2->urm = new_node;
		new_node->urm = q1;
	}
	return a;
}

//adaugarea unei carti in lista ordonata de carti
book *adauga_carte(book *m, book *new_book)
{
	book *q1, *q2;
	for (q1 = q2 = m; q1 != NULL && strcmp(q1->nume_carte, new_book->nume_carte) < 0; q2 = q1, q1 = q1->urm);
	if (q1 == q2)
	{
		new_book->urm = m;
		m = new_book;
	}
	else
	{
		q2->urm = new_book;
		new_book->urm = q1;
	}
	return m;
}

//				  																      //								
//		      FUNCTIE PENTRU CITIREA DIN FISIER A UNEI LISTE CU SUBLISTA		      //
//																		 		      //

void readDB(char *nume_fisier_autori,char *nume_fisier_carti,autor **lst)
{
	//avand toate datele in un fisier trebuie sa distingem care din ele vor merge in lista (autorii)
	//si care vor face parte din sublista(cartile) unui element din lista
	//structura fisierelor
	//structura fisier autori.txt : nume_autor(sir de caractere), an_nasterii(int), nr_carti(int), varsta(int), is_alive(sir de caractere[maxim 7 caractere])
	//structura fisier carti.txt : nume_autor(sir de caractere), nume_carte(sir de caractere), nr_pagini(int), an_publicare(int)
	autor *a;
	FILE *f = NULL,*g = NULL;
	fopen_s(&f, nume_fisier_autori, "rt");
	fopen_s(&g, nume_fisier_carti, "rt");
	char temp_var[BUFFER], temp_var2[BUFFER], temp_viu[9];//iau si Probabil ca un raspuns pe langa da si nu :))))
	int an, varsta, nr_pc;
	if (f != NULL)
	{
		//verificam daca campurile citite sunt 5,atunci e un autor
		//daca campurile citite sunt 4 atunci e carte(4 pentru ca intra si numele autorului pentru a putea adauga cartea in lista corespunzatoare)
		while (fscanf(f, "%s %d %d %d %s", temp_var, &an, &varsta, &nr_pc, temp_viu) == 5)
		{
			autor *aut = (autor*)malloc(sizeof(autor));
			if (aut == NULL)
			{
				//esuare alocare
				printf("Alocare esuata.\n");
				exit(-1);
			}
			aut->nume_autor = (char*)malloc(strlen(temp_var) + 1);
			if (aut->nume_autor == NULL)
			{
				//esuare alocare
				printf("Alocare esuata.\n");
				exit(-1);
			}
			strcpy(aut->nume_autor, temp_var);
			aut->e_viu = (char*)malloc(strlen(temp_viu) + 1);
			if (aut->e_viu == NULL)
			{
				//esuare alocare
				printf("Alocare esuata.\n");
				exit(-1);
			}
			strcpy(aut->e_viu, temp_viu);
			//copiem restul chestiilor
			aut->an_nasterii = an;
			aut->varsta = varsta;
			aut->nr_carti = nr_pc;
			//verific daca exista deja autorul,daca exista atunci e un autor introdus de la tastatura si ii modific datele 
			a = cauta_autor(*lst, aut->nume_autor);
			if (a == NULL) //nu exista deci e bine , il adaugam
			{
				aut->urm = NULL; //fac urmatorul nod null pentru adaugarea ordonata
				aut->sl = NULL; //ii initializam sublista cu null
				//adaug autorul in lista principala
				*lst = adauga_autor(*lst, aut);
			}
			else
			{
				//deja exista , so doar ii modific valorile cu cele gasite in fisier,adica varsta,anul,nr de carti si daca e viu
				//pt cac numele e lafel
				a->an_nasterii = aut->an_nasterii;
				a->an_nasterii = aut->varsta;
				a->an_nasterii = aut->nr_carti;
				strcpy(a->e_viu, aut->e_viu);
				//sublista ramane lafel numele autorului fiind lafel in sublista deci nu pierdem nimic , asta e doar un fel de anti bug
			}
		}
		fclose(f); //inchid fisieru cu autor
	}
	if (g != NULL)
	{
		while (fscanf(g, "%s %s %d %d", temp_var, temp_var2, &nr_pc, &an) == 4)
		{
			//imi aloc memoria necesara pt noul nod din sublista
			book *b = (book*)malloc(sizeof(book));
			if (b == NULL)
			{
				//esuare alocare
				printf("Alocare esuata.\n");
				exit(-1);
			}
			b->nume_autor = (char*)malloc(strlen(temp_var) + 1);
			if (b->nume_autor == NULL)
			{
				//esuare alocare
				printf("Alocare esuata.\n");
				exit(-1);
			}
			strcpy(b->nume_autor, temp_var);
			b->nume_carte = (char*)malloc(strlen(temp_var2) + 1);
			if (b->nume_carte == NULL)
			{
				//esuare alocare
				printf("Alocare esuata.\n");
				exit(-1);
			}
			strcpy(b->nume_carte, temp_var2);
			b->nr_pagini = nr_pc;
			b->an_publicare = an;
			b->urm = NULL; //initializez cu NULL urmatorul nod pt siguranta
			//caut autorul dupa nume si vad daca exista ,daca nu exista e fisierul creat gresit
			a = cauta_autor(*lst, temp_var);
			if (a != NULL) //daca cumva nu exista autorul atunci afisam o eroare pt idiotul care a creat fisierul :P
			{
				//adaugam in sublista lui cartea lol
				a->sl = adauga_carte(a->sl, b);
			}
		}
		//inchid fisierul cu carti
		fclose(g);
	}
}

//																						//								
//				Functie pentru adaugare de la tastatura a unui autor/carti				//
//							daca autorul exista deja in lista						    //

autor *adauga_lista(autor *l,char* nume_autor)
{
	//caut sa vad daca autorul cautat exista , daca nu il adaug
	autor *searcher = cauta_autor(l,nume_autor);
	int an,nr_pc;
	if (searcher == NULL)
	{
		char temp_viu[9];
		int varsta;
		//nu exista acel autor atunci il pot adauga de la tastatura
		autor *a = (autor*)malloc(sizeof(autor));
		if (a == NULL)
		{
			printf("Alocare esuata\n");
			exit(-1);
		}
		a->nume_autor = (char*)malloc(strlen(nume_autor) + 1);
		if (a->nume_autor == NULL)
		{
			printf("Alocare esuata\n");
			exit(-1);
		}
		strcpy(a->nume_autor,nume_autor);
		printf("An nasterii : ");
		scanf("%d", &an);
		printf("Varsta : ");
		scanf("%d", &varsta);
		printf("Carti scrise : ");
		scanf("%d", &nr_pc);
		printf("E inca viu ? : ");
		scanf("%s", temp_viu);
		a->e_viu = (char*)malloc(strlen(temp_viu) + 1);
		if (a->e_viu == NULL)
		{
			printf("Alocare esuata\n");
			exit(-1);
		}
		strcpy(a->e_viu, temp_viu);
		a->an_nasterii = an;
		a->varsta = varsta;
		a->nr_carti = nr_pc;
		a->sl = NULL;
		a->urm = NULL;
		//adaug noul autor in lista
		l = adauga_autor(l, a);
	}
	else
	{
		char temp_var[BUFFER];
		book *b = (book*)malloc(sizeof(book));
		if (b == NULL)
		{
			printf("Alocare esuata\n");
			exit(-1);
		}
		b->nume_autor = (char*)malloc(strlen(nume_autor) + 1);
		if (b->nume_autor == NULL)
		{
			printf("Alocare esuata\n");
			exit(-1);
		}
		strcpy(b->nume_autor, nume_autor);
		//daca exista atunci ii adaug in sublista un nou element
		printf("Autorul %s exista deja in lista,se face adaugarea in sublista acestuia pentru o noua carte.\n", b->nume_autor);
		printf("Nume carte : ");
		scanf("%s", temp_var);
		b->nume_carte = (char*)malloc(strlen(temp_var) + 1);
		if (b->nume_carte == NULL)
		{
			printf("Alocare esuata\n");
			exit(-1);
		}
		strcpy(b->nume_carte, temp_var);
		printf("Pagini carte : ");
		scanf("%d", &nr_pc);
		printf("Anul publicatiei : ");
		scanf("%d", &an);
		b->nr_pagini = nr_pc;
		b->an_publicare = an;
		b->urm = NULL;
		//adaug in sublista autorului acu'
		searcher->sl = adauga_carte(searcher->sl, b);
	}
	return l;
}

//								  			//								
//			FUNCTII PENTRU CAUTARE			//
//								  			//

//cauta daca exista elementul in lista dp numele autorului
autor *cauta_autor(autor *l, char *nume_cautat)
{
	autor *cautat = l;
	for (cautat = l; cautat != NULL; cautat = cautat->urm)
	{
		if (strcmp(cautat->nume_autor, nume_cautat) == 0)
		{
			return cautat;
		}
	}
	return NULL;
}

autor *stergere_cu_anume(autor *l, char *nume_autor, char *nume_carte)
{
	autor *n = cauta_autor(l, nume_autor);
	int found = 0;
	if (n != NULL) //l-a gasit
	{
		book *b1, *b2;
		for (b1 = b2 = n->sl; b1 != NULL && strcmp(b1->nume_carte,nume_carte) != 0; b2 = b1, b1 = b1->urm);
		if (b1 != NULL && strcmp(b1->nume_carte, nume_carte) == 0)
		{
			found = 1;
			if (b1 == b2) 
			{
				n->sl = n->sl->urm;
				free(b1->nume_carte);
				free(b1->nume_autor);
				free(b1);
			}
			else
			{
				b2->urm = b1->urm;
				free(b1->nume_carte);
				free(b1->nume_autor);
				free(b1);
			}
		}
	}
	if (found == 1)
	{
		printf("Cartea %s a fost stearsa cu succes din sublista autorului %s.\n", nume_carte, nume_autor);
	}
	else
	{
		printf("Cartea %s nu a fost gasita in sublista autorului %s.\n", nume_carte,nume_autor);
	}
	//returnam lista la final
	return l;
}
//cauta daca exista elementul in sublista dp numele cartii
book *cauta_carte(autor *l, char *nume_cautat)
{
	book *cautat = l->sl;
	for (cautat = l->sl; cautat != NULL; cautat = cautat->urm)
	{
		if (strcmp(cautat->nume_carte, nume_cautat) == 0)
		{
			return cautat;
		}
	}
	return NULL;
}

//cautare conditionata a unui anumit autor
//afiseaza toti autori cu un nr de carti mai mare de x
void cautare_conditionat(autor *a, int nr_carti)
{
	autor *cNode = a;
	int found = 0;
	for (cNode = a; cNode != NULL; cNode = cNode->urm)
	{
		if (cNode->nr_carti >= nr_carti)
		{
			//afisare informatii despre autor
			printf("| Nume autor : %s | Anul nasterii : %d | Varsta : %d | Nr.carti : %d | E viu : %s |\n", cNode->nume_autor, cNode->an_nasterii, cNode->varsta, cNode->nr_carti, cNode->e_viu);
			//afisare sublista autorului
			printBooks(cNode);
			found = 1;
		}
	}
	if (found == 0)
	{
		printf("Nu a fost gasit nici un autor care sa aiba un nr egal sau mai mare de carti cu %d.\n", nr_carti);
	}
}

//																			//								
//			    FUNCTII PENTRU UPDATAREA LISTEI SI A SUBLISTEI			    //
//							IN FISIERE										//

void updateFisiere(char *f1, char *f2, autor *l)
{
	FILE *f = NULL, *g = NULL;
	//updatam deci scriem peste
	fopen_s(&f, f1, "wt");
	fopen_s(&g, f2, "wt");
	//nodurile cu care trecem prin lista si subliste
	autor *nod = l;
	book *nod_b = l->sl;
	for (nod = l; nod != NULL; nod = nod->urm)
	{
		//scriem autorul in fisierul cu autori
		fprintf(f, "%s %d %d %d %s\n",nod->nume_autor, nod->an_nasterii, nod->varsta, nod->nr_carti, nod->e_viu);
		for (nod_b = nod->sl; nod_b != NULL; nod_b = nod_b->urm)
		{
			//scriem cartile in fisierul pt carti
			fprintf(g, "%s %s %d %d\n", nod_b->nume_autor, nod_b->nume_carte, nod_b->nr_pagini, nod_b->an_publicare);
		}
	}
	//inchidem fisierele , lucru important
	fclose(f);
	fclose(g);
}

//																			//								
//			    FUNCTII PENTRU AFISAREA LISTEI SI A SUBLISTEI			    //
//																			//

//functie ce afiseaza lista completa
void afisareLista(autor *a)
{
	autor *temp = a;
	book *b_temp = a->sl;
	for (temp = a; temp != NULL; temp = temp->urm)
	{
		//afisare informatii autor
		printf("| Nume autor : %s | Anul nasterii : %d | Varsta : %d | Nr.carti : %d | E viu : %s |\n",temp->nume_autor,temp->an_nasterii,temp->varsta,temp->nr_carti,temp->e_viu);
		//afisarea sublistei autorului
		printBooks(temp);
		printf("\n");
	}
}

//functie ce afiseaza sublista de carti pentru un anumit autor
void printBooks(autor *a)
{
	book *b = a->sl;
	printf("--------------------  Carti  -----------------------------\n");
	for (b = a->sl; b != NULL; b = b->urm)
	{
		printf("Nume carte : %s | Nr. de pagini : %d | An publicatie : %d\n", b->nume_carte, b->nr_pagini, b->an_publicare);
	}
	printf("----------------------------------------------------------\n");
}

//																			//								
//			    FUNCTII PENTRU STERGEREA LISTEI SI A SUBLISTEI			    //
//	

//functie ce sterge un autor din lista
autor *sterge_autor(autor *l,char *nume)
{
	autor *q1, *q2;
	//merg prin lista si caut autorul pe care vreau sa il sterg dp nume
	for (q1 = q2 = l; q1 != NULL && strcmp(q1->nume_autor, nume) != 0; q2 = q1, q1 = q1->urm); 
	//acum verific daca am gasit nodul cautat
	if (q1 != NULL && strcmp(q1->nume_autor, nume) == 0)
	{
		//intai ii eliberez memoria din sublista dp sterg nodul lui in sine
		//astfel nu sunt leak-uri de memorie
		DestroySublist(&q1->sl);
		if (q1 == q2)
		{
			//e la coada listei, atunci scrie peste el
			l = l->urm;
		}
		else
		{
			//altfel nodul din fata(urm din nodul ala) lui o sa fie egal cu nodul care urmeaza dp el
			q2->urm = q1->urm;
		}
		//eliberam memoria
		printf("Autorul %s a fost sters din lista.\n", q1->nume_autor);
		free(q1->nume_autor);
		free(q1);
	}
	else
	{
		printf("Nu exista nici un autor cu numele %s in lista.\n", nume);
	}
	return l;
}

//functie pentru a sterge o carte din sublista, in cazul de fata o sa sterg cartea din toate sublistele in care ea exista
//daca e 1 singura sterg si autorul
autor *sterge_carte(autor *l, char *nume_cautat)
{
	autor *q1, *q2;
	book *b1, *b2;
	int found = 0;
	for (q1 = q2 = l; q1 != NULL; q2 = q1,q1 = q1->urm) //merg prin lista
	{
		//merg prin sublista autorului si caut daca are cartea pe care vreau eu sa o sterg
		for (b1 = b2 = q1->sl; b1 != NULL && strcmp(b1->nume_carte, nume_cautat) != 0; b2 = b1, b1 = b1->urm); 
		//bun am gasit-o acm facem stergerea
		if (b1 != NULL && strcmp(b1->nume_carte, nume_cautat) == 0)
		{
			found = 1;
			if (b1->urm == NULL) //daca nodul e la final
			{
				//daca urmatorul nod e null atunci e curul listei
				//in varianta asta din pacate nu merge eliberat nodul din lista(autorul) pentru ca q1 inca continua sa mearga prin lista
				//iar daca il eliberez atunci nu mai poate continua sa caute
				DestroySublist(&q1->sl);
				if (q1 == q2)
					l = l->urm;
				else
					q2->urm = q1->urm;
				printf("Autorul %s a fost sters din lista.\n", q1->nume_autor);
				free(q1->nume_autor);
			}
			else if (b1 == b2) //daca acesta e la inceput 
			{
				q1->sl = q1->sl->urm;
				free(b1->nume_carte);
				free(b1->nume_autor);
				free(b1);
			}
			else
			{
				b2->urm = b1->urm;
				free(b1->nume_carte);
				free(b1->nume_autor);
				free(b1);
			}
		}
	}
	if (found == 1)
	{
		printf("Cartea %s a fost stearsa cu succes din toate sublistele.\n", nume_cautat);
	}
	else
	{
		printf("Cartea %s nu a fost gasita in nici o sublista.\n", nume_cautat);
	}
	//returnam lista la final
	return l;
}

//																		//								
//			FUNCTII PENTRU DISTRUGEREA LISTEI SI A SUBLISTEI			//
//																		//

//eliberarea memorie din lista de autori / stergerea completa a listei
void DestroyList(autor **a)
{
	autor *aux;
	while (*a)
	{
		aux = *a; //salvez nodul pe care vreu sa il sterg
		*a = aux->urm;
		//eliberez memoria pt sirul de caractere ,sublista si nodul din lista
		free(aux->nume_autor);
		//stergi si sublista pentru o eliberare corecta
		DestroySublist(&aux->sl);
		//eliberez nodul in sine
		free(aux);
	}
	//setez capul pe null
	*a = NULL;
}

//eliberarea memorie din lista de carti
void DestroySublist(book **m)
{
	book *aux;
	while (*m)
	{
		aux = *m; //salvez nodul pe care vreu sa il sterg
		*m = aux->urm;
		//eliberez memoria
		free(aux->nume_autor);
		free(aux->nume_carte);
		//eliberez nodul in sine
		free(aux);
	}
	//setez capul pe null
	*m = NULL;
}

//meniu' principal 
void menu()
{
	printf("\n1)Incarca baza de date\n");
	printf("2)Afisare autori\n");
	printf("3)Afiseaza toti autorii ce au un nr de carti mai mare sau egal cu cel introdus de la tastatura\n");
	printf("4)Adauga autor sau carte daca acesta exista\n");
	printf("5)Sterge autor\n");
	printf("6)Sterge carte din subliste\n");
	printf("7)Updatare fisiere cu datele din lista curenta\n");
	printf("8)Iesire\n");
	printf("Optiunea ta : ");
}

//sth important I guess , ¯\_(ツ)_/¯
int main()
{
	int choose;
	autor *a = NULL;
	char temp_sir[BUFFER];
	char t_s[BUFFER];
	int nr_c;
	do
	{
		menu();
		scanf_s("%d", &choose);
		switch (choose)
		{
		case 1 :
			if (a != NULL)
			{
				printf("Baza de date a fost deja incarcata in lista.\n");
			}
			else
			{
				readDB(FILE_NAME, FILE_NAME2, &a);
				printf("Baza de date a fost incarcata cu succes in lista.\n");
			}
			break;
		case 2 :
			if (a != NULL)
			{
				afisareLista(a);
			}
			else
			{
				printf("Baza de date nu a fost inca incarcata in lista.\n");
			}
			break;
		case 3 :
			if (a != NULL)
			{
				printf("Nr de carti pt afisare : ");
				scanf("%d", &nr_c);
				cautare_conditionat(a, nr_c);
			}
			else
			{
				printf("Baza de date nu a fost inca incarcata in lista.\n");
			}
			break;
		case 4 : 
			if (a != NULL)
			{
				printf("Numele autorului adaugat : ");
				scanf("%s", temp_sir);
				a = adauga_lista(a, temp_sir);
			}
			else
			{
				printf("Baza de date nu a fost inca incarcata in lista.\n");
			}
			break;
		case 5:
			if (a != NULL)
			{
				printf("Numele autorului de sters : ");
				scanf("%s", temp_sir);
				a = sterge_autor(a, temp_sir);
			}
			else
			{
				printf("Baza de date nu a fost inca incarcata in lista.\n");
			}
			break;
		case 6:
			if (a != NULL)
			{
				printf("Numele autor de sters : ");
				scanf("%s", temp_sir);
				printf("Numele carte din sublista autorului %s : ",temp_sir);
				scanf("%s", t_s);
				//a = sterge_carte(a, temp_sir);
				a = stergere_cu_anume(a,temp_sir,t_s);
			}
			else
			{
				printf("Baza de date nu a fost inca incarcata in lista.\n");
			}
			break;
		case 7:
			if (a != NULL)
			{
				updateFisiere(FILE_NAME, FILE_NAME2,a);
				printf("Fisierele au fost updatate cu succes.\n");
			}
			else
			{
				printf("Baza de date nu a fost inca incarcata in lista.\n");
			}
			break;
		case 8 :
			//distruge lista si elibereaza memoria
			DestroyList(&a);
			//iesire cu succes
			exit(0);
			break;
		default:
			choose = 8;
			break;
		}
	} while (choose != 8);
	return 0;
}
//Gata -.- ~~~
//
//    E ora ( #include <math.h> #define PI 3.14 )[ 5:(int)floor(PI * 10) ](Wtf I'm doing with my life .. ?!) dimineata cand fking termin programul..
//	  Fml trebuia sa dorm la ora asta ...   
//    Da nu o sa dorm ci o sa desenez o floare , lol :
//
//                                              :. ,..
//                                            .' :~.':_.,
//                                          .'   ::.::'.'
//                                         :     ::'  .:
//                                       `.:    .:  .:/
//                                        `::--.:'.::'
//                                          |. _:===-'
//                                         / /
//                        ,---.---.    __,','
//                       (~`.  \   )   )','.,---..
//                        `v`\ | ,' .-'.:,'_____   `.
//                            )|/.-~.--~~--.   ~~~-. \
//                          _/-'_.-~        ""---.._`.|
//                     _.-~~_.-~                    ""'
//              _..--~~_.(~~
//   __...---~~~_..--~~
//,'___...---~~~
//
//