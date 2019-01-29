public class Account
{
    private int m_ID;
    private float m_money;
    Account(int id,float amount)
    {
    	m_ID = id;
    	m_money = amount;
    }
    public void Deposit(float amount)
    {
        m_money += amount;
        System.out.println("Account with ID "+m_ID+" deposited "+amount+" | Total now : "+m_money);
    }
    public void Withdraw(float amount)
    {
        m_money -= amount;
        System.out.println("Account with ID "+m_ID+" extracted "+amount+" | Total now : "+m_money);
    }
    public float ComputeInterest()
    {
        float _interest = (0.5f * m_money) / 100;
        return _interest;
    }
    public float TotalAmount()
    {
        return m_money + ComputeInterest();
    }
    public void TransferMoney(Account dest,float amount)
    {
        if(dest == null)
            return;
        
        if(amount > m_money)
            return;
        
        m_money -= amount;
        System.out.println("Transfer done succesfully : Account with ID "+m_ID+" transfered "+amount+" to account with ID "+dest.getID());
        dest.setMoney(dest.getMoney() + amount);
    }
    // Getters
    public int getID()
    {
        return m_ID;
    }
    public float getMoney()
    {
        return m_money;
    }
    // Setteri
    public void setID(int ID)
    {
        m_ID = ID;
    }
    public void setMoney(float amount)
    {
        m_money = amount;
    }
}