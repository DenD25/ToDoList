using Microsoft.EntityFrameworkCore;

namespace ToDoList.Models
{
    public class ApplicationContext: DbContext
    {
        public DbSet<TaskModel> Tasks { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
