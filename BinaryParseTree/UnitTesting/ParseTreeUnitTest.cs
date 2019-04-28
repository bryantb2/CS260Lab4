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
        ParseTree testTree2;

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
        
        [Test]
        public void TreeConstructorAndBuildTest()
        {
            /*
            try
            {
                testTree = new ParseTree(" ");
                Assert.Fail("The constructor accepted the string input expression");
            }
            catch(Exception)
            {
                Assert.Pass("The constructor unexpectedly rejected the string input expression");
            }*/

            try
            {
                testTree2 = new ParseTree("AB+");
                Assert.Pass("The constructor accepted the string input expression");
            }
            catch (Exception)
            {
                Assert.Fail("The constructor unexpectedly rejected the string input expression");
            }
        }
        /*
        //[Test]
        public void TreeInOrderTest()
        {
            Assert.AreEqual("((A+B))/(C-D)", testTree.InOrder());
        }*/



    }
}
