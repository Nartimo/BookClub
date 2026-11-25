using System;
using System.Collections.Generic;
using System.Text;

namespace BookClub.BusinessEntity.Entities
{
    public abstract class BaseEntity
    {
        public string Id { get; }
        protected BaseEntity(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentException("Id cannot be null or empty", nameof(id));
            }

            Id = id;
        }
    }
}
