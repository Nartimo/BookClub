using System;
using System.Collections.Generic;
using System.Text;

namespace BookClub.BusinessEntity.Entities
{
    public class Review : BaseEntity
    {
        public Book Book { get; }
        public Member Member { get; }
        public int Rating { get; private set; }
        public string Comment { get; private set; }
        public DateTime Timestamp { get; private set; }

        public Review(
            string id,
            Book book,
            Member member,
            int rating,
            string comment,
            DateTime timestamp) 
            : base(id)
        {
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book), "Book cannot be null");
            }
            if (member == null)
            {
                throw new ArgumentNullException(nameof(member), "Member cannot be null");
            }

            ValidateRating(rating);

            Book = book;
            Member = member;
            Rating = rating;
            Comment = comment ?? string.Empty;
            Timestamp = timestamp;
        }

        public void UpdateReview(
            int rating,
            string comment,
            DateTime timestamp)
        {
            ValidateRating(rating);

            if (timestamp < Timestamp)
            {
                throw new ArgumentException(
                    "The review timestamp cannot precede its previous timestamp.",
                    nameof(timestamp));
            }

            Rating = rating;
            Comment = comment ?? string.Empty;
            Timestamp = timestamp;
        }

        private static void ValidateRating(int rating)
        {
            if (rating < 1 || rating > 10)
            {
                throw new ArgumentOutOfRangeException(nameof(rating), "Rating must be between 1 and 10");
            }
        }
    }
}
