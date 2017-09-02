using NUnit.Framework;

namespace BashSoftTesting
{
    using System;

    using BashSoft.Contracts;
    using BashSoft.DataStructures;

    [TestFixture]
    public class OrderedDataStructureTester
    {
        private ISimpleOrderedBag<string> names;

        [Test]
        public void TestEmptyCtor()
        {
            this.names = new SimpleSortedList<string>();
            Assert.AreEqual(16, this.names.Capacity);
            Assert.AreEqual(0, this.names.Size);
        }

        [Test]
        public void TestCtorwithInitialCapacity()
        {
            this.names = new SimpleSortedList<string>(20);
            Assert.AreEqual(20, this.names.Capacity);
            Assert.AreEqual(0, this.names.Size);
        }

        [Test]
        public void TestCtorWithAllParams()
        {
            this.names = new SimpleSortedList<string>(StringComparer.OrdinalIgnoreCase, 30);
            Assert.AreEqual(30, this.names.Capacity);
            Assert.AreEqual(0, this.names.Size, 0);
        }

        [Test]
        public void TestCtorWithInitialComparer()
        {
            this.names = new SimpleSortedList<string>(StringComparer.OrdinalIgnoreCase);
            Assert.AreEqual(16, this.names.Capacity);
            Assert.AreEqual(0, this.names.Size);
        }

        [SetUp]
        public void SetUp()
        {
            this.names = new SimpleSortedList<string>();
        }

        [Test]
        public void TestAddIncreaseSize()
        {
            this.names.Add("Nasko");
            Assert.AreEqual(1, this.names.Size);
        }

        [Test]
        public void TestAddNullThrowsException()
        {
            Assert.Throws<NullReferenceException>(() => this.names.Add(null));
        }

        [Test]
        public void TestAddUnsortedDataIsHeldSorted()
        {
            this.names.Add("Georgi");
            this.names.Add("Rosen");
            this.names.Add("Balkan");

            CollectionAssert.IsOrdered(this.names);
        }

        [Test]
        public void TestAddingMoreThanInitialCapacity()
        {
            this.names = new SimpleSortedList<string>();

            for (int i = 0; i < 17; i++)
            {
                this.names.Add("foo");
            }

            Assert.AreEqual(17, this.names.Size);
            Assert.AreNotEqual(16, this.names.Capacity);
        }

        [Test]
        public void TestAddingAllFromCollectionIncreasesSize()
        {
            var testNames = new[] { "foo", "bar" };

            this.names.AddAll(testNames);

            Assert.AreEqual(2, this.names.Size);
        }

        [Test]
        public void TestAddingAllFromNullThrowsException()
        {
            Assert.Throws<NullReferenceException>(() => this.names.AddAll(null));
        }

        [Test]
        public void TestAddAllKeepsSorted()
        {
            var testNames = new[] { "Bbb", "Aaa", "Ccc" };
            this.names.AddAll(testNames);

            CollectionAssert.IsOrdered(this.names);
        }

        [Test]
        public void TestRemoveValidElementDecreasesSize()
        {
            var testNames = new[] { "Bbb", "Aaa", "Ccc" };
            this.names.AddAll(testNames);
            int currentSize = names.Size;  
            
            // remove one element
            this.names.Remove("Bbb");
            int expectedSize = currentSize - 1;

            Assert.AreEqual(expectedSize,names.Size);
        }

        [Test]
        public void TestRemoveValidElementRemovesSelectedOne()
        {
            var firstElement = "Aaa";
            var secondElement = "Bbb";
            this.names.Add(firstElement);
            this.names.Add(secondElement);
            
            // remove second element
            this.names.Remove(secondElement);

            Assert.That(this.names, Has.No.Member(secondElement));
        }

        [Test]
        public void TestRemovingNullThrowsException()
        {
            Assert.Throws<NullReferenceException>(() => this.names.Remove(null));
        }

        [Test]
        public void TestJoinWithNull()
        {
            var firstElement = "Aaa";
            var secondElement = "Bbb";
            this.names.Add(firstElement);
            this.names.Add(secondElement);

            Assert.Throws<ArgumentNullException>(() => this.names.JoinWith(null));
        }

        [Test]
        public void TestJoinWorksFine()
        {
            var testNames = new[] { "Bbb", "Aaa", "Ccc" };
            this.names.AddAll(testNames);
            string result;
            Assert.DoesNotThrow(() => result = this.names.JoinWith(",,"));
            Console.WriteLine(this.names);
        }

        [Test]
        public void TestJoinDontAddJoinerAtTheEnd()
        {
            var testNames = new[] { "Bbb", "Aaa", "Ccc" };

            this.names.AddAll(testNames);
            string result = this.names.JoinWith(",,,");

            Assert.IsTrue(result.EndsWith("Ccc"));
        }
    }
}
