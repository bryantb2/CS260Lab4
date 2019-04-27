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
        readonly string[] tokens = new string[] { "+", "-", "*", "/" };
        string expression; //stores inputted formula
        Node<string> root = null;
        Node<string> currentNode = null;

        //Default Constructor
        public ParseTree(string expression)
        {
            int startingIndex = 0;
            this.expression = expression;
            if (expression != "")
            {
                if (!BuildTree(startingIndex))
                {
                    throw new Exception("Could not build the parse tree");
                }
            }
            else
            {
                throw new Exception("Please input a valid non-empty expression");
            }

        }

        //Methods
        public bool BuildTree(int expressionIndexer)
        {
            //create a recursive function that add a node for each value in the expression
            //create an index and set to zero
            //test to see if expression is empty and if current value is a space, if not then continue

            //if the current substring does not equal the operators
            //add two nodes, assign the first to root and generate a second one on the left of root
            //make the second node's value equal the current substring
            //then call this function and increment the index
            //else if the current substring equals one of the operators
            //

            if (expression.Substring(expressionIndexer) != " ")
            {
            }
            else
            {
                return BuildTree(expressionIndexer + 1);
            }
        }

        public string PreOrder()
        {
            return "";
        }

        public string InOrder()
        {
            //this will return an infix expression
            
            //pass in index and output string
            //if its an operator
                //output an opening paren
                //return call the function again with a decremented index (will output number) and store in output
                //output the operator to the string
                //return call the function again with a decremented index (output number) and set to output
                //output closing paren to string
            //if num
                //output the number
                //return (jumps into parent node)

            return "";
        }

        public string PostOrder()
        {
            return "";
        }
    }
}
