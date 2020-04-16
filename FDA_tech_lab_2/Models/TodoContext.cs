using Microsoft.EntityFrameworkCore;

namespace FDA_tech_lab_2.Models
{
    public class TodoContext : DbContext
    {

        public DbSet<Plant> Plants { get; set; }
        public DbSet<Owner> Owners { get; set; }

        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
        }

        //public DbSet<TodoItem> TodoItems { get; set; }
    }
}