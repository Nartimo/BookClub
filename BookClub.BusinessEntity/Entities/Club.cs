using System;
using System.Collections.Generic;
using System.Text;
using BookClub.BusinessEntity.Enums;

namespace BookClub.BusinessEntity.Entities
{
    public class Club : BaseEntity
    {
        private readonly HashSet<Member> members = new();

        public string Name { get; }
        public string Description { get; }
        public Category Category { get; }
        public Member Leader { get; }
        public IReadOnlyCollection<Member> Members => members.ToList();
        public bool Active { get; private set; }

        public Club(
            string id,
            string name,
            string description,
            Category category,
            Member leader,
            bool active = true,
            IEnumerable<Member>? initialMembers = null)
            : base(id)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(
                    "Club name cannot be empty.", nameof(name));
            }

            if (string.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentException(
                    "Club description cannot be empty.",
                    nameof(description));
            }

            ArgumentNullException.ThrowIfNull(category);
            ArgumentNullException.ThrowIfNull(leader);

            if (leader.Role != Role.ClubLeader)
            {
                throw new ArgumentException(
                    "The club leader must have the ClubLeader role.",
                    nameof(leader));
            }

            Name = name;
            Description = description;
            Category = category;
            Leader = leader;
            Active = active;

            if (initialMembers is null)
            {
                // If no initial members are provided, we still add the leader as a member of the club.
                this.members.Add(leader);
            }
            else
            {
                foreach (var member in initialMembers)
                {
                    ArgumentNullException.ThrowIfNull(member);

                    if (!this.members.Add(member))
                    {
                        throw new InvalidOperationException(
                            "Duplicate member found in initial members.");
                    }
                }

                if (!this.members.Contains(leader))
                {
                    // Leader is always considered as a member of the club, even if not explicitly added to the initial members.
                    this.members.Add(leader);
                }
            }
        }

        public bool IsMember(Member member)
        {
            return members.Contains(member);
        }

        public void AddMember(Member member)
        {
            ArgumentNullException.ThrowIfNull(member);

            if (!Active)
            {
                throw new InvalidOperationException(
                    "Cannot join an inactive club.");
            }

            if (!members.Add(member))
            {
                throw new InvalidOperationException(
                    "The user is already a member of this club.");
            }
        }

        public void Deactivate()
        {
            Active = false;
        }
    }
}