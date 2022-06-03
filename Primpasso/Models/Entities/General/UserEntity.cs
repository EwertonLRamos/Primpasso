using System.ComponentModel.DataAnnotations;

namespace Primpasso.Models.Entities.General
{
    public abstract class UserEntity : Entity
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
