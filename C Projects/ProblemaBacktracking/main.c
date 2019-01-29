#include <stdio.h>

#define CULORI_NUM 6    //nr de culor
#define MAX_BOUND 100   //nr masim de solutii tinute in vector

//problema este simpla trebuie sa generam
//Aranjamente de n luate cate 5 (numarul de culori ce trebuie combinate)
//stiind ca tr cel putin n culori vom face aranjamentele pana ce n-ul va ajunge sa fie egal cu 5

int n;  //nr de culori combinate
int st[MAX_BOUND]; //variabila globala , vector de solutii
char *nume_culori[] = { "rosu" , "galben" ,"albastru" ,"verde" ,"alb" ,"portocaliu" }; //un vector de siruri de caractere cu numele culorilor

void printSol()
{
    int i = 0;
    for(i = 1;i<= n;i++)
    {
        printf("%s ",nume_culori[st[i]]);
    }
    printf("\n");
}

int valid(int k)
{
    int i = 1;
    for(i = 1;i < k;i++)
    {
        if(st[i] == st[k] ||
           (st[i] == 3 || st[k] == 3) ||
           ((st[i] == 2 && st[i+1] == 0) ||
            (st[k] == 2 && st[k+1] == 0)) )
            return 0;
    }
    return 1;
}

void backtrack(int k)
{
    int i = 0;
    if(k > n)
    {
        printSol();
    }
    else
    {
        for(i = 0;i < CULORI_NUM;i++)
        {
            st[k] = i;
            if(valid(k))
            {
                backtrack(k+1);
            }
        }
    }
}

int main()
{
    //un array de siruri de caractere in care avem numele tuturor culorilor
    //noi vom verifica indexul si vom sorta dupa indexi
    // 0 - rosu, 1- galben, 2 - albastru , 3 - verde(o sa il ignoram) ,4- alb, 5 - portocaliu
    //nu poate exista 3 si 2,0(albastru,rosu)
    scanf("%d",&n);
    int i = 0,p = n;
    for(i = 1;i <= CULORI_NUM - p;i++)
    {
        backtrack(1);
        n++;
    }
    return 0;
}
