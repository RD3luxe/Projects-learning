/*Class used to read the files*/
import java.io.File;
import java.io.FileNotFoundException;
import java.util.List;
import java.util.Scanner;
import java.io.IOException;

import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;
import javax.xml.parsers.ParserConfigurationException;

import org.w3c.dom.Document;
import org.w3c.dom.Element;
import org.w3c.dom.NodeList;
import org.xml.sax.SAXException;

public class MyReader 
{
	private File file;
	private Document dom;
	
	MyReader(String petsFileName,String xmlFile) 
	{
		file = new File(petsFileName);
		parseXmlFile(xmlFile);
	}
	private void parseXmlFile(String xmlName)
	{
		//get the factory
		DocumentBuilderFactory dbf = DocumentBuilderFactory.newInstance();
		try 
		{
			//Using factory get an instance of document builder
			DocumentBuilder db = dbf.newDocumentBuilder();
			//parse using builder to get DOM representation of the XML file
			dom = db.parse(xmlName);
		}catch(ParserConfigurationException pce) {
			pce.printStackTrace();
		}catch(SAXException se) {
			se.printStackTrace();
		}catch(IOException ioe) {
			ioe.printStackTrace();
		}
	}
	public int readPersonsData(List<Data> myDataList)
	{
		int _countPersons = 0;
		//get the root elememt
		Element docEle = dom.getDocumentElement();
		//get a nodelist of <Halter> elements
		NodeList nl = docEle.getElementsByTagName("Halter");
		if(nl != null && nl.getLength() > 0) 
		{
			for(int i = 0 ; i < nl.getLength();i++)
			{
				//get the 'Halter' element
				Element el = (Element)nl.item(i);
				Data e = getPerson(el);
				//add it to list
				myDataList.add(e);
				//Increase our counter
				_countPersons++;
			}
		}
		return _countPersons;
	}
	private Data getPerson(Element el)
	{
		String name = getTextValue(el,"Vorname");
		String lastName = getTextValue(el,"Nachname");
		int id = getIntValue(el,"ID");
		//Create a new Data with the value read from the xml nodes
		Data e = new Data(id,name,lastName,"","",new TransactionNumber(16));
		return e;
	}
	private String getTextValue(Element ele, String tagName)
	{
		String textVal = null;
		NodeList nl = ele.getElementsByTagName(tagName);
		if(nl != null && nl.getLength() > 0) {
			Element el = (Element)nl.item(0);
			textVal = el.getFirstChild().getNodeValue();
		}
		return textVal;
	}
	private int getIntValue(Element dt, String tagName) 
	{
		return Integer.parseInt(getTextValue(dt,tagName));
	}
	/*Will return the number of pets in the file and set the pets to their owners after indexes*/
	public int readPetsData(List<Data> myData) throws FileNotFoundException
	{
		int _countPets = 0;
		Scanner sc = new Scanner(file);
		sc.nextLine(); // Skip the columns 
        while (sc.hasNextLine()) 
        {
            String line = sc.nextLine();
            String[] splitData = line.split(",");
            if(splitData.length >= 2)   // To be sure we don't get index out of bounds if the line is empty
            { 
		        for(int i = 0;i < myData.size();i++)
	            {
	            	if(myData.get(i).get_ID() == Integer.parseInt(splitData[0])) // we found the owner of this pet
	            	{
	            		// We set the pet name and the 'type'
	            		myData.get(i).set_petType(splitData[1]);
	            		myData.get(i).set_petName(splitData[2]);
	            		_countPets++; // we increment the pet number
	            		break;
	            	}
	            }  
            }
        }
        sc.close();
		return _countPets;
	}
}