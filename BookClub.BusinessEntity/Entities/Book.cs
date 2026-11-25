using System;
using System.Collections.Generic;
using System.Text;

namespace BookClub.BusinessEntity.Entities
{
    public class Book : BaseEntity
    {
        public string Title { get; private set; }
        public string Author { get; private set; }
        public string ISBN { get; private set; }
        public int PublishedYear { get; private set; }
        public Category Category { get; private set; }
        public bool Active { get; private set; }
        public Book(string id, string title, string author, string isbn, int publishedYear, Category category, bool active=true) : base(id)
        {
            ValidateDetails(title, author, isbn, publishedYear, category);
            Title = title;
            Author = author;
            ISBN = isbn;
            PublishedYear = publishedYear;
            Category = category ?? throw new ArgumentNullException(nameof(category), "Category cannot be null");
            Active = active;
        }

        public void UpdateDetails(string title, string author, string isbn, int publishedYear, Category category)
        {
            ValidateDetails(title, author, isbn, publishedYear, category);
            Title = title;
            Author = author;
            ISBN = isbn;
            PublishedYear = publishedYear;
            Category = category ?? throw new ArgumentNullException(nameof(category), "Category cannot be null");
        }

        public void Deactivate()
        {
            Active = false;
        }

        private static void ValidateDetails(string title, string author, string isbn, int publishedYear, Category category)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentException("Book title cannot be empty", nameof(title));
            }

            if (string.IsNullOrEmpty(author))
            {
                throw new ArgumentException("Author cannot be empty", nameof(author));
            }

            if (string.IsNullOrEmpty(isbn))
            {
                throw new ArgumentException("ISBN cannot be empty", nameof(isbn));
            }

            if (publishedYear <= 0)
            {
                throw new ArgumentException("Published year must be positive", nameof(publishedYear));
            }

            ArgumentNullException.ThrowIfNull(category);
        }
    }
}
