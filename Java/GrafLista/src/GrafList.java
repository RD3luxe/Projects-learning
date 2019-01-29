class LinkedList
{
    class Node
    {
        char value;
        Node next;
        Node(char val)
        {
            value = val;
            next = null;
        }
    }
    Node root;
    LinkedList()
    {
        root = null;
    }
    boolean isEmpty()
    {
        return root == null ? true:false;
    }
    void add(char A)
    {  
        if(root == null)
        {  
            root = new Node(A);
            return;
        }
        Node nextNode = new Node(A);
        if(root.next == null)
        {
            root.next = nextNode;
        }else{
            Node last = root;
            Node myAdd = last;     
            for(;last != null;myAdd = last,last = last.next);
            myAdd.next = nextNode;
        }
    }  
    void printList(int[] costArr)
    {
        if(root == null)
            return;
        char val = root.value;
        System.out.println("Nod : "+val+" | ");
        Node aux = root.next;
        if(aux == null)
            return;
        int cnt = 0;
        for(;aux != null;aux = aux.next)
        {
            System.out.println(val+"-"+aux.value+" Cost : "+costArr[cnt]);
            cnt++;
        }
        System.out.println();
    }
    /*boolean searchNode(char nameNode)
    {
        Node auxNode = root;
        for(;auxNode != null;auxNode = auxNode.next)
        {
            if(auxNode.value == nameNode)
                return true;
        }
        return false;
    }*/
}
 
class GrafList
{
    // lista de adiacenta
    LinkedList adjList[];
    int[] ponderi;
    // nr de arce
    int nrV,curPosition,pContor;
    //constructor
    GrafList(int vert)
    {
        curPosition = 0;
        nrV = vert*2;
        adjList = new LinkedList[nrV];
        // Cream o lista pentru fiecare nod
        for(int i = 0;i < nrV/2;i++)
        {
            adjList[i] = new LinkedList();
        }
        ponderi = new int[nrV];
        pContor = 0;
    }
    int getPositionNode(char nodeA)
    {
        for(int i = 0;i < nrV/2;i++)
        {
            if(adjList[i] != null && !adjList[i].isEmpty())
            {
                if(adjList[i].root.value == nodeA)
                    return i;
            }
        }
        return -1;
    }
    void addEdge(char nodeA,char nodeB,int pondere)
    {
        // Verificam daca nodul A exista sau nu
        int posA = getPositionNode(nodeA);
        int posB = getPositionNode(nodeB);
        if(posA == -1)
        {
            adjList[curPosition].add(nodeA);
            adjList[curPosition].add(nodeB);
            curPosition++;
        }else{
            adjList[posA].add(nodeB);
        }
        if(posB == -1)
        {
            adjList[curPosition].add(nodeB);
            adjList[curPosition].add(nodeA);
            curPosition++;
        }else{
            adjList[posB].add(nodeA);
        }
        ponderi[pContor] = pondere;
        pContor++;
    }
    void printGraf()
    {
        for(int i = 0; i < nrV/2;i++)
        {
            if(adjList[i] != null)
            {
                adjList[i].printList(ponderi);
            }          
        }
    }
    public static void main(String[] args)
    {
        GrafList graf = new GrafList(5);
        graf.addEdge('A','B',12);
        graf.addEdge('A','C',15);
        graf.addEdge('A','D',40);
        graf.addEdge('F','D',60);
        graf.addEdge('F','C',9);
        graf.printGraf();
    }
}