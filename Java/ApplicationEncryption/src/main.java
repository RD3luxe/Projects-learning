import java.io.FileNotFoundException;
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;
import java.util.Scanner;

public class main 
{
	private final static String xmlFileName = "input_halter.xml";
	private final static String csvFileName = "input.csv";
	
	public static void main(String[] args) throws FileNotFoundException
	{
		// A list with our data
		List<Data> myData = new ArrayList<Data>();
		// Read the files and populate the list
		MyReader dataReader = new MyReader(csvFileName,xmlFileName);
		// read the xml file and return the number of persons (we can use the dimension of the array as the number but to be sure..)
		int personsCounter = dataReader.readPersonsData(myData);  
		// read the csv file and return the number of pets
		int petCounter = dataReader.readPetsData(myData);  	   
		System.out.println("Imported "+petCounter+" pets from "+csvFileName);
		System.out.println("Imported "+personsCounter+" people from "+xmlFileName);
		String key,command;
		Scanner scInput = new Scanner(System.in);
		boolean keyEntered = false;
		while(!keyEntered)
		{
			System.out.print("Enter a 16 digit key : ");
			key = scInput.next();
			if(key.length() == 16)
			{
				keyEntered = true;
				EncryptionAES.encryptionKey = key;
			}else{
				keyEntered = false;
				System.out.println("Please enter a 16 digit key !!!");
			}
		}
		// Do the encryption for the transaction key after we got the key provided by the user
		EncryptionAES aesEncryptor = new EncryptionAES();
		aesEncryptor.encryptAllKeys(myData);
		int personID = -1;
		// we reuse this with the id input reader
		keyEntered = false; 
		while(!keyEntered)
		{
			System.out.print("Enter an id or type exit to close the application : ");
			command = scInput.next();
			if(command.toLowerCase().equals("exit"))
			{
				keyEntered = true; // stop the loop
				System.out.println("Closing application.");
				System.exit(0);
			}else{
				boolean found = false;
				personID = Integer.parseInt(command);
				if(personID == 0)
				{
					// Set the found flag on true because we will display all the data
					found = true;
					// sort after the pet name
					Collections.sort(myData, (a, b) -> a.get_petName().compareToIgnoreCase(b.get_petName()));
					// print the data and write it in the json file
					Data.printAll(myData);
				}
				else if(personID >= 1)
				{
					// print this person ( not the best method but it works )
					for(int i = 0;i < myData.size();i++)
					{
						if(myData.get(i).get_ID() == personID)
						{
							found = true;
							System.out.println(myData.get(i).toString());
							break;
						}
					}
				}
				if(!found)
				{
					System.out.println("Invalid/Unknown owner id.");
				}
			}
		}
		scInput.close();
	}
}