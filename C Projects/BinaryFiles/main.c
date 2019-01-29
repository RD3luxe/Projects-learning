#include <stdio.h>
#include<stdlib.h>

#define FILE_NAME  "elevi.bin"
#define NEW_FILE   "new_elevi.bin"

#define MAX 60
typedef struct elev
{
    char name[MAX],prename[MAX];
    float medie;
}elev;

void add_data(char *fName1)
{
    FILE *f = fopen(fName1,"ab");
    elev data;
    printf("Nume : ");
    scanf("%s",data.name);
    printf("Prenume : ");
    scanf("%s",data.prename);
    printf("Medie : ");
    scanf("%f",&data.medie);
    if(f != NULL)
    {
        //set the pointer to the end and write
        fseek(f,sizeof(elev),SEEK_END);
        fwrite(&data,sizeof(elev),1,f);
        fclose(f);
    }else{
        printf("File %s not found.\n",fName1);
        exit(1);
    }
}
void readFile(char *fName1,elev *e,int *nr)
{
        FILE *f = fopen(fName1,"rb");
        if(f != NULL)
        {
            //set the pointer to the start
            fseek(f,0,SEEK_SET);
            while(!feof(f))
            {
                fread(&e[*nr],sizeof(elev),1,f);
                (*nr)++;
            }
            fclose(f);
        }else{
            printf("File %s not found.\n",fName1);
            exit(1);
        }
}
void writeData(char *fName1,char *fName2)
{
        int i;
        elev data;
        FILE *f ,*g;
        f = fopen(fName1,"rb");
        g = fopen(fName2,"wb");
        if(f != NULL)
        {
            //set the pointer to the start
            fseek(f,sizeof(elev)*2,SEEK_SET);//go to the 3rd stuff in file shit
            for(i = 0;i <= (5-3);i++)
            {
                 fread(&data,sizeof(elev),1,f);
                 fwrite(&data,sizeof(elev),1,g);
                 //fseek(f,sizeof(elev),SEEK_CUR);
            }
            fclose(f);
            fclose(g);
            printf("Scris de la 3 la 5 in %s.\n",fName2);
        }else{
            printf("File %s not found.\n",fName1);
            exit(1);
        }
}
void show_data(elev *e,int cnt)
{
    int i = 0;
    for(i = 0;i < cnt-1;i++)
    {
        printf("|| Nume %s | Prenume %s | Medie %.2f ||\n",(e+i)->name,(e+i)->prename,(e+i)->medie);
    }
    printf("\n");
}
void menu(int *opt)
{
    printf("\n1)Add data\n");
    printf("2)Load data\n");
    printf("3)Show data\n");
    printf("4)Copy from 3-5 to another file\n");
    printf("5)Show new data\n");
    printf("6)Exit\n");
    printf("Your option : ");
    scanf("%d",opt);
}
int main()
{
    elev elvs[50];
    elev elvs2[3];
    int nr2 = 0;
    int nr = 0,option;
    do
    {
        menu(&option);
        switch(option)
        {
            case 1 :
                add_data(FILE_NAME);
                break;
            case 2 :
                 readFile(FILE_NAME,elvs,&nr);
                 printf("Data from %s binary file was read.\n",FILE_NAME);
                 break;
            case 3 :
                if(nr == 0 )
                    printf("Mai intai tr citite datele\n");
                else
                    show_data(elvs,nr);
                break;
            case 4 :
                writeData(FILE_NAME,NEW_FILE);
                break;
            case 5 :
                readFile(NEW_FILE,elvs2,&nr2);
                show_data(elvs2,nr2);
                break;
            case 6 :
                option = 0;
            default :
                exit(1);
                break;
        }
    }while(option != 0);
    return 0;
}
