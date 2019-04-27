using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryParseTree
{
    public class Node<T>
    {
        //Class Fields
        private T value;

        //Defined and Default Constructor
        public Node(T v, Node<T> parent, Node<T> left, Node<T> right)
        {
            this.value = v; //actual value stored in the node/link
            this.Right = right; //sets the right value of the node in the tree
            this.Left = left; //sets the left value of the node in the tree
            this.Parent = parent; //sets the parent value of the node in the tree
        }

        //Properties
        public T Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }

        public Node<T> Parent { get; set; } = null;

        public Node<T> Right { get; set; } = null;

        public Node<T> Left { get; set; } = null;

        public override string ToString()
        {
            return this.value.ToString();
        }
    }
}
