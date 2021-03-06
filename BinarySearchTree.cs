using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    //Creating binary search tree using generics and IComparable to use CompareTo method
    public class BinarySearchTree<T> where T : IComparable<T>
    {
        //Intializing variables
        public int leftCount, rightCount;
        public bool result = false;

        //Declaring Properties
        public T nodeData { get; set; }
        public BinarySearchTree<T> leftTree { get; set; }
        public BinarySearchTree<T> rightTree { get; set; }

        //Parameterized Constructor
        public BinarySearchTree(T nodeData)
        {
            this.nodeData = nodeData;
            this.leftTree = null;
            this.rightTree = null;
        }
        //Method to check node and add node value to left or right by comparing
        public void Insert(T data)
        {
            T currentNodeValue = nodeData;
            if ((data.CompareTo(currentNodeValue)) < 0)
            {
                if (this.leftTree == null)
                {
                    this.leftTree = new BinarySearchTree<T>(data);
                    leftCount++;
                }
                else
                { 
                    this.leftTree.Insert(data);
                    leftCount++;
                }
            }
            else
            {
                if (this.rightTree == null)
                {
                    this.rightTree = new BinarySearchTree<T>(data);
                    rightCount++;
                }
                else
                { 
                    this.rightTree.Insert(data);
                    rightCount++;
                }
            }
        }

        //Displaying the data in binary tree
        public void Display()
        {
            if (this.leftTree != null)
            {
                this.leftTree.Display();
            }
            Console.Write(this.nodeData.ToString() + " ");
            if (this.rightTree != null)
            {
                this.rightTree.Display();
            }
        }

        //Get the size of binary tree
        public void GetSIze()
        {
            Console.WriteLine("\nSize of Binary Tree is : "  + (this.leftCount + this.rightCount + 1 ));
        }

        //search for an element in binary tree
        public bool IfValueExists(T element, BinarySearchTree<T> node)
        {
            if (node == null)
            {
                return false;
            }
            if (node.nodeData.Equals(element))
            {
                Console.WriteLine("\nFound the element in BST : " +" " + node.nodeData);
                result = true;
            }
            else
            {
                Console.WriteLine("\nCurrent element is {0} in BST  ", node.nodeData);
            }
            if (element.CompareTo(node.nodeData) < 0)
            {
                IfValueExists(element, node.leftTree);
            }
            if (element.CompareTo(node.nodeData) > 0)
            {
                IfValueExists(element, node.rightTree);
            }
            return result;
        }
    }
}