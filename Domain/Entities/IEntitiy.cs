using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public interface IEntity<TPrimaryKey>
    {
        //
        // Summary:
        //     Unique identifier for this entity.
        TPrimaryKey Id { get; set; }

        //
        // Summary:
        //     Checks if this entity is transient (not persisted to database and it has not
        //     an Abp.Domain.Entities.IEntity`1.Id).
        //
        // Returns:
        //     True, if this entity is transient
        bool IsTransient();
    }

    public class Entity<TPrimaryKey> : IEntity<TPrimaryKey>
    {
        public TPrimaryKey Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool IsTransient()
        {
            throw new NotImplementedException();
        }
    }
}
