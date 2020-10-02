namespace MailSender.lib.Models.Base
{
    public abstract class Entity
    {
        public int Id { get; set; }
    }

    public abstract class NamedEntity : Entity
    {
        public virtual string Name { get; set; }
    }

    public abstract class Person : NamedEntity
    {
        public virtual string Address { get; set; }
    }
}
