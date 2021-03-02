using Microsoft.EntityFrameworkCore;
using ExamOne.Models;

namespace ExamOne.Contexts
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options) { }
        public DbSet<User> Users {get;set;}
        public DbSet<Gathering> Gatherings {get;set;}
        public DbSet<Participation> Participations {get;set;}
    }
}