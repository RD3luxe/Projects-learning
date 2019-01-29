#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "bmp_header.h"

#define BGR_COLORS 3
#define MAX_LENGTH 69

typedef struct {
	struct bmp_fileheader fileheader;
	struct bmp_infoheader bmpinfoheader;
}bitmap_header;

int createBmp(char* input, char *output,int bgrColors[3])
{
    FILE *fp,*out;
    bitmap_header *hp;
    unsigned char *PixelMatrix;
    //Open input file:
    fp = fopen(input, "rb");
    if(fp==NULL){
        printf("Image wasn't found.");
        return 0;
    }
    hp=(bitmap_header*)malloc(sizeof(bitmap_header));
    if(hp==NULL)
        return 0;

    //read the header
    fread(hp, sizeof(bitmap_header), 1, fp);
    PixelMatrix = (unsigned char*)malloc(sizeof(unsigned char)*hp->bmpinfoheader.biSizeImage);
    if(PixelMatrix==NULL){
        printf("The memory necessary was not allocated.");
        return 0;
    }
    //read the pixel matrix
    fseek(fp,sizeof(unsigned char)*hp->fileheader.imageDataOffset,SEEK_SET);
    fread(PixelMatrix,sizeof(unsigned char),hp->bmpinfoheader.biSizeImage, fp);
    //output file
    out = fopen(output, "wb");
    fwrite(hp,sizeof(unsigned char),sizeof(bitmap_header),out);
    int imageIdx;
    for (imageIdx = 0;imageIdx < (int)hp->bmpinfoheader.biSizeImage;imageIdx++)
    {
            int n = PixelMatrix[imageIdx];
            //if it's not white then change it's color and move 2 forward
            if(n != 255)
            {
                fwrite(&bgrColors[0],sizeof(unsigned char),1,out);
                fwrite(&bgrColors[1],sizeof(unsigned char),1,out);
                fwrite(&bgrColors[2],sizeof(unsigned char),1,out);
                imageIdx += 2;
            }else{
                fwrite(&n,sizeof(unsigned char),1,out);
            }
    }
    //close all used files & free all pointers
    fclose(fp);
    fclose(out);
    free(PixelMatrix);
    free(hp);
    return 1;
}
void readInfo(char *fileName)
{
    FILE * fp = fopen(fileName,"rt");
    if(fp == NULL)
    {
        printf("ERROR: Can't open %s file.",fileName);
        exit(1);
    }
    char *bmpName;
    bmpName = malloc(MAX_LENGTH*sizeof(char));
    int bgr[3];
    fscanf(fp,"%s",bmpName);
    fscanf(fp,"%d",&bgr[0]);
    fscanf(fp,"%d",&bgr[1]);
    fscanf(fp,"%d",&bgr[2]);
    char newbmpName[MAX_LENGTH];
    newbmpName[0] = '\0';
    int i = 0;
    char c = bmpName[i];
    while(c != '.')
    {
        newbmpName[i] = bmpName[i];
        i++;
        c = bmpName[i];
    }
    newbmpName[i] = '\0';
    strcat(newbmpName,"_task1.bmp");
    char *path;
    path = malloc(MAX_LENGTH*2 * sizeof(char));
    strcpy(path,"input//captcha_files//");
    strcat(path,bmpName);
    createBmp(path,newbmpName,bgr);
    free(bmpName);
    free(path);
}
int main(void)
{
    readInfo("input.txt");
    return 0;
}
