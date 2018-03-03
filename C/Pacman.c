#include <stdio.h>

#define MIN_RESTRICTION 1
#define MAX_RESTRICTION 80
#define MAX_OBSTACLES 3

struct obstacol
{
    int l,c;
    char m;
};
void table(int n,int m,int x,int y,char player,struct obstacol o[3],int p)
{
    int i = 0,j = 0,k = 0;
    //afisam tabla , playerul si obstacolele dupa ce am prelucrat-o
    for(i = 0;i < n+2;i++)
    {
        for(j = 0;j < m+2;j++)
        {
            if(i == y && j == x)
            {
                printf("%c",player);
            }else{
                int found = 0;
                if(i > 0 && i < n+1)
                {
                    if(j > 0 && j < m+1)
                    {
                        for(k = 0;k < p;k++)
                        {
                            if(i == o[k].l && j == o[k].c)
                            {
                                printf("x");
                                found = 1;
                                break;
                            }
                        }
                        if(found == 0)
                            printf(" ");
                    }else{
                        printf("*");
                    }
                }else{
                     printf("*");
                }
            }
        }
        printf("\n");
    }
}
void checkInput(int n,int m,int x,int y,char c,struct obstacol o[3],int p,int turn)
{
    char current_skin = c;
    int finish = 0,nr_turn = turn,i = 0,movement;
    nr_turn++;
    //obstacole mobile dp 2 ture
    movement = getchar();
    switch(movement)
    {
        case 'w' :
            y--;
            if(y < MIN_RESTRICTION)
              y = MIN_RESTRICTION;
            else
              current_skin = '^';
            break;
        case 's' :
            y++;
            if(y > n)
              y = n;
            else
              current_skin = 'v';
            break;
        case 'a' :
            x--;
            if(x < MIN_RESTRICTION)
              x = MIN_RESTRICTION;
            else
              current_skin = '<';
            break;
        case 'd' :
            x++;
            if(x > m)
              x = m;
            else
              current_skin = '>';
            break;
        case 'q' :
            finish = 1;
            break;
        default :
            break;
    }
    //miscam obstacolul in fctie de x
    if(nr_turn-1 == 3)
    {
        nr_turn = 0;
        //modificam pozitia obstacolelor care sunt mobile
        for(i = 0;i < p;i++)
        {
            if(o[i].m == 'm')
            {
                //daca e obstacol mobil il mutam in functie de ecuatie
                if(x == o[i].c)
                {
                    if(o[i].c + 1 > m)
                    {
                        o[i].c--;
                    }
                    else if(o[i].c - 1 < 1)
                    {
                        o[i].c++;
                    }
                }
                if(y == o[i].l)
                {
                    if(o[i].l + 1 > n)
                    {
                        o[i].l--;
                    }
                    else if(o[i].l - 1 < 1)
                    {
                        o[i].l++;
                    }
                 }
                if(x < o[i].c)
                    o[i].c--;
                else if(x > o[i].c)
                    o[i].c++;
                if(y < o[i].l)
                    o[i].l--;
                else if(y > o[i].l)
                    o[i].l++;
            }
        }
    }
    for(i = 0;i < p;i++)
    {
        if(y == o[i].l && x == o[i].c)
        {
            finish = 1;
            printf("GAME OVER\n");
            break;
        }
    }
    if(movement != '\n' && finish != 1)
    {
        table(n,m,x,y,current_skin,o,p);
    }
    if(x == m && y == n && !finish)
    {
        printf("GAME COMPLETED\n");
        finish = 1;
    }
    if(finish != 1)
    {
        checkInput(n,m,x,y,current_skin,o,p,nr_turn);
    }
}
int main()
{
    struct obstacol obs[3];
    int N,M,x,y,p,i;
    scanf("%d %d %d %d %d",&N,&M,&x,&y,&p);
    //restrictii pt m si n
    if(N < MIN_RESTRICTION)
    {
        N = MIN_RESTRICTION;
    }
    else if(N > MAX_RESTRICTION)
    {
        N = MAX_RESTRICTION;
    }
    if(M < MIN_RESTRICTION)
    {
        M = MIN_RESTRICTION;
    }
    else if(M > MAX_RESTRICTION)
    {
        M = MAX_RESTRICTION;
    }
    //restrictii pt x si y
    if(x < MIN_RESTRICTION)
    {
        x = MIN_RESTRICTION;
    }
    else if(x > M)
    {
        x = M;
    }
    if(y < MIN_RESTRICTION)
    {
        y = MIN_RESTRICTION;
    }
    else if(y > N)
    {
        y = N;
    }
    //restrictii pt p
    if(p < 0)
    {
       p  = 0;
    }
    else if(p > MAX_OBSTACLES)
    {
        p = MAX_OBSTACLES;
    }
    //declarare pt obstacole
    for(i = 0;i < p;i++)
    {
      scanf("%d %d %c",&obs[i].l,&obs[i].c,&obs[i].m);
      //restrictii obstacole
      if(obs[i].l < MIN_RESTRICTION)
      {
          obs[i].l = MIN_RESTRICTION;
      }
      else if(obs[i].l > N)
      {
          obs[i].l = N;
      }
      if(obs[i].c < MIN_RESTRICTION)
      {
          obs[i].c = MIN_RESTRICTION;
      }
      else if(obs[i].c > M)
      {
          obs[i].c = M;
      }
    }
    //afisam tabla
    table(N,M,x,y,'v',obs,p);
    //incepem sa citim caracterele
    checkInput(N,M,x,y,'v',obs,p,0);
    return 0;
}