#include <stdio.h>
#include <stdlib.h> //pentru itoa
#include <string.h> //pentru strlen
#define BIT_NUM 8

void printBinary(unsigned int n)
{
    int i = 0;
    for(i = BIT_NUM-1;i >= 0;i--)
    {
        printf("%d",((n>>i)&1) == 1? 1:0);
    }
    printf("\n");
}
//sterge(inlocuieste cu 0) primul bit de 1 intalnit de la MSB(0)
void strip_last_set_bit(unsigned int *a)
{
    *a = *a & (*a-1);
}
//verifica daca un numar e par sau impar
int is_par(unsigned int a)
{
    return (a & 1) ? 0:1;
}
//shiftarea la stanga/dreapta pt inmultirea/impartirea cu 2
void operatii(unsigned int a)
{
    printf("Numarul %u inmultit cu 2 este : %u\n",a,a<<1);
    printf("Numarul %u impartit cu 2 este : %u\n",a,a>>1);
}
//verifica daca numarul poate fi scris sub forma unei puteri a lui 2 (8 = 2^3)
//explicatie : toate numerele care sunt puteri ale lui 2 au un singur bit setat pe 1
//exemplu 16 = 2^4 : 10000-1 = 01111 = 15 => 10000 & 01111 = 0
int isPowerOfTwo(unsigned int x)
{
    return x && (!(x & (x-1)));
}
//verifica daca biti alterneaza precum 101(nr 10)
int alternateOrder(unsigned int a)
{
    //xor nr a cu a siftat cu 1 pozitie : 1010 si 0101 facand xor -> 1111(toti biti pe 1 daca e pattern)
    unsigned int n = a ^ (a >> 1);
    return ((n+1) & n) == 0? 1:0;
}
//numara biti de 1 din reprezentarea binara a unui numar
int countSetBits(unsigned int n)
{
    /*
    METODA CLASICA - loop prin toti biti si crestem un contor de fiecare data cand un bit e 1
    METODA Brian Kernighan - informatii aici despre metoda asta https://www.geeksforgeeks.org/count-set-bits-in-an-integer/
    */
    //Metoda Kernighan
    int contor = 0;
    while(n)
    {
        n &= (n-1);
        contor++;
    }
    return contor;
}
//numara numarul de biti de 0 din numar (pentru o dimensiune fixa - cel mai putin semnificativ bit fiind 1)
int countUnsetBits(unsigned int n)
{
    char buffer[65];
    itoa(n,buffer,2);
    return strlen(buffer) - countSetBits(n);
}
//returneaza valoarea de la primul bit de 1 gasit
//exemplu 10 = 1010 => primul bit de 1 e pe pozitia 1 = 2^1 = 2
int lowest_set_bit(int num)
{
    int ret = num & (-num);
    return ret;
}
//seteaza toti biti pe 0 de la LSB pana la bit-ul k
unsigned int clearBitsLSB(unsigned int n,unsigned int k)
{
    //creaza o masca cu primii k biti 1(dreapta la stanga)
    //0001000 - 1 => 15 = 00001111
    //negam masca ~15 => 11110000
    //acum facem & cu numarul n
    unsigned int mask = ~((1<<(k+1))-1);
    return n & mask;
}
//seteaza toti biti pe 0 de la MSB pana la bit-ul k
unsigned int clearBitsMSB(unsigned int n,unsigned int k)
{
    //creaza o masca cu primii k biti 1(stanga la dreapta)
    //ex k = 4(tr sa setam toti biti e 0 pana
    //primi 4 biti => 16 = 0001000
    //0001000 - 1 => 15 = 00001111
    //acum facem & cu numarul n
    unsigned int mask = (1<<k)-1;
    return n & mask;
}
//main-ul
int main()
{
    unsigned int a,b,k;
    scanf("%u",&a);
    scanf("%u",&k);
    b = a;
    printBinary(a);
    printf("Numarul %u %s.\n",a,is_par(a) == 1? "este par":"nu este par");
    //la impartire va rotunji la cel mai apropiat multiplu de 2
    operatii(a);
    printf("Numarul %u %s.\n",a,isPowerOfTwo(a) == 1? "este putere a lui 2":"nu este putere a lui 2");
    printf("Numarul %u %s.\n",a,alternateOrder(a) == 1? "are un pattern de biti setati":"nu are un pattern de biti setati");
    printf("Numarul %u are %d biti de unu.\n",a,countSetBits(a));
    printf("Numarul %u are %d biti de zero.\n",a,countUnsetBits(a));
    printf("Valoarea de la primul bit de unu este %d\n",lowest_set_bit(a));
    //pentru a face complement de 1/complement de 2 numarul trebuie sa fie cu semn
    //pentru complement de 1 : ~a , Complement de 2 -a sau (~a+1)
    printf("Numarul cu biti de unu stersi pana la poz %u de la lsb : %u\n",k,clearBitsLSB(b,k));
    printBinary(clearBitsLSB(b,k));
    printf("Numarul cu biti de unu stersi pana la poz %u de la msb : %u\n",k,clearBitsMSB(b,k));
    printBinary(clearBitsMSB(b,k));
    printf("Adunare / scadere : \n");
    printBinary(a-1);
    printBinary(a+1);
    printf("Numarul a cu ultimul bit de unu setat pe zero : \n");
    strip_last_set_bit(&a);
    printBinary(a);
    return 0;
}
