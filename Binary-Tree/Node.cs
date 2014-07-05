using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Tree
{
    class Node
    {
        public int data = 0;
        public string label;
        public int degree = 0;
        public Node left = null;
        public Node right = null;

        public Node(int data) {
            this.data = data;
        }

        public Node(int data, string label) {
            this.label = label;
            this.data = data;
        }
    }
}
