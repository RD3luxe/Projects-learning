/*Transaction ID class*/
import java.util.Random;

public class TransactionNumber
{
	private String m_rawNumber;
	private String m_encryptedData;
	private Random random;
	
	TransactionNumber(int sizeTransKey)
	{
		random = new Random(System.nanoTime());
		// Generate our transaction number
		m_rawNumber = generateTransaction(sizeTransKey);
	}
    private String generateTransaction(int length) 
    {
    	/* we use length - 1 because we need a key with the size of 16 digits
    	   we generate the first 15 random and the last digit is generated with luhn algorithm */
        int randomNumberLength = length - 1;
        StringBuilder builder = new StringBuilder();
        for (int i = 0; i < randomNumberLength; i++)
        {
            int digit = this.random.nextInt(10);
            builder.append(digit);
        }
        // Do the Luhn algorithm to generate the check digit.
        int checkDigit = this.getCheckDigit(builder.toString());
        builder.append(checkDigit);
        return builder.toString();
    }
    private int getCheckDigit(String number) 
    {
        int sum = 0;
        for (int i = 0; i < number.length(); i++) 
        {
            // Get the digit at the current position.
            int digit = Integer.parseInt(number.substring(i, (i + 1)));
            if ((i % 2) == 0)
            {
                digit = digit * 2;
                if (digit > 9) {
                    digit = (digit / 10) + (digit % 10);
                }
            }
            sum += digit;
        }
        int mod = sum % 10;
        return ((mod == 0) ? 0 : 10 - mod);
    }
	public String get_RawData() {
		return m_rawNumber;
	}
	public String get_encryptedData() {
		return m_encryptedData;
	}
	public void set_encryptedData(String data) {
		m_encryptedData = data;
	}
	public String toString()
	{
		StringBuilder sb = new StringBuilder();
		sb.append(m_rawNumber.toCharArray(), 0, 4);
		sb.append(" ");
		sb.append(m_rawNumber.toCharArray(), 4, 2);
		sb.append(" ... ");
		sb.append(m_rawNumber.toCharArray(), 12, 4);
		return sb.toString();
	}
}