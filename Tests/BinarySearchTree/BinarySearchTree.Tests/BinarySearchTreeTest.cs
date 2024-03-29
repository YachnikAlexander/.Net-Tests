﻿using System;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using BinarySearchTree;

namespace BinarySearchTree.Tests
{
    [TestFixture]
    public class BinarySearchTreeTest
    {
        [Test]
        public void AddIntTest()
        {
            var array = new[] { 100, 130, 50 };
            var tree = new BinarySearchTree<int>(array);
            Assert.AreEqual(array.Length, tree.Count);
            tree.Add(140);

            var items = tree.ToArray();
            Assert.AreEqual(array.Length + 1, items.Length);
            int i = 0;
            Assert.AreEqual(100, items[i++]);
            Assert.AreEqual(50, items[i++]);
            Assert.AreEqual(130, items[i++]);
            Assert.AreEqual(140, items[i]);
        }

        [TestCase(new[] { 1, 2, 3, 7, 5 }, 5, ExpectedResult = true)]
        [TestCase(new[] { 1, 2, 3, 7, 5 }, 1, ExpectedResult = true)]
        [TestCase(new[] { 1, 2, 3, 7, 5 }, 77, ExpectedResult = false)]
        public bool ContainsIntTest(int[] array, int item) =>
            new BinarySearchTree<int>(array).Contains(item);

        [Test]
        public void OrderIntTest()
        {
            var array = new[] { 100, 130, 50, 25, 70, 140 };
            var tree = new BinarySearchTree<int>(array);

            VerifyOrder(new[] { 100, 50, 25, 70, 130, 140 }, tree.GetPreorderEnumerator, (i, i1) => Assert.AreEqual(i, i1));

            VerifyOrder(new[] { 25, 50, 70, 100, 130, 140 }, tree.GetInorderEnumerator, (i, i1) => Assert.AreEqual(i, i1));

            VerifyOrder(new[] { 25, 70, 50, 140, 130, 100 }, tree.GetPostorderEnumerator, (i, i1) => Assert.AreEqual(i, i1));

            tree = new BinarySearchTree<int>((i1, i2) =>
            {
                if (i1 == i2) return 0;
                if (i1 > i2) return 1;
                return -1;
            }, array);

            VerifyOrder(new[] { 100, 50, 25, 70, 130, 140 }, tree.GetPreorderEnumerator, (i, i1) => Assert.AreEqual(i, i1));

            VerifyOrder(new[] { 25, 50, 70, 100, 130, 140 }, tree.GetInorderEnumerator, (i, i1) => Assert.AreEqual(i, i1));

            VerifyOrder(new[] { 25, 70, 50, 140, 130, 100 }, tree.GetPostorderEnumerator, (i, i1) => Assert.AreEqual(i, i1));
        }

        [Test]
        public void AddStringTest()
        {
            var array = new[] { "DDD", "BBB", "AAA", "CCC", "EEE" };
            var tree = new BinarySearchTree<string>(array);
            Assert.AreEqual(array.Length, tree.Count);
            tree.Add("FFF");

            var items = tree.ToArray();
            Assert.AreEqual(array.Length + 1, items.Length);
            int i = 0;
            Assert.AreEqual("DDD", items[i++]);
            Assert.AreEqual("BBB", items[i++]);
            Assert.AreEqual("AAA", items[i++]);
            Assert.AreEqual("CCC", items[i++]);
            Assert.AreEqual("EEE", items[i++]);
            Assert.AreEqual("FFF", items[i]);
        }

        [TestCase(new[] { "DDD", "EEE", "FFF", "BBB", "AAA", "CCC" }, "DDD", ExpectedResult = true)]
        [TestCase(new[] { "DDD", "EEE", "FFF", "BBB", "AAA", "CCC" }, "AAA", ExpectedResult = true)]
        [TestCase(new[] { "DDD", "EEE", "FFF", "BBB", "AAA", "CCC" }, "REW", ExpectedResult = false)]
        public bool ContainsStringTest(string[] array, string item) =>
            new BinarySearchTree<string>(array).Contains(item);

        [Test]
        public void OrderStringTest()
        {
            var array = new[] { "DDD", "EEE", "FFF", "BBB", "AAA", "CCC" };
            var tree = new BinarySearchTree<string>(array);

            VerifyOrder(new[] { "DDD", "BBB", "AAA", "CCC", "EEE", "FFF" }, tree.GetPreorderEnumerator, StringAssert.AreEqualIgnoringCase);

            VerifyOrder(new[] { "AAA", "BBB", "CCC", "DDD", "EEE", "FFF" }, tree.GetInorderEnumerator, StringAssert.AreEqualIgnoringCase);

            VerifyOrder(new[] { "AAA", "CCC", "BBB", "FFF", "EEE", "DDD" }, tree.GetPostorderEnumerator, StringAssert.AreEqualIgnoringCase);

            tree = new BinarySearchTree<string>((i1, i2) => string.Compare(i1, i2, StringComparison.Ordinal), array);

            VerifyOrder(new[] { "DDD", "BBB", "AAA", "CCC", "EEE", "FFF" }, tree.GetPreorderEnumerator, StringAssert.AreEqualIgnoringCase);

            VerifyOrder(new[] { "AAA", "BBB", "CCC", "DDD", "EEE", "FFF" }, tree.GetInorderEnumerator, StringAssert.AreEqualIgnoringCase);

            VerifyOrder(new[] { "AAA", "CCC", "BBB", "FFF", "EEE", "DDD" }, tree.GetPostorderEnumerator, StringAssert.AreEqualIgnoringCase);
        }

        [Test]
        public void OrderBookTest()
        {
            var array = new[] { new Book("DDD"), new Book("EEE"), new Book("FFF"), new Book("BBB"), new Book("AAA"), new Book("CCC") };
            var tree = new BinarySearchTree<Book>(array);

            VerifyOrder(new[] { new Book("DDD"), new Book("BBB"), new Book("AAA"), new Book("CCC"), new Book("EEE"), new Book("FFF") },
                tree.GetPreorderEnumerator, (book, book1) => StringAssert.AreEqualIgnoringCase(book.Title, book1.Title));

            VerifyOrder(new[] { new Book("AAA"), new Book("BBB"), new Book("CCC"), new Book("DDD"), new Book("EEE"), new Book("FFF") },
                tree.GetInorderEnumerator, (book, book1) => StringAssert.AreEqualIgnoringCase(book.Title, book1.Title));

            tree = new BinarySearchTree<Book>((i1, i2) => string.Compare(i1.Title, i2.Title, StringComparison.Ordinal), array);

            VerifyOrder(new[] { new Book("DDD"), new Book("BBB"), new Book("AAA"), new Book("CCC"), new Book("EEE"), new Book("FFF") },
                tree.GetPreorderEnumerator, (book, book1) => StringAssert.AreEqualIgnoringCase(book.Title, book1.Title));

            VerifyOrder(new[] { new Book("AAA"), new Book("BBB"), new Book("CCC"), new Book("DDD"), new Book("EEE"), new Book("FFF") },
                tree.GetInorderEnumerator, (book, book1) => StringAssert.AreEqualIgnoringCase(book.Title, book1.Title));
        }

        [Test]
        public void AddBookTest()
        {
            var array = new[] { "DDD", "BBB", "AAA", "CCC", "EEE" };
            var tree = new BinarySearchTree<string>(array);
            Assert.AreEqual(array.Length, tree.Count);
            tree.Add("FFF");

            var items = tree.ToArray();
            Assert.AreEqual(array.Length + 1, items.Length);
            int i = 0;
            Assert.AreEqual("DDD", items[i++]);
            Assert.AreEqual("BBB", items[i++]);
            Assert.AreEqual("AAA", items[i++]);
            Assert.AreEqual("CCC", items[i++]);
            Assert.AreEqual("EEE", items[i++]);
            Assert.AreEqual("FFF", items[i]);
        }

        [Test]
        public void ContainsBookTest()
        {
            var array = new[] { new Book("DDD"), new Book("EEE"), new Book("FFF"), new Book("BBB"), new Book("AAA"), new Book("CCC") };
            var tree = new BinarySearchTree<Book>(array);

            Assert.IsTrue(tree.Contains(new Book("DDD")));
            Assert.IsTrue(tree.Contains(new Book("EEE")));
            Assert.IsTrue(tree.Contains(new Book("AAA")));
            Assert.IsFalse(tree.Contains(new Book("ww")));
        }

        [Test]
        public void OrderPointTest()
        {
            Comparison<Point> comparer = (p1, p2) =>
            {
                if (p1.X > p2.X) return 1;
                if (p1.X == p2.X) return 0;
                return -1;
            };

            var array = new[]
            {
                new Point(100, 10), new Point(50, 15), new Point(25, 7), new Point(70, 88), new Point(130, 4), new Point(140, 68)
            };

            var tree = new BinarySearchTree<Point>(comparer, array);

            VerifyOrder(new[] { new Point(100, 10), new Point(50, 15), new Point(25, 7), new Point(70, 88), new Point(130, 4), new Point(140, 68) },
                tree.GetPreorderEnumerator, (p1, p2) => Assert.AreEqual(p1.X, p2.X));

            VerifyOrder(new[] { new Point(25, 7), new Point(50, 15), new Point(70, 88), new Point(100, 10), new Point(130, 4), new Point(140, 68) },
                tree.GetInorderEnumerator, (p1, p2) => Assert.AreEqual(p1.X, p2.X));

            VerifyOrder(new[] { new Point(25, 7), new Point(70, 88), new Point(50, 15), new Point(140, 68), new Point(130, 4), new Point(100, 10) },
                tree.GetPostorderEnumerator, (p1, p2) => Assert.AreEqual(p1.X, p2.X));
        }

        [Test]
        public void ContainsPointTest()
        {
            Comparison<Point> comparer = (p1, p2) =>
            {
                if (p1.X > p2.X) return 1;
                if (p1.X == p2.X) return 0;
                return -1;
            };

            var array = new[]
            {
                new Point(100, 10), new Point(50, 15), new Point(25, 7), new Point(70, 88), new Point(130, 4), new Point(140, 68)
            };

            var tree = new BinarySearchTree<Point>(comparer, array);

            Assert.IsTrue(tree.Contains(new Point(50, 15)));
            Assert.IsTrue(tree.Contains(new Point(25, 7)));
            Assert.IsTrue(tree.Contains(new Point(130, 4)));
            Assert.IsFalse(tree.Contains(new Point(88, 888)));
        }

        [TestCase(new[] { 100, 130, 50, 25, 70, 140, 120 }, 140, ExpectedResult = new[] { 100, 50, 25, 70, 130, 120 })]
        [TestCase(new[] { 100, 130, 50, 25, 70, 140, 120 }, 25, ExpectedResult = new[] { 100, 50, 70, 130, 120, 140 })]
        [TestCase(new[] { 100, 130, 50, 25, 70, 140, 120 }, 100, ExpectedResult = new[] { 120, 50, 25, 70, 130, 140 })]
        [TestCase(new[] { 100, 130, 50, 25, 70, 140, 120 }, 130, ExpectedResult = new[] { 100, 50, 25, 70, 140, 120 })]
        [TestCase(new[] { 100, 130, 50, 25, 70, 140, 120 }, 1500, ExpectedResult = new[] { 100, 50, 25, 70, 130, 120, 140 })]
        public int[] RemoveTest(int[] array, int item)
        {
            var tree = new BinarySearchTree<int>(array);
            tree.Remove(item);

            var temp = tree.ToArray();
            return temp;
        }

        private static void VerifyOrder<T>(IReadOnlyList<T> items, Func<IEnumerable<T>> getEnumerator, Action<T, T> assert)
        {
            int i = 0;
            foreach (var item in getEnumerator())
            {
                assert(items[i], item);
                i++;
            }
        }
    }
}
