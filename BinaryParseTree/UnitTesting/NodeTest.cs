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
    public class NodeTest
    {
        Node<string> link1;
        Node<string> link2;
        Node<string> link3;

        [SetUp]
        public void Setup()
        {
            link1 = new Node<string>("*", null, link2, link3);
            link2 = new Node<string>("1", link1, null, null);
            link3 = new Node<string>("3", link1, null, null);
        }

        [Test]
        public void BasicTest()
        {
            Assert.AreEqual(true, true);
        }

        [Test]
        public void ValueGetterSetterTest()
        {
            //Getters
            Assert.AreEqual("*", link1.Value);
            Assert.AreEqual("1", link2.Value);
            Assert.AreEqual("3", link3.Value);
            //Setters
            link1.Value = "+";
            link2.Value = "18";
            link3.Value = "100";
            Assert.AreEqual("+", link1.Value);
            Assert.AreEqual("18", link2.Value);
            Assert.AreEqual("100", link3.Value);
        }

        [Test]
        public void ParentSetterGetterTest()
        {
            //Setters
            link2.Parent = link1;
            link3.Parent = link2;
            //Getters
            Assert.AreEqual(link1, link2.Parent);
            Assert.AreEqual(link2, link3.Parent);
        }

        [Test]
        public void LeftSetterGetterTest()
        {
            //Setters
            link2.Left = link1;
            link3.Left = link2;
            //Getters
            Assert.AreEqual(link1, link2.Left);
            Assert.AreEqual(link2, link3.Left);
        }

        [Test]
        public void RightSetterGetterTest()
        {
            //Setters
            link2.Right = link1;
            link3.Right = link2;
            //Getters
            Assert.AreEqual(link1, link2.Right);
            Assert.AreEqual(link2, link3.Right);
        }
    }
}
