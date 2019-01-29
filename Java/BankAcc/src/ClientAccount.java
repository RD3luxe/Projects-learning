import java.util.Scanner;

public class ClientAccount 
{
	 private Account account1 = new Account(1,100.0f);
	 private Account account2 = new Account(2,200.0f);
     public void Operations()
     {
         Scanner scan = new Scanner(System.in);
         System.out.println("Amount to deposit : ");
         float _depSum = scan.nextFloat();
         account1.Deposit(_depSum);
         System.out.println("Amount to extract : ");
         float _extSum = scan.nextFloat();
         account2.Withdraw(_extSum);
         System.out.println("Amount to transfer from acc1 to acc2 : ");
         float _transSum = scan.nextFloat();
         account1.TransferMoney(account2,_transSum);
         System.out.println("Total amount for acc1 is "+account1.TotalAmount());
         System.out.println("Total amount for acc2 is "+account2.TotalAmount());
         scan.close();
     }
}
