using ConsoleTests.Data.Entityes;
using Microsoft.EntityFrameworkCore;

namespace ConsoleTests.Data
{
    public class StudentsDB : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public DbSet<Group> Groups { get; set; }

        public StudentsDB(DbContextOptions<StudentsDB> options) : base(options) { }
    }
}
