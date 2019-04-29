using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryParseTree
{
    public class ParseTree
    {
        //Class Fields
        readonly char[] tokens = new char[] { '+', '-', '*', '/' };
        string expression = ""; //stores inputted formula
        Node<char> root = null;
        //Node<string> currentNode = null;

        //Default Constructor
        public ParseTree(string expression)
        {
            //int startingIndex = 0;
            this.expression = expression;

            if (expression.Length >= 3)
            {
                BuildTree(expression);
            }
            else
            {
                throw new ArgumentException("Please input a valid non-empty expression");
            }
        }

        //Properties
        private int ExpressionLength
        {
            get
            {
                return this.expression.Length;
            }
        }

        //Methods
        private void BuildTree(string expression)
        {
            //declares a currentNode and index variable
            Node<char> currentNode = new Node<char>(' ', null, null, null);
            int startingIndex = (ExpressionLength - 1);
            bool specialCase = false;
            //iterate through the expression starting at end, working backwards (functions as a stack)
            for (int i = startingIndex; i >= 0; i--)
            {
                char currentValue = expression[i];
                //special case: if i == startingIndex
                //set current node to first value in expression
                //special case equal to true
                if (i == startingIndex)
                {
                    currentNode = new Node<char>(currentValue, null, null, null);
                    specialCase = true;
                }
                //if the current index value reps a operator and parent's right has been used
                //add new node to left
                //set current node
                else if ((currentValue == tokens[0] || currentValue == tokens[1] || currentValue == tokens[2] || currentValue == tokens[3]) && specialCase != true && (currentNode.Right != null))
                {
                    currentNode.Left = new Node<char>(currentValue, currentNode, null, null);
                    currentNode = currentNode.Left;
                }
                //if the current index value reps an operator
                //add new node to right
                //set current node
                else if ((currentValue == tokens[0] || currentValue == tokens[1] || currentValue == tokens[2] || currentValue == tokens[3]))
                {
                    currentNode.Right = new Node<char>(currentValue, currentNode, null, null);
                    currentNode = currentNode.Right;
                    specialCase = false;
                }
                //if the current index value reps a non-operator and the parent's right has been used
                //add a new node to left of parent
                //set current node
                else if ((currentValue != tokens[0] || currentValue != tokens[1] || currentValue != tokens[2] || currentValue != tokens[3]) && (currentNode.Right != null))
                {
                    currentNode.Left = new Node<char>(currentValue, currentNode, null, null);
                    if (currentNode.Parent != null)
                    {
                        currentNode = currentNode.Parent;
                    }
                }
                //if a non-operator 
                //add non-op to right
                //set current node
                else if (currentValue != tokens[0] || currentValue != tokens[1] || currentValue != tokens[2] || currentValue != tokens[3])
                {
                    currentNode.Right = new Node<char>(currentValue, currentNode, null, null);
                    //currentNode = currentNode.Right;
                }
                //if index value now reps zero
                //iterate through the tree to the very first value
                //set value to the class variable root
                if (i == 0)
                {
                    while (currentNode != null)
                    {
                        if(currentNode.Parent == null)
                        {
                            break;
                        }
                        else
                        {
                            currentNode = currentNode.Parent;
                        }
                    }
                    //currentNode = currentNode.Parent;
                    root = currentNode;
                }

            }

            //if index is == to the end of the expression
            //set the currentNode to the last value in the expression
            //else if its an operator
            //add a new right node
            //
            //else if its not an operator
            //add left


            //output an opening paren
            //return call the function again with a decremented index (will output number) and store in output
            //output the operator to the string
            //return call the function again with a decremented index (output number) and set to output
            //output closing paren to string
        }

        public string PreOrder()
        {
            return PreOrderCalc(root);
        }

        private string PreOrderCalc(Node<char> currentNode)
        {
            //create a recursive function that add a node for each value in the expression
            //create an index and set to zero
            //test to see if expression is empty and if current value is a space, if not then continue

            //if the current substring does not equal the operators
            //add two nodes, assign the first to root and generate a second one on the left of root
            //make the second node's value equal the current substring
            //then call this function and increment the index
            //else if the current substring equals one of the operators
            if (currentNode == null)
            {
                return "";
            }
            string buffer = "";
            buffer += currentNode.Value;
            buffer += PreOrderCalc(currentNode.Left);
            buffer += PreOrderCalc(currentNode.Right);
            return buffer;
        }

        public string InOrder()
        {
            return InOrderCalc(root);
        }

        private string InOrderCalc(Node<char> currentNode)
        {
            if (currentNode == null)
            {
                return "";
            }
            string buffer = "";
            if(currentNode.Left != null)
            {
                buffer += "(";
                buffer += InOrderCalc(currentNode.Left);
            }
            buffer += currentNode.Value;
            if(currentNode.Right != null)
            {
                buffer += InOrderCalc(currentNode.Right);
                buffer += ")";
            }
            return buffer;
        }

        public string PostOrder()
        {
            return PostOrderCalc(root);
        }

        private string PostOrderCalc(Node<char> currentNode)
        {
            if (currentNode == null)
            {
                return "";
            }
            string buffer = "";
            if (currentNode.Left != null)
            {
                buffer += PostOrderCalc(currentNode.Left);
            }
            if (currentNode.Right != null)
            {
                buffer += PostOrderCalc(currentNode.Right);
            }
            buffer += currentNode.Value;
            return buffer;
        }

        //JUNK
        /*
            //declare a currentNode and output string variable
            Node<char> currentNode = root;
            string output = "";
            bool nowOnRight = false;
            //walk through to the leaf furthest on the left portion of the tree that is an operator
            while ((currentNode.Left.Value == tokens[0] || currentNode.Left.Value == tokens[1] || currentNode.Left.Value == tokens[2] || currentNode.Left.Value == tokens[3]))
            {
                currentNode = currentNode.Left;
            }
            output += "(";
            while (currentNode != null)
            {
                //use a while loop under the condition that the currentNode is not null

                //if the current node is the root
                //print the root and set current node to right
                if (currentNode == root)
                {
                    output += currentNode.Value;
                    currentNode = currentNode.Right;
                    nowOnRight = true;
                }

                //if current node value is op and has no operator children (to the left of parent)
                //print its left child, itself, then its right child
                //set current node to the parent
                if ((currentNode.Value == tokens[0] || currentNode.Value == tokens[1] || currentNode.Value == tokens[2] || currentNode.Value == tokens[3]) && (currentNode != root) && nowOnRight != true
                && (currentNode.Right.Value != tokens[0] || currentNode.Right.Value != tokens[1] || currentNode.Right.Value != tokens[2] || currentNode.Right.Value != tokens[3]) &&
                (currentNode.Left.Value != tokens[0] || currentNode.Left.Value != tokens[1] || currentNode.Left.Value != tokens[2] || currentNode.Left.Value != tokens[3]))
                {
                    output += "(";
                    output += currentNode.Left.Value;
                    output += currentNode.Value;
                    output += currentNode.Right.Value;
                    output += ")";
                    if (expression.Length == 3)
                    {
                        currentNode = null;
                    }
                    else
                    {
                        currentNode = currentNode.Parent;
                    }
                }
                /*
                //if the current node is an op and has a non-op left child
                    //print the left child and then itself
                    //set the current node to the right child
                else if ((currentNode.Value == tokens[0] || currentNode.Value == tokens[1] || currentNode.Value == tokens[2] || currentNode.Value == tokens[3])
                && (currentNode.Left.Value != tokens[0] || currentNode.Left.Value != tokens[1] || currentNode.Left.Value != tokens[2] || currentNode.Left.Value != tokens[3]))
                {
                    output += currentNode.Left.Value;
                    output += currentNode.Value;
                    currentNode = currentNode.Right;
                }

                //if current node value is a non-op and on the right side of a parent
                    //print value to output string
                    //jump up to grandparent node 
                if ((currentNode.Value != tokens[0] || currentNode.Value != tokens[1] || currentNode.Value != tokens[2] || currentNode.Value != tokens[3]) && (currentNode.Right == currentNode))
                {
                    output += currentNode.Value;
                    if (currentNode.Parent.Parent == null) //tests to see if there is not a secondary operator branch
                        currentNode = currentNode.Parent;
                    else
                        currentNode = currentNode.Parent.Parent;
                }

                //if current node value is op and has an operator child
                    //print itself
                    //set the current node to the right child
                else if ((currentNode.Value == tokens[0] || currentNode.Value == tokens[1] || currentNode.Value == tokens[2] || currentNode.Value == tokens[3])
                && (currentNode.Left.Value != tokens[0] || currentNode.Left.Value != tokens[1] || currentNode.Left.Value != tokens[2] || currentNode.Left.Value != tokens[3]))
                {
                    output += currentNode.Value;
                    currentNode = currentNode.Right;
                }*/


        //if current node value is op, has no operator children, and is to the right of the parent
        //print its left child, itself, then its right child
        //TEST TO SEE IF ON THE RIGHT SIDE OF ROOT
        //use while loop to find current node
        //if current node equals the iter
        //set current node to null
        //otherwise
        //set the current node to the grandparent (meaning that the parsing process is not over)
        //use while loop to find current node 
        /*
        else if ((currentNode.Value == tokens[0] || currentNode.Value == tokens[1] || currentNode.Value == tokens[2] || currentNode.Value == tokens[3]) && (currentNode.Parent.Right == currentNode)
        && (currentNode.Right.Value != tokens[0] || currentNode.Right.Value != tokens[1] || currentNode.Right.Value != tokens[2] || currentNode.Right.Value != tokens[3]) &&
        (currentNode.Left.Value != tokens[0] || currentNode.Left.Value != tokens[1] || currentNode.Left.Value != tokens[2] || currentNode.Left.Value != tokens[3]))
        {
            output += "(";
            output += currentNode.Left.Value;
            output += currentNode.Value;
            output += currentNode.Right.Value;
            output += ")";
            output += ")";
            currentNode = currentNode.Parent.Parent; //this could change
            Node<char> temp = root;
            while (temp != null)
            {
                if (temp == currentNode)
                {
                    currentNode = null; //breaks the loop and ends the traversal, only occurs if the node being processed is the last operator on the right side
                }
                temp = temp.Right;
            }
        }


    }
    return (string)output;
        //if current node value is a non-op and on left side of a parent
        //output value to output string
        //set the currentnode to the parent
        /*if ((currentNode.Value != tokens[0] || currentNode.Value != tokens[1] || currentNode.Value != tokens[2] || currentNode.Value != tokens[3]) && (currentNode.Parent.Left == currentNode))
           {
               output += currentNode.Value;
               currentNode = currentNode.Parent;
           }*/
    }
}
