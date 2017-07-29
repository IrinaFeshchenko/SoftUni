using System;
using System.Collections;
using System.Collections.Generic;

public class Library:IEnumerable<Book>
{
    private readonly SortedSet<Book> books;

    public Library(params Book[] books)
    {
        this.books = new SortedSet<Book>(books,new BookComparator());
    }

    public IEnumerator<Book> GetEnumerator()
    {
        return new LibraryIterator(this.books);
    }

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

    private class LibraryIterator:IEnumerator<Book>
    {

        private readonly IList<Book> books;

        private int index;

        public LibraryIterator(IEnumerable<Book> books)
        {
            this.books = new List<Book>(books);
            this.Reset();
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            return ++index < this.books.Count;
        }

        public void Reset()
        {
            this.index=-1;
        }

        public Book Current => this.books[index];

        object IEnumerator.Current => this.Current;
    }
}
