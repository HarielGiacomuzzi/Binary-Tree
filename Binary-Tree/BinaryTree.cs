using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Binary_Tree
{
    public class BinaryTree
    {
        Node root = null;
        Node NodeNull = new Node(0);

        public BinaryTree(){
            NodeNull.degree = 0;
            NodeNull.left = NodeNull;
            NodeNull.right = NodeNull;
        }

        public string preOrderPrint() {
            return preOrderPrint("",root);
        }

        public string inOrderPrint() {
            return inOrderPrint("", root);
        }

        private string inOrderPrint(string s, Node n) {
            if (n == NodeNull) { return s; }
            s = inOrderPrint(s, n.left);
            s = s + " - " + n.data;
            s = inOrderPrint(s,n.right);
            return s;
        }

        public string postOrderPrint() {
            return postOrderPrint("",root);
        }

        private string postOrderPrint(string s, Node n) {
            if (n == NodeNull) { return s; }
            s = postOrderPrint(s, n.left);
            s = postOrderPrint(s, n.right);
            s = s + " - " + n.data;
            return s;
        }

        private string preOrderPrint(string s, Node n) {
            if (n == NodeNull) { return s; }
            s = s + " - "+n.data;
            s = preOrderPrint(s, n.left);
            s = preOrderPrint(s, n.right);
            return s;
        }

        public void insert (int i){
            Node a = new Node(i);
            a.degree = 1;
            a.left = NodeNull;
            a.right = NodeNull;
            if (root == null) {
                root = a;
                return;
            }
            root = insert(a,root);
        }

        private Node insert(Node n, Node x) {
            if (x == NodeNull) {
                return n;
            }
            if (n.data > x.data)
            {
                x.right = insert(n, x.right);
                x = skew(x);
                x = split(x);
                return x;
            }
            else {
                x.left = insert(n, x.left);
                x = skew(x);
                x = split(x);
                return x;
            }
        } 


        private Node split(Node n) {
            if (n.right.right.degree == n.degree) {
                Node aux = n.right;
                n.right = aux.left;
                aux.left = n;
                aux.degree++;
                return aux;
            }
            return n;
        }

        private Node skew(Node n) { 
            if(n.left.degree == n.degree){
                Node aux = n.left;
                n.left = aux.right;
                aux.right = n;
                return aux;
            }
            return n;
        }

        public void CreateGraphVizFile(string where){
            StreamWriter writer = new StreamWriter(where,false);
            string fileContent = "digraph BST{"+GraphVizFile("", root)+"\n}"; 
            writer.Write(fileContent);
            writer.Close();
        }

        private string GraphVizFile(string s,Node n) {
            if (n == NodeNull) {
                return s;
            }
            if (n.left == NodeNull)
            {
                s = s + "\n null0" + " [shape=point];";
                s = s + "\n" + n.data + " -> " + "null0";
            }
            else
            {
                s = s + "\n" + n.data + " -> " + n.left.data;
            }

            if (n.right == NodeNull)
            {
                s = s + "\n null0"+ " [shape=point];";
                s = s + "\n" + n.data + " -> " + "null0";
            }
            else
            {
                s = s + "\n" + n.data + " -> " + n.right.data;
            }

            s = GraphVizFile(s, n.left);
            s = GraphVizFile(s, n.right);
            return s;
        }

    }
}
