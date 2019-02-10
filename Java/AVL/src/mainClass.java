import java.util.Scanner;

public class mainClass
{
	public static void main(String[] args)
	{
		Scanner scan = new Scanner(System.in);
		/* Creating object of AVLTree */
		AVLTree avlt = new AVLTree();
		System.out.println("AVLTree Tree Test\n");
		int choice = 0;
		/* Perform tree operations */
		do
		{
			System.out.println("\nAVLTree Operations\n");
			System.out.println("1. Insert node");
			System.out.println("2. Search node");
			System.out.println("3. Count nodes");
			System.out.println("4. Check empty");
			System.out.println("5. Clear tree");
			System.out.println("6. Delete node");
			choice = scan.nextInt();
			switch (choice)
			{
			case 1:
				System.out.println("Enter integer element to insert : ");
				avlt.insert(scan.nextInt());
				break;
			case 2:
				System.out.println("Enter integer element to search : ");
				System.out.println("Search result : " + avlt.search(scan.nextInt()));
				break;
			case 3:
				System.out.println("Adancime  = " + avlt.maxLevels());
				System.out.println("Nodes = " + avlt.countNodes());
				break;
			case 4:
				System.out.println("Empty status = " + avlt.isEmpty());
				break;
			case 5:
				System.out.println("\nTree Cleared");
				avlt.makeEmpty();
				break;
			case 6:
				System.out.println("Enter integer element to delete : ");
				avlt.delete(scan.nextInt());
				break;
			default:
				System.out.println("Wrong Entry \n ");
				break;
			}
			/* Display tree */
			System.out.print("\nPost order : ");
			avlt.postorder();
			System.out.print("\nPre order : ");
			avlt.preorder();
			System.out.print("\nIn order : ");
			avlt.inorder();
		}while (choice != 0);
		scan.close();
	}
}
