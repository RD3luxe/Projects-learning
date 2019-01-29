class BinaryTree
{
    private final int capacitateArbore = 100;  // capacitatea arborelui
    public int indparinte[] = new int[capacitateArbore];
    public int valchei[] = new int[capacitateArbore];
    public int contor = 0;                     // numarul de noduri existente, adica introduse in arbore
   
    public BinaryTree()
    {
        System.out.println("Initializam vectorii cu -1 pentru un arbore de 100 de noduri.");    
        for (int i = 0;i < capacitateArbore;i++)
        {
            indparinte[i] = -1;
            valchei[i] = -1;
        }
    }
   
    int countChilds(int indxParinte)
    {
    	int childs = 0;
    	for(int i = 0;i < capacitateArbore;i++)
    	{
    		if(indparinte[i] == indxParinte)
    		{
    			childs++;
    		}
    	}
    	return childs;
    }
    
    int[] getChildIndx(int indxParinte)
    {
    	int maxChilds = 2;
    	int childs[] = new int[maxChilds];
    	int counter = 0;
    	for(int i = 0;i < capacitateArbore;i++)
    	{
    		if(indparinte[i] == indxParinte)
    		{
    			childs[counter] = i; // save the child index
    			counter++;
    		}
    	}
    	// umplem restul de copii cu -1 
    	for(int i = counter; i < maxChilds;i++)
    	{
    		childs[i] = -1;
    		// System.out.println("Added index -1 ca fiu.");
    	}
    	return childs;
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
    	// verificam daca cheia 
    	// are 2 fii daca nu -> tr sa punem la urmatorul indice parinte cheia
    	if(countChilds(indiceParinte) >= 2)
    	{
    		indiceParinte++;
    		add(cheie,indiceParinte);
    		return -1;
    	}
    	// Daca a trecut de verificare putem adauga cheia la indicele acelui parinte
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
    	int[] childIndx = getChildIndx(0);
        //System.out.println("Radacina este "+valchei[0]+" are fiul stang "+valchei[childIndx[0]] +"("+childIndx[0]+")"+" si fiul drept "+valchei[childIndx[1]] +"("+childIndx[1]+")");
        for(int i = 0;i < capacitateArbore;i++)
        {
        	if(valchei[i] != -1)
        	{
	            if(countChilds(i) > 0)
	            {
	            	childIndx = getChildIndx(i);
	            	System.out.print("Nodul "+i+" cu cheie "+valchei[i]);
	            	if(childIndx[0] != -1)
	            		System.out.print(" are fiul stang "+valchei[childIndx[0]] +"("+childIndx[0]+")");
	            	else
	            		System.out.print(" nu are fiu stang ");
	            	if(childIndx[1] != -1)
	            		System.out.println(" si fiul drept "+valchei[childIndx[1]] +"("+childIndx[1]+")");
	            	else
	            		System.out.println(" nu are fiu drept.");
	            }
        	}
        }
    }
   
    public static void main(String args[])
    {
    	BinaryTree arb = new BinaryTree();
    	System.out.println("Program Arbore Binar");
      	arb.add(15, -1); //0 - > Radacina
      	arb.add(9, 0); //1
      	arb.add(2, 0); //2
      	arb.add(4, 1); //3
      	arb.add(8, 3); //4
      	arb.add(7, 1); //5
      	arb.add(72,1); //6
      	arb.add(6, 2); //7
      	arb.add(88, 2); //8
    	arb.add(5, 2); //9
    	arb.add(84, 6); //10
    	arb.add(22, 6); //11
    	//arb.add(34, 1); //12
      	arb.search(4);
      	arb.printTree();
      	arb.delete(2);
      	arb.printTree();
      	arb.add(10,0);

      	arb.printTree();
      	//arb.search(10);
    }
}