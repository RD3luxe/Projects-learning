/*
** DESCRIPTION:
++ TOGGLES THE Nth BIT OF A BINARY NUMBER
++ DACA BIT-UL E 1 DEVINE 0 SI DACA E 0 DEVINE 1
*/
#include <stdio.h>
#include <stdlib.h>
#define BIT_NUM 8

void printBinary(unsigned int x)
{
    int i = 0;
    for(i = BIT_NUM-1;i >= 0;i--)
    {
        printf("%d",((x>>i)&1) == 1? 1:0);
    }
    printf("\n");
}
unsigned int toggle(unsigned int x,unsigned int poz)
{
    unsigned int nr = 0;
    nr = x ^ (1<<poz);
    return nr;
}
int main()
{
    unsigned int a,nr2,poz;
    scanf("%u",&a);
    scanf("%u",&poz);
    nr2 = toggle(a,poz);
    printf("Nr este %u ",a);
    printBinary(a);
    printf("Nr modificat la pozitia %u este %u ",poz,nr2);
    printBinary(nr2);
    return 0;
}
