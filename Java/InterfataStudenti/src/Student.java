import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.File;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.Random;

public class Student 
{
	private final String DBName = "file.txt";
	private final String Questions = "questions.txt";
	
	private String m_name,m_surname,m_scode;
	private int m_age;
	private String m_fac,m_serie;
	private int m_group;
	private String m_question,m_questionA;
	private Date m_date;
	private int m_sex; // 1 - male, 2 -female;
	private boolean m_working;

	private void SetRandomQuestion()
	{
		Random rand = new Random(); 
		int value = rand.nextInt(5); 
		try 
		{
	        File file = new  File(Questions); 
	        if (!file.exists()) {  
	        	m_question = "Numele pisicii tale ?";
	        	return;
	        }
	        FileReader fw = new FileReader(file.getAbsoluteFile());
	        BufferedReader bw = new BufferedReader(fw); 
	        int cnt = 0;
	        String buffer = null;
			while((buffer = bw.readLine()) != null)
			{
				if(cnt == value)
				{
					m_question = buffer;
					break;
				}
				cnt++;
			}
	        bw.close(); 
	    }
		catch (IOException e) 
		{ 
	        e.printStackTrace();
	    }
	}
	
	private String createStringStud()
	{
		String buffer = null;
		SimpleDateFormat formatter = new SimpleDateFormat("dd/MM/yyyy");
		String strDate = formatter.format(m_date);
		buffer = String.format("%s %s %s %s %d %s %s %d %s %s '%s'",strDate,m_scode,m_name,m_surname,m_age,m_fac,m_serie,m_group,m_questionA,m_sex == 1 ? "Male":"Female",m_working == true? "Angajat":"Fara serviciu");
		return buffer;
	}
	
	public void writeToFile()
	{
		try 
		{
	        File file = new  File(DBName); 
	        if (!file.exists()) {  
	            file.createNewFile();   
	        }
	        String studData = createStringStud();
	        FileWriter fw = new FileWriter(file.getAbsoluteFile(), true);
	        BufferedWriter bw = new BufferedWriter(fw); 
	        bw.write(studData);
	        bw.newLine();
	        bw.close(); 
	    }
		catch (IOException e) 
		{ 
	        e.printStackTrace();
	    }
	}
	
	Student()
	{
		m_name = m_surname = m_scode = m_fac = m_serie = " ";
		m_age = 0;
		m_group = 0;
		m_questionA = " ";
		m_date = new Date();
		m_sex = 0;
		m_working = false;
		SetRandomQuestion();
	}
	
	/**
	 * @param m_questionA the m_questionA to set
	 */
	public void set_answer(String m_questionA) {
		this.m_questionA = m_questionA;
	}
	/**
	 * @param m_name the m_name to set
	 */
	public void setM_name(String m_name) {
		this.m_name = m_name;
	}
	/**
	 * @param m_scode the m_scode to set
	 */
	public void setM_scode(String m_scode) {
		this.m_scode = m_scode;
	}
	/**
	 * @param m_surname the m_surname to set
	 */
	public void setM_surname(String m_surname) {
		this.m_surname = m_surname;
	}
	/**
	 * @param m_age the m_age to set
	 */
	public void setM_age(int m_age) {
		this.m_age = m_age;
	}
	/*
	 * @param m_fac the m_fac to set
	 */
	public void setM_fac(String m_fac) {
		this.m_fac = m_fac;
	}
	/**
	 * @param m_serie the m_serie to set
	 */
	public void setM_serie(String m_serie) {
		this.m_serie = m_serie;
	}
	/**
	 * @param m_group the m_group to set
	 */
	public void setM_group(int m_group) {
		this.m_group = m_group;
	}
	/**
	 * @return the m_question
	 */
	public String getM_question() {
		return m_question;
	}
	/**
	 * @param m_date the m_date to set
	 */
	public void setM_date(Date m_date) {
		this.m_date = m_date;
	}
	/**
	 * @param m_sex the m_sex to set
	 */
	public void setM_sex(int m_sex) {
		this.m_sex = m_sex;
	}
	/**
	 * @param m_working the m_working to set
	 */
	public void setM_working(boolean m_working) {
		this.m_working = m_working;
	}
}
