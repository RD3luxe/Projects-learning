/*
** DESCRIPTION:
++ SWAPING 2 NUMBERS USING XOR OPERATPOR
++ XOR RULE : 1+0 OR 0+1 = 1, 1+1 OR 0+0 = 0
*/
#include <stdio.h>
#include <stdlib.h> //biblioteca pt atoi si itoa !!!
#define BIT_NUM 8 //8 biti = numarul maxim pe care il poate afisa 255

//afisarea directa a unui nr in binar pt x biti dat de BIT_NUM
void printBinary(unsigned int x)
{
    int i = 0;
    for(i = BIT_NUM-1;i >= 0;i--)
    {
        printf("%d",((x>>i)&1) == 1? 1:0);
    }
    printf("\n");
}
//conversia unui nr in binar
char* binaryConvert(unsigned int k)
{
    char *buffer;
    buffer = (char*)malloc(sizeof(char) * 65);
    itoa(k,buffer,2);
    return buffer;
}
//alternativa care transforma numarul in int nu string
unsigned int binaryConvert2(unsigned int k)
{
    char *buffer;
    buffer = (char*)malloc(sizeof(char) * 65);
    itoa(k,buffer,2);
    return atoi(buffer);
}
int main()
{
    unsigned int a,b;
    scanf("%u",&a);
    scanf("%u",&b);
    printf("\nBefore swaping : a = %u(%s) , b = %u(%s)\n\n",a,binaryConvert(a),b,binaryConvert(b));
    a = a ^ b;
    b = a ^ b;
    a = a ^ b;
    printf("After swaping : a = %u(%u) , b = %u(%u)\n\n",a,binaryConvert2(a),b,binaryConvert2(b));
    printf("a in binar(%d biti) : ",BIT_NUM);
    printBinary(a);
    printf("b in binar(%d biti) : ",BIT_NUM);
    printBinary(b);
    return 0;
}
