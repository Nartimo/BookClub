using System;
using System.Collections.Generic;
using System.Text;

namespace BookClub.BusinessEntity.Entities
{
    public class Event : BaseEntity
    {
        public Club Club { get; }
        public Book Book { get; }
        public string Title { get; }
        public DateTime Date { get; }
        public string Location { get; }
        public int MaxParticipants { get; }
        public DateTime RegistrationDeadline { get; }
        public bool Active { get; private set; }

        public Event(
            string id,
            Club club,
            Book book,
            string title,
            DateTime date,
            string location,
            int maxParticipants,
            DateTime registrationDeadline,
            bool active = true)
            : base(id)
        {
            ArgumentNullException.ThrowIfNull(club);
            ArgumentNullException.ThrowIfNull(book);

            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException(
                    "Event title cannot be empty.", nameof(title));
            }

            if (string.IsNullOrWhiteSpace(location))
            {
                throw new ArgumentException(
                    "Event location cannot be empty.", nameof(location));
            }

            if (maxParticipants <= 0)
            {
                throw new ArgumentException(
                    "Event max participants must be a positive number.",
                    nameof(maxParticipants));
            }

            if (registrationDeadline >= date)
            {
                throw new ArgumentException(
                    "Event registration deadline must be before the event date.",
                    nameof(registrationDeadline));
            }

            Club = club;
            Book = book;
            Title = title;
            Date = date;
            Location = location;
            MaxParticipants = maxParticipants;
            RegistrationDeadline = registrationDeadline;
            Active = active;
        }

        public void Cancel()
        {
            Active = false;
        }
    }
}
