/* Class used to implement the AES encryption algorithm*/
import java.security.Key;
import javax.crypto.Cipher;
import javax.crypto.spec.SecretKeySpec;
import java.util.Base64;
import java.util.List;

public class EncryptionAES 
{
	private byte[] keyValue;
	public static String encryptionKey;
	
	public EncryptionAES()
	{
		keyValue = encryptionKey.getBytes();
	}
	public void encryptAllKeys(List<Data> myData)
	{
		// Now encrypt it using AES
		try 
		{
			if(EncryptionAES.encryptionKey != null)
			{
				for(int i = 0;i < myData.size();i++)
				{
					TransactionNumber trans = myData.get(i).get_transactionNumber();
					EncryptionAES encryptorAES = new EncryptionAES();
					String dataToEncrypt = trans.get_RawData();
					trans.set_encryptedData(encryptorAES.encrypt(dataToEncrypt));
					// Test logs
					//System.out.println(trans.get_encryptedData());
					//String decrypted = encryptorAES.decrypt(trans.get_encryptedData());
					//System.out.println("Original : "+dataToEncrypt+" Decrypted : "+decrypted);
				}
			}
		}
		catch (Exception e) 
		{
			e.printStackTrace();
		}
	}
	public String encrypt(String Data) throws Exception
	{
		Key key = generateKey();
		Cipher cipher = Cipher.getInstance("AES");
		cipher.init(Cipher.ENCRYPT_MODE, key);
		byte[] encVal = cipher.doFinal(Data.getBytes());
		String encryptedValue = Base64.getEncoder().encodeToString(encVal);
		return encryptedValue;
	}
	public String decrypt(String encryptedData) throws Exception
	{
		Key key = generateKey();
		Cipher cipher = Cipher.getInstance("AES");
		cipher.init(Cipher.DECRYPT_MODE, key);
		byte[] decoderValue = Base64.getDecoder().decode(encryptedData);
		byte[] decValue = cipher.doFinal(decoderValue);
		String decryptedValue = new String(decValue);
		return decryptedValue;
	}
	private Key generateKey() throws Exception
	{
		Key key = new SecretKeySpec(keyValue,"AES");
		return key;
	}
}