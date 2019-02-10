class AVLTree
{
	private AVLNode root;
	public AVLTree()
	{
		root = null;
	}
	public boolean isEmpty()
	{
		return root == null;
	}
	/* Make the tree logically empty */
	public void makeEmpty()
	{
		root = null;
	}
	/* Function to insert data */
	public void insert(int data)
	{
		root = insert(data, root);
	}
	/* Function to delete data */
	public void delete(int data)
	{
		root = delete(data,root);
	}
	/* Function to get height of node */
	private int height(AVLNode t)
	{
		return t == null ? -1 : t.height;
	}
	/* Function to max of left/right node */
	private int max(int lhs, int rhs)
	{
		return lhs > rhs ? lhs : rhs;
	}
	/* Function to insert data recursively */
	private AVLNode insert(int x, AVLNode t)
	{
		if (t == null)
		{
			t = new AVLNode(x);
		}
		else if (x < t.data)
		{
			t.left = insert(x, t.left);
			/*if (height(t.left) - height(t.right) == 2)
				if (x < t.left.data)
					t = rotateWithLeftChild(t);
				else
					t = doubleWithLeftChild(t);*/
		}
		else if (x > t.data)
		{
			t.right = insert(x, t.right);
			/*if (height(t.right) - height(t.left) == 2)
				if (x > t.right.data)
					t = rotateWithRightChild(t);
				else
					t = doubleWithRightChild(t);*/
		}
		else
			; // Duplicate; do nothing
		//t.height = max(height(t.left), height(t.right)) + 1;
		return balanceAVL(t);
	}
	/* A fost folosita ca referinta cartea lui Mark Allen Weiss , Data Structures and Algorithm Analysis in Java (Capitolul 4 AVL) */
	/* Delete data function */
	private AVLNode delete(int x, AVLNode t)
	{
		// Nod null - base case
		if(t == null)
			return t;  
		
		if(x < t.data)
		{
			// Verific daca trebuie sa merg pe subarborele stang pentru a face stergerea
			t.left = delete( x, t.left );
		}
		else if(x > t.data)
		{
			// Verific daca trebuie sa merg pe subarborele drept pentru a face stergerea
			t.right = delete( x, t.right );	
		}
		else if( t.left != null && t.right != null ) // Cazul in cand subarborii au fii 
		{
			// Luam cel mai mare element din subarborele stang al radacinei 
			// Adica vom merge pe subarborele stang si dupa in drepta pana la ultimul element care v-a fii cel mai mare
			t.data = getPredecesor(t.left).data;
			// Stergem elementul ce a fost acolo pentru ca l-am pus in locul radacinii noastre
			t.left = delete(t.data, t.left );
		}
		else
		{
			// Daca are 1 singur fiu il pun pe ala in locul lui
			if( t.left != null )
			{
				t = t.left;
			}
			else
			{
				t = t.right; 
			}
		}
		return balanceAVL(t);
	}
	public int maxLevels()
	{
		return maxLevels(root);
	}
	private int maxLevels(AVLNode t)
	{
		if(t == null)
			return 0;
		else
		{
			int lh = maxLevels(t.left);
			int rh = maxLevels(t.right);
			if(lh > rh)
				return (lh+1);
			else
				return (rh+1);
		}	
	}
	// Function to balance the tree
	private AVLNode balanceAVL(AVLNode t)
	{
		if(t == null)
			return t; 
		
		// Verificam daca avem nevoie de echilibrare pe subarborele stang (cazul stanga)
		if (height(t.left) - height(t.right) >= 2)
		{
				// Verific acm unde e dezechilibrul la subarborele stanga(subarbodele ce e dezechilibrat)
				if (height(t.left.left) >= height(t.left.right)) 
					t = rotateWithLeftChild(t);  // caz 1-stanga , schimbam pe t.right cu t si t devine copilul stang pt t.right
				else
					t = doubleWithLeftChild(t); // caz 2-stanga , facem dubla rotatie
		}
		// Verificam daca avem nevoie de echilibrare pe subarborele drept(cazul drepta)
		else if (height(t.right) - height(t.left) >= 2)
		{
				if (height(t.right.right) >= height(t.right.left))
					t = rotateWithRightChild(t); // caz 1-dreapta , schimbam pe t.right cu t si t devine copilul stang pt t.right
				else
					t = doubleWithRightChild(t); // caz 2-dreapta , facem dubla rotatie
		}
		// Updatam height-ul(ech-ul)
		//System.out.println(t.height);
		//System.out.println(height(t.left)+":"+height(t.right)+" Max : "+max(height(t.left), height(t.right)));
		t.height = max(height(t.left), height(t.right)) + 1;
		return t;
	}
	/* Function to get the predecessor */
	private AVLNode getPredecesor(AVLNode t)
	{
		if(t != null)
		{
			while(t.right != null)
			{
				t = t.right;
			}
		}
		return t;
	}
	/* Rotate binary tree node with left child */
	private AVLNode rotateWithLeftChild(AVLNode k2)
	{
		AVLNode k1 = k2.left;
		k2.left = k1.right;
		k1.right = k2;
		k2.height = max(height(k2.left), height(k2.right)) + 1;
		k1.height = max(height(k1.left), k2.height) + 1;
		return k1;
	}
	/* Rotate binary tree node with right child */
	private AVLNode rotateWithRightChild(AVLNode k1)
	{
		AVLNode k2 = k1.right;
		k1.right = k2.left;
		k2.left = k1;
		k1.height = max(height(k1.left), height(k1.right)) + 1;
		k2.height = max(height(k2.right), k1.height) + 1;
		return k2;
	}
	private AVLNode doubleWithLeftChild(AVLNode k3)
	{
		k3.left = rotateWithRightChild(k3.left);
		return rotateWithLeftChild(k3);
	}
	private AVLNode doubleWithRightChild(AVLNode k1)
	{
		k1.right = rotateWithLeftChild(k1.right);
		return rotateWithRightChild(k1);
	}
	public int countNodes()
	{
		return countNodes(root);
	}
	private int countNodes(AVLNode r)
	{
		if (r == null)
			return 0;
		else
		{
			int l = 1;
			l += countNodes(r.left);
			l += countNodes(r.right);
			return l;
		}
	}
	public boolean search(int val)
	{
		return search(root, val);
	}
	private boolean search(AVLNode r, int val)
	{
		boolean found = false;
		while ((r != null) && !found)
		{
			int rval = r.data;
			if (val < rval)
				r = r.left;
			else if (val > rval)
				r = r.right;
			else
			{
				found = true;
				break;
			}
			found = search(r, val);
		}
		return found;
	}
	public void inorder()
	{
		inorder(root);
	}
	private void inorder(AVLNode r)
	{
		if (r != null)
		{
			inorder(r.left);
			System.out.print(r.data + " ");
			inorder(r.right);
		}
	}
	public void preorder()
	{
		preorder(root);
	}
	private void preorder(AVLNode r)
	{
		if (r != null)
		{
			System.out.print(r.data + " ");
			preorder(r.left);
			preorder(r.right);
		}
	}
	public void postorder()
	{
		postorder(root);
	}
	private void postorder(AVLNode r)
	{
		if (r != null)
		{
			postorder(r.left);
			postorder(r.right);
			System.out.print(r.data + " ");
		}
	}
}