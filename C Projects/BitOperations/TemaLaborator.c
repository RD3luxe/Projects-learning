/*
ENUNTURI : 
1. Se citesc 2 numere de la tastatura. Sa se genereze al treilea numar care are bitul 1 pe pozitiile pe care primul numar are 0 si al doilea are 1. In restul pozitiilor al treilea numar are bitul pe 0.

2. Se citesc 3 numere de la tastatura. Sa se genereze al 4-lea numar care are 1 pe pozitiile pe care toti cei 3 au 1 si 0 in rest.

3. Se citeste un numar de la tastatura. Sa se nege toti bitii lui de pe pozitiile pare.

4. Se citeste un numar a de la tastatura si un alt numar, n. Sa se seteze pe 0 toti bitii de la pozitia 0 la pozitia n din numarul a.

5. Se citeste de la tastatura un numar. Daca bitii de pe pozitiile 0,2 si 5 sunt 1 sa se faca 0.
*/
#include <stdio.h>
#include <stdlib.h>

void printBits(unsigned int num)
{
   int bit = 0;
   for(bit = 7;bit >=0 ; bit--)
   {
      printf("%d", (num&1<<bit)? 1:0);
   }
   printf("\n");
}
int main()
{
    //1
    unsigned int nr1,nr2,nr3;
    printf("P1)\n");
    printf("Primul numar : ");
    scanf("%d",&nr1);
    printf("Al 2-lea numar : ");
    scanf("%d",&nr2);
    printBits(nr1);
    printBits(nr2);
    nr3 = ~nr1&nr2;
    printBits(nr3);
    /*
    0001 0010
    0000 1010
    0000 1000
    */
    //2
    unsigned int nr4;
    printf("P2)\n");
    printf("Primul numar : ");
    scanf("%d",&nr1);
    printf("Al 2-lea numar : ");
    scanf("%d",&nr2);
    printf("Al 3-lea numar : ");
    scanf("%d",&nr3);
    nr4 = nr1&nr2;
    nr4 &= nr3;
    printBits(nr1);
    printBits(nr2);
    printBits(nr3);
    printBits(nr4);
    /*
    1000 1001
    0100 1001
    0001 1001
    0000 1001
    */
    //3
    printf("P3)\n");
    printf("Numar : ");
    scanf("%d",&nr1);
    printBits(nr1);
    nr1 ^= 0x55;
    printBits(nr1);
    /*
    0100 1010
    0101 0101
    0001 1111
    */
    //4
    int n,i;
    printf("P4)\n");
    printf("Numar : ");
    scanf("%d",&nr1);
    printf("N : ");
    scanf("%d",&n);
    printBits(nr1);
    for(i = 0; i <= n;i++)
    {
        nr1 = nr1 & ~(1 << i);
    }
    printBits(nr1);
    /*
    0100 1001
    4
    0100 0000
    */
    //5
    printf("P5)\n");
    printf("Numar : ");
    scanf("%d",&nr1);
    printBits(nr1);
    nr1 = nr1&(~37);
    printBits(nr1);
    /*
    1010 0011
   ~0010 0101
    1000 0010
    */
    return 0;
}
