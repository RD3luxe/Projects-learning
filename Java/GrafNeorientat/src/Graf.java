/*
ENUNT :
    Sa se scrie un program in limbajul C care citeste de la tastatura o structura de date de tip graf prin intermediul unui meniu interactiv.
    Meniul va suporta urmatoarele functii :
        - Introducere nod
        - Introducere arc
        - Stergere nod
        - Stergere arc
        - Afisare graf
        - Exista drum ? (verifica daca exista drum intre A si B)
        - Iesire program
*/
import java.util.Scanner;
 
class Graf
{
    public int[][] m_adiacenceMatrix;
    private char[] nodes;
    private int nrElem;
    Graf(int nrElements)
    {
        // Alocam memoria pentru matricea de adicenta
        m_adiacenceMatrix = new int[nrElements][nrElements];
        // Initializam cu 0 matricea de adiacenta
        for(int i = 0;i < nrElements;i++)
        {  
            for(int j = 0;j < nrElements;j++)
            {
                m_adiacenceMatrix[i][j] = 0;
            }
        }
        // Initializam nr max de noduri din graf
        nrElem = nrElements;
        // Alocam memorie pt vectorul de noduri
        nodes = new char[nrElements];
        for(int i = 0;i < nrElements;i++)
        {
            nodes[i] = '?';
        }
    }
    /*
        Adauga un nod in graf      
    */
    public int addNode(char nodeValue)
    {
    	int getPos = getPosition(nodeValue);
    	if(getPos != -1)
    		return -1; // nodul e deja in graf
        for(int i = 0;i < nrElem;i++)
        {
            if(nodes[i] == '?')
            {
                // Adaugam nodu unde e loc (pt ca stergerea)
                nodes[i] = nodeValue;
                return 0;
            }
        }
        return -1;
    }
    /*
        Adauga un arc in graf de la nodul A la nodul B     
    */
    public int addArc(char A,char B,int cost)
    {
        int pozNodA = getPosition(A);
        int pozNodB = getPosition(B);
        if(pozNodA == -1 || pozNodB == -1)
            return -2; // nu exista nodurile
        if(m_adiacenceMatrix[pozNodA][pozNodB] == 0
           || m_adiacenceMatrix[pozNodB][pozNodA] == 0)
        {
            m_adiacenceMatrix[pozNodA][pozNodB] = cost;
            m_adiacenceMatrix[pozNodB][pozNodA] = cost;
            return 0;
        }  
        return -1; // arc deja existent
    }
    /*
        Metoda ajutatoare pentru a returna indexul la care se gaseste nodul in vectorul de noduri
    */
    private int getPosition(char node)
    {
        for(int i = 0;i < nrElem;i++)
        {
            if(nodes[i] == node)
                return i;
        }
        return -1;
    }
    /*
        Verifica daca exista drum intre A si B
            returnea costu
    */
    public int isRoad(char A,char B)
    {
        int pozA = getPosition(A);
        int pozB = getPosition(B);
        if(pozA == -1 || pozB == -1)
            return -1; // nu exista nodurile
        return m_adiacenceMatrix[pozA][pozB];
    }
    /*
         Sterge nod din graf
    */
    public int deleteNode(char nodeValue)
    {
        // Luam pozitia nodului de sters
        int pozA = getPosition(nodeValue);
        if(pozA == -1)
            return -1; // Nu exista nodu
        for(int i = 0;i < nrElem;i++)
        {
            if(m_adiacenceMatrix[pozA][i] != 0 || m_adiacenceMatrix[i][pozA] != 0)
            {
                // Stergem arcul daca l-am gasit
                deleteArc(nodeValue,nodes[i]);
            }
        }
        nodes[pozA] = '?';
        return 0;
    }
    /*
        Sterge arc din graf
    */
    public int deleteArc(char A,char B)
    {
        int pozA = getPosition(A);
        int pozB = getPosition(B);
        if(pozA == -1 || pozB == -1)
            return -1; // nu exista nodurile
        // Stergem arcele in ambele directii
        m_adiacenceMatrix[pozA][pozB] = 0;
        m_adiacenceMatrix[pozB][pozA] = 0;
        return 0;
    }
    /*
        Afisare graf
    */
    public void printGraf()
    {
        int cNode = 0;
        for(int i = 0;i < nrElem;i++)
        {
            for(int j = 0;j < nrElem;j++)
            {
            	if(m_adiacenceMatrix[i][j] != 0)
            	{
	                if(nodes[cNode] != '?')
	                {
	                    System.out.print("Valoare nod : "+nodes[cNode]+" | Arce : "+nodes[cNode]+" <-> "+nodes[j]+" cost : ");
		                System.out.println(m_adiacenceMatrix[cNode][j]);
	                }
            	}
            }
            cNode++;
        }
        System.out.println();
    }
    /*
        Meniu'
    */
    public static void menu()
    {
        System.out.println("[1] Adauga nod");
        System.out.println("[2] Adauga arc");
        System.out.println("[3] Sterge nod");
        System.out.println("[4] Sterge arc");
        System.out.println("[5] Afisare graf");
        System.out.println("[6] Exista drum intre 2 noduri");
        System.out.println("[7] Iesire");
        System.out.print("Optiune : ");
    }
    public static void main(String[] args)
    {
        Scanner scan = new Scanner(System.in);
        int choice = 0;
        char A,B;
        System.out.println("Graf neorientat");
        Graf myGraf = new Graf(6);
        do
        {
            menu();
            choice = scan.nextInt();
            switch(choice)
            {
                case 1 :
                    System.out.print("Valoare nod : ");
                    A = scan.next().charAt(0);
                    if(myGraf.addNode(A) == -1)
                    {
                        System.out.println("Nodul este deja in graf sau graful este plin.");
                    }else{
                    	 System.out.println("Nodul "+A+" a fost adaugat in graf.");
                    }
                    break;
                case 2 :
                    System.out.print("Valoare nod A : ");
                    A = scan.next().charAt(0);
                    System.out.print("Valoare nod B : ");
                    B = scan.next().charAt(0);
                    System.out.print("Cost arc : ");
                    int val = myGraf.addArc(A,B,scan.nextInt());
                    if(val == -1)
                    {
                        System.out.println("Arc deja existent.");
                    }
                    else if(val == -2)
                    {
                   	 	System.out.println("Unul sau ambele noduri nu exista in graf.");
                    }
                    else 
                    {
                    	 System.out.println("Arcul a fost adaugat.");
                    }
                    break;
                case 3 :
                    System.out.print("Valoare nod : ");
                    A = scan.next().charAt(0);
                    if(myGraf.deleteNode(A) == -1)
                    {
                        System.out.println("Nodul NU este in graf.");
                    }else{
                    	System.out.println("Nodul a fost sters.");
                    }
                    break;
                case 4 :
                    System.out.print("Valoare nod A : ");
                    A = scan.next().charAt(0);
                    System.out.print("Valoare nod B : ");
                    B = scan.next().charAt(0);
                    int rVal = myGraf.deleteArc(A,B);
                    if(myGraf.deleteArc(A,B) == -1)
                    {
                        System.out.println("Arc deja existent.");
                    }
                    else if(myGraf.deleteArc(A,B) == -2)
                    {
                    	 System.out.println("Unul sau ambele noduri nu exista in graf.");
                    }     
                    else 
                    {
                    	System.out.println("Arcul a fost sters.");
                    }
                    break;
                case 5 :
                    myGraf.printGraf();
                    break;
                case 6 :
                    System.out.print("Valoare nod A : ");
                    A = scan.next().charAt(0);
                    System.out.print("Valoare nod B : ");
                    B = scan.next().charAt(0);
                    int cost = myGraf.isRoad(A,B);
                    if(cost == 0)
                    {
                        System.out.println("Nu exista drum intre "+A+" si "+B);
                    }
                    else 
                    {
                    	System.out.println("Exista drum intre "+A+" si "+B+" cu costul de : "+cost);
                    }
                    break;
                case 7 :
                    break;
                default :
                    break;
            }
 
        }while(choice != 7);
        scan.close();
    }
}