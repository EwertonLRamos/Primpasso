using System;
using System.ComponentModel.DataAnnotations;

namespace Primpasso.Models.Entities.General
{
    public abstract class Entity
    {
        [Key]
        public int Id { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
