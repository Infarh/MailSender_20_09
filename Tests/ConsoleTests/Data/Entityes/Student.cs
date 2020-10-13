using System;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ConsoleTests.Data.Entityes
{
    public class Student : NamedEntity
    {
        //[Key] 
        //public int PrimaryKey { get; set; }

        [Required, MaxLength(120)]
        public string Surname { get; set; }

        [MaxLength(120)]
        public string Patronymic { get; set; }

        public virtual Group Group { get; set; } // навигационные свойства
    }
}
