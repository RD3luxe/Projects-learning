class Arbore
{
    private final int capacitateArbore = 100;  // capacitatea arborelui
    public int indparinte[] = new int[capacitateArbore];
    public int valchei[] = new int[capacitateArbore];
    public int contor = 0;                     // numarul de noduri existente, adica introduse in arbore
   
    public Arbore()
    {
        System.out.println("Initializam vectorii cu -1 pentru un arbore de 100 de noduri.");    
        for (int i = 0;i < capacitateArbore;i++)
        {
            indparinte[i] = -1;
            valchei[i] = -1;
        }
    }
   
    void search(int cheie)
    {
        boolean found = false;
        for(int i = 0;i < capacitateArbore;i++)
        {
            if(valchei[i] == cheie)
            {
                found = true;
                System.out.println("Elementul "+cheie+" se afla in arbore.");
                break;
            }
        }
        if(!found)
        {
            System.out.println("Elementul "+cheie+" NU se afla in arbore.");
        }
    }
   
    int add(int cheie,int indiceParinte)
    {
        // Adaug radacina la indexul 0
        if(indiceParinte == -1 && contor == 0)
        {
            indparinte[0] = indiceParinte;
            valchei[0] = cheie;
            contor++;
            System.out.println("Am adaugat radacina cu cheia " + cheie );
            return -1;
        }
        if(indiceParinte > contor)
        {
        	System.out.println("Acel index de parinte nu exista " + indiceParinte );
        	return -1;
        }
        // Pentru celelalte noduri adaug normal
        for (int i = 1; i < capacitateArbore; i++)
        {
            if (valchei[i] == cheie)
            {
                System.out.println("Cheia " + cheie + " exista deja in arbore.");
                return -1;
            }
            if (valchei[i] == -1 && indparinte[i] == -1)//i == contor)
            {
                indparinte[i] = indiceParinte;
                valchei[i] = cheie;
                System.out.println("Am adaugat cheia " + cheie + " la parintele " + indiceParinte);
                contor++;
                return indiceParinte;
            }
        }
        return -1;
    }    
 
    void delete(int cheie)
    {
        boolean search = false;
        for(int i = 0;i < capacitateArbore;i++)
        {
            if(valchei[i] == cheie)
            {
                search = true;
                //System.out.println("INDEX : "+i);
                for(int j = 0;j < capacitateArbore;j++)
                {
                	//if(indparinte[j] != -1)
                	//System.out.println(cheie +" == "+indparinte[j]+" : "+valchei[indparinte[j]]);
                    if(indparinte[j] != -1 && cheie == valchei[indparinte[j]])
                    {
                        // Stergem toate 'crengile' ce atarna
                        delete(valchei[j]);
                        valchei[j] = -1;
                        indparinte[j] = -1;
                        contor--;
                    }
                }          
                // Stergem si nodu curent
                valchei[i] = -1;
                indparinte[i] = -1;
                contor--;
            }
        }
        if(!search)
        {
            System.out.println("Elementul "+cheie+" nu a fost gasit in arbore.");
        }else{
            System.out.println("Elementul "+cheie+ " a fost sters.");
        }
    }
   
    // Parcurge
    void printTree()
    {        
        System.out.println("Radacina este : "+valchei[0]);
        for(int i = 1;i < capacitateArbore;i++)
        {
            if(valchei[i] != -1)
            {
                System.out.println("Nodul "+i+" are cheia cu valoare "+valchei[i]+" si are ca parinte pe "+valchei[indparinte[i]]+ " cu indexul "+ indparinte[i]);
            }
        }
    }
   
    public static void main(String args[])
    {
      Arbore arb = new Arbore();
      System.out.println("Program Arbore Generic");
      arb.add(15, -1); //0 - > Radacina
      arb.add(9, 0); //1
      arb.add(2, 0); //2
      arb.add(4, 1); //3
      arb.add(8, 3); //4
      arb.add(7, 1); //5
      arb.add(72,1); //6
      arb.add(6, 2); //7
      arb.search(4);
      arb.printTree();
      arb.delete(2);
      arb.printTree();
      arb.add(10,5);
      arb.add(11,5);
      arb.add(15,5);
      arb.printTree();
      arb.search(10);
    }
}