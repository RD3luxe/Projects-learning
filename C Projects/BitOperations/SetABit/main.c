/*
** DESCRIPTION:
++ SET THE Nth BIT OF A BINARY NUMBER TO 1 OR 0
*/
#include <stdio.h>
#include <stdlib.h>

//converteste un nr in binar
unsigned int convertBinary(unsigned int n)
{
    char *buffer;
    buffer = (char*)malloc(sizeof(char) * 65);
    itoa(n,buffer,2);
    return atoi(buffer);
}
//seteaza pe 1 bit-ul de la pozitia pos
unsigned int set(unsigned int num,unsigned int pos)
{
    unsigned int nr = 0;
    nr = num | (1 << pos);
    return nr;
}
//seteaza pe 0 bit-ul de la pozitia pos
unsigned int unset(unsigned int num,unsigned int pos)
{
    unsigned int nr = 0;
    nr = num & (~(1 << pos));
    return nr;
}
int main()
{
    unsigned int nr,nr_modificat,poz,poz2;
    scanf("%u",&nr);
    scanf("%u",&poz);
    scanf("%u",&poz2);
    printf("Nr normal : %u (%u)\n",nr,convertBinary(nr));
    nr_modificat = set(nr,poz);
    printf("Nr modificat dp adaugare de bit(1) la poziita %u = %u (%u)\n",poz,nr_modificat,convertBinary(nr_modificat));
    nr_modificat = unset(nr,poz2);
    printf("Nr modificat dp adaugare de bit(0) la pozitia %u = %u (%u)\n",poz2,nr_modificat,convertBinary(nr_modificat));
    return 0;
}
