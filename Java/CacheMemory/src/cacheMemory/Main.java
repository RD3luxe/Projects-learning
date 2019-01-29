package cacheMemory;
import java.util.Scanner;
import java.io.File;
import java.io.FileNotFoundException;

public class Main 
{
	public static void main(String[] args) throws FileNotFoundException 
	{
		Memory primaryMemory = new Memory(); // Memoria primara
		Cache cacheMemory = null; // Memoria cache
		int nrOperations;
		String cacheType;
		int cacheSize;
		String line;
		File file = new File(args[0]);
		if(!file.exists())
		{
			System.out.println("File not found.");
			return;
		}
		Scanner sc = new Scanner(file);
		cacheType = sc.nextLine();
		cacheSize = sc.nextInt();
		nrOperations = sc.nextInt();
		// Verificam ce tip de cache e si facem un switch
		switch(cacheType)
		{
			case "FIFO" :
				cacheMemory = new FIFOCache(cacheSize);
				break;
			case "LFU" :
				cacheMemory = new LFUCache(cacheSize);
				break;
			case "LRU" :
				cacheMemory = new LRUCache(cacheSize);
				break;
			default :
				break;
		}
		//System.out.format("Cache Type : %s | Cache size : %d | Nr of operations : %d\n",cacheType,cacheSize,nrOperations);
		for(int i = 0;i <= nrOperations;i++)
		{
			line = sc.nextLine();
			String splitLine[] = line.split(" ");
			if(splitLine.length >= 3)
			{
				int indx = primaryMemory.getByTitluar(splitLine[1]);
				int cacheIndx = cacheMemory.exist(splitLine[1]);
				if(indx != -1)
				{
					primaryMemory.getMyMemory().get(indx).set_basicSubs(Integer.parseInt(splitLine[2]));
					if(cacheIndx != -1)
					{
						cacheMemory.remove(new Premium(splitLine[1]));
						//cacheMemory.getCache()[cacheIndx].set_basicSubs(Integer.parseInt(splitLine[2]));
					}
					if(splitLine.length == 4)
					{
						primaryMemory.getMyMemory().get(indx).set_premiumSubs(Integer.parseInt(splitLine[3]));
						if(cacheIndx != -1)
						{
							cacheMemory.remove(new Premium(splitLine[1]));
							//cacheMemory.getCache()[cacheIndx].set_premiumSubs(Integer.parseInt(splitLine[3]));
						}
					}
				}else{
					Premium obj = new Premium(splitLine[1]);
					obj.set_basicSubs(Integer.parseInt(splitLine[2]));
					if(splitLine.length == 4)
					{
						obj.set_premiumSubs(Integer.parseInt(splitLine[3]));
					}
					primaryMemory.getMyMemory().add(obj);
				}
			}
			else if(splitLine.length == 2)  // GET cu 1 parametru , numele obj
			{
				int indx = primaryMemory.getByTitluar(splitLine[1]);
				int cacheIndx = cacheMemory.exist(splitLine[1]);
				if(cacheMemory != null && cacheIndx != -1)
				{
					System.out.print("0");
					if(primaryMemory.getMyMemory().get(indx).get_premiumSubs() != 0)
					{
						System.out.println(" PREMIUM");
						primaryMemory.getMyMemory().get(indx).set_premiumSubs(primaryMemory.getMyMemory().get(indx).get_premiumSubs() - 1);
						cacheMemory.getCache()[cacheIndx].set_premiumSubs(cacheMemory.getCache()[cacheIndx].get_premiumSubs() - 1);
					}
					else if(primaryMemory.getMyMemory().get(indx).get_basicSubs() != 0)
					{
						System.out.println(" BASIC");
						primaryMemory.getMyMemory().get(indx).set_basicSubs(primaryMemory.getMyMemory().get(indx).get_basicSubs() - 1);
						cacheMemory.getCache()[cacheIndx].set_basicSubs(cacheMemory.getCache()[cacheIndx].get_basicSubs() - 1);
					}
					else
					{
						System.out.println(" FREE");
					}
				}
				else if(primaryMemory.search(splitLine[1]))
				{
					// Obiectul exista -> adaugam si in cache si afisam in fisier 1
					System.out.print("1");
					if(primaryMemory.getMyMemory().get(indx).get_premiumSubs() != 0)
					{
						System.out.println(" PREMIUM");
						primaryMemory.getMyMemory().get(indx).set_premiumSubs(primaryMemory.getMyMemory().get(indx).get_premiumSubs() - 1);
					}
					else if(primaryMemory.getMyMemory().get(indx).get_basicSubs() != 0)
					{
						System.out.println(" BASIC");
						primaryMemory.getMyMemory().get(indx).set_basicSubs(primaryMemory.getMyMemory().get(indx).get_basicSubs() - 1);
					}
					else
					{
						System.out.println(" FREE");
					}
					cacheMemory.add(primaryMemory.getMyMemory().get(indx));
				}
				else
				{
					System.out.println("2 "+splitLine[1]);			
				}
			}
		}
		sc.close();
	}
}