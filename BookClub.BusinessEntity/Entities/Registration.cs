using System;
using System.Collections.Generic;
using System.Text;
using BookClub.BusinessEntity.Enums;

namespace BookClub.BusinessEntity.Entities
{
    public class Registration : BaseEntity
    {
        public Event Event { get; }
        public Member Member { get; }
        public DateTime RegisteredAt { get; }
        public RegistrationStatus Status { get; private set; }

        public Registration(
            string id,
            Event clubEvent,
            Member member,
            DateTime registeredAt,
            RegistrationStatus status)
            : base(id)
        {
            ArgumentNullException.ThrowIfNull(clubEvent);
            ArgumentNullException.ThrowIfNull(member);

            if (!Enum.IsDefined(status))
            {
                throw new ArgumentException(
                    "Invalid registration status.",
                    nameof(status));
            }

            if (registeredAt > clubEvent.RegistrationDeadline)
            {
                throw new ArgumentException(
                    "Registration date cannot exceed the event deadline.",
                    nameof(registeredAt));
            }

            Event = clubEvent;
            Member = member;
            RegisteredAt = registeredAt;
            Status = status;
        }

        public void Promote()
        {
            if (Status != RegistrationStatus.Waitlisted)
            {
                throw new InvalidOperationException(
                    "Only waitlisted registrations can be promoted.");
            }

            Status = RegistrationStatus.Confirmed;
        }

        public void Cancel()
        {
            if (Status == RegistrationStatus.Cancelled)
            {
                throw new InvalidOperationException(
                    "Registration is already cancelled.");
            }
            Status = RegistrationStatus.Cancelled;
        }
    }
}
