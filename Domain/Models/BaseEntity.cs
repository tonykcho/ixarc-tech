using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }

        public Guid Guid { get; set; }
    }
}
