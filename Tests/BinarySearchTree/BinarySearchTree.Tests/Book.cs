using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree.Tests
{
    public class Book : IComparable<Book>
    {
        public readonly string Title;

        public Book(string title)
        {
            Title = title;
        }

        public int CompareTo(Book other) =>
            ReferenceEquals(other, null) ? 1 :
            string.CompareOrdinal(this.Title, other.Title);
    }
}
