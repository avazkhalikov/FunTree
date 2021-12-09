using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunTree.Models
{
    public class Node
    {

        public int data;
        public Node left, right;

        public Node(int d)
        {
            data = d;
            left = right = null;
        }
    }

    public class BinaryTree
    {
        //what is Root? to hold on to your chain and be able to pass it ...to have a starting point to traverse!    
        public Node Add(int value, Node root)
        {
            //check if the root exists, if not the new item becomes it.
            Node newNode = new Node(value);

            if (root == null) //root is set, which is always going to hold our tree.
            {
                return newNode;   //newNode becomes root and returned!             
            }
            else {

                if (root.data < value)
                {
                    if (root.right == null)
                    {
                        root.right = newNode;
                    }
                    else
                    {
                            Add(value, root.right);  //recursively return current node to next insert!~
                    }
                }
                if (root.data > value)
                {
                    if (root.left == null)
                    {
                        root.left = newNode;
                    }
                    else
                    {
                        Add(value, root.left);  //recursively return current node to next insert!~
                    }
                }


            }

            return root; 
                        
        }



        public void getMyTree()
        { 
        
        }
    }
}
