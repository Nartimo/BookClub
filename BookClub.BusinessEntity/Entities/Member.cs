using BookClub.BusinessEntity.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookClub.BusinessEntity.Entities
{
    public class Member : BaseEntity
    {
        public string Name { get; }
        public string Email { get; }
        public Role Role { get; }

        public Member(string id, string name, string email, Role role) : base(id)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Name cannot be null or empty", nameof(name));
            }

            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentException("Email cannot be null or empty", nameof(email));
            }

            if (role != Role.Member && role != Role.ClubLeader)
            {
                throw new ArgumentException("Invalid member role.", nameof(role));
            }

            Name = name;
            Email = email;
            Role = role;
        }
    }
}
