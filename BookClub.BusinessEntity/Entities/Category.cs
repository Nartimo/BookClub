using System;
using System.Collections.Generic;
using System.Text;

namespace BookClub.BusinessEntity.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; }
        public bool Active { get; }
        public Category(string id, string name, bool active) : base(id)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Name cannot be null or empty", nameof(name));
            }

            Name = name;
            Active = active;
        }
    }
}
