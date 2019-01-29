/*Our data class*/
import java.io.FileWriter;
import java.io.IOException;
import java.io.Writer;
import java.util.List;

import org.json.simple.JSONArray;
import org.json.simple.JSONObject;

public class Data
{
	private static final String jsonOutputFile = "output.json";
	private String m_name;
	private String m_prename;
	private int m_ID;
	private String m_petType;
	private String m_petName;
	private TransactionNumber m_transactionNumber;
	
	Data(int _ID,String _name,String _pre,String _petType,String _petName,TransactionNumber tr)
	{
		m_ID = _ID;
		m_name = _name;
		m_prename = _pre;
		m_petType = _petType;
		m_petName = _petName;
		m_transactionNumber = tr;
	}
	@SuppressWarnings({ "unchecked" })
	public static void printAll(List<Data> data)
	{		
		try
		{
			JSONObject myobjData = new JSONObject();
			Writer file = new FileWriter(jsonOutputFile);
			JSONArray jsonArray = new JSONArray();
			for(int i = 0;i < data.size();i++)
			{
				StringBuffer sb = new StringBuffer();
				sb.append("\nInformations about the owner with ID "+data.get(i).get_ID());
				sb.append("\nName : "+data.get(i).get_name());
				sb.append("\nSurname : "+data.get(i).get_prename());
				sb.append("\nPet race : "+data.get(i).get_petType());
				sb.append("\nPet Name : "+data.get(i).get_petName());
				sb.append("\nTransaction ID encrypted : "+data.get(i).get_transactionNumber().get_encryptedData()+"\n");
				myobjData.put("ID",data.get(i).get_ID());
				myobjData.put("Name",data.get(i).get_name());
				myobjData.put("Surname",data.get(i).get_prename());
				myobjData.put("Pet Race",data.get(i).get_petType());
				myobjData.put("Pet Name",data.get(i).get_petName());
				myobjData.put("Transaction ID",data.get(i).get_transactionNumber().get_encryptedData());
				jsonArray.add(myobjData);
				// Write in the standard output
				System.out.println(sb);
			}
			// Write in the json file
			JSONObject mainJson = new JSONObject();
			mainJson.put("Data",jsonArray);
			file.write(mainJson.toString());
			file.flush();
			file.close();
		}
		catch(IOException e)
		{
			e.printStackTrace();
		}
	}
	public String get_name() {
		return m_name;
	}
	public void set_name(String m_name) {
		this.m_name = m_name;
	}
	public String get_prename() {
		return m_prename;
	}
	public void set_prename(String m_prename) {
		this.m_prename = m_prename;
	}
	public int get_ID() {
		return m_ID;
	}
	public void set_ID(int m_ID) {
		this.m_ID = m_ID;
	}
	public String get_petName() {
		return m_petName;
	}
	public void set_petName(String m_petName) {
		this.m_petName = m_petName;
	}
	public TransactionNumber get_transactionNumber() {
		return m_transactionNumber;
	}
	public void set_transactionNumber(TransactionNumber m_transactionNumber) {
		this.m_transactionNumber = m_transactionNumber;
	}
	public String get_petType() {
		return m_petType;
	}
	public void set_petType(String m_petType) {
		this.m_petType = m_petType;
	}	
	public String toString() 
	{
		StringBuffer sb = new StringBuffer();
		sb.append("\nInformations about the owner with ID "+get_ID());
		sb.append("\nName : "+get_name());
		sb.append("\nLast name : "+get_prename());
		sb.append("\nPet race : "+get_petType());
		sb.append("\nPet Name : "+get_petName());
		sb.append("\nTransaction ID : "+get_transactionNumber().toString()+"\n");
		return sb.toString();
	}
}