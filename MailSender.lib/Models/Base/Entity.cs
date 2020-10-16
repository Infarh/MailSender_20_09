using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace MailSender.lib.Models.Base
{
    public abstract class Entity
    {
        public int Id { get; set; }
    }

    public abstract class NamedEntity : Entity
    {
        [Required]
        public virtual string Name { get; set; }
    }

    public abstract class Person : NamedEntity
    {
        public virtual string Address { get; set; }
    }
}
