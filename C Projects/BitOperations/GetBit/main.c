/*
** DESCRIPTION:
++ GET THE Nth BIT FROM A NUMBER
++ RETURNEAZA DACA BIT-UL DE LA POZITIA CAUTATA ESTE 1 SAU 0
*/
#include <stdio.h>
#include <stdlib.h>
#define BIT_NUM 8

void printBinary(unsigned int nr)
{
    int i = 0;
    for(i = BIT_NUM-1;i >= 0;i--)
    {
        printf("%d",((nr>>i)&1) == 1 ? 1:0);
    }
    printf("\n");
}
//verifica daca bitul de la pozitia poz e 1 sau 0
unsigned int checkBit(unsigned int n,unsigned int poz)
{
    return ((n>>poz)&1) == 1? 1:0;
}
int main()
{
    unsigned int a,p;
    scanf("%u",&a);
    scanf("%u",&p);
    printBinary(a);
    printf("%u",checkBit(a,p));
    return 0;
}
