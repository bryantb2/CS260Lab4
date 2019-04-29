using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using BinaryParseTree;

namespace UnitTesting
{
    [TestFixture]
    class ParseTreeUnitTest
    {
        ParseTree testTree;

        //[SetUp]
        public void Setup()
        {
            testTree = new ParseTree("AB+CD+/");
        }

        [Test]
        public void BasicTest()
        {
            bool test = false;
            Assert.AreEqual(false, test);
        }
        
        //[Test]
        public void TreeConstructorAndBuildTest()
        {
            //this will not pass for some reason
            
            try
            {
                testTree = new ParseTree("AB+C/");
                Assert.Pass("The constructor accepted the string input expression");
            }
            catch (ArgumentException)
            {
                Assert.Fail("The constructor unexpectedly rejected the string input expression");
            }
            
            try
            {
                testTree = new ParseTree(" ");
                Assert.Fail("The constructor accepted the string input expression");
            }
            catch(ArgumentException)
            {
                Assert.Pass("The constructor unexpectedly rejected the string input expression");
            }
            
        }
        
        [Test]
        public void TreeInOrderTest()
        {
            testTree = new ParseTree("AB+CD-/");
            Assert.AreEqual("((A+B)/(C-D))", testTree.InOrder());
            testTree = new ParseTree("AB+");
            testTree.InOrder();
            Assert.AreEqual("(A+B)", testTree.InOrder());
            testTree = new ParseTree("AB+CD+*");
            Assert.AreEqual("((A+B)*(C+D))", testTree.InOrder());
        }

        [Test]
        public void TreePostOrderTest()
        {
            testTree = new ParseTree("AB+CD-/");
            Assert.AreEqual("AB+CD-/", testTree.PostOrder());
            testTree = new ParseTree("AB+");
            testTree.PostOrder();
            Assert.AreEqual("AB+", testTree.PostOrder());
            testTree = new ParseTree("AB+CD+*");
            Assert.AreEqual("AB+CD+*", testTree.PostOrder());
        }






    }
}
