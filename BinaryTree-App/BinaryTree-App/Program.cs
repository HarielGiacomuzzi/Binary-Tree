using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Binary_Tree;

namespace BinaryTree_App
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree tree = new BinaryTree();

            tree.insert(10);
            tree.insert(11);
            tree.insert(12);
            tree.insert(9);
            tree.insert(8);

            Console.WriteLine(tree.preOrderPrint());
            Console.WriteLine(tree.inOrderPrint());
            Console.WriteLine(tree.postOrderPrint());

            tree.CreateGraphVizFile("D:\\Tree.txt"); ;

            Console.ReadKey();
        }
    }
}
