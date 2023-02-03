using Microsoft.EntityFrameworkCore;
using TodoList.DataAccess.Database.Configurations;
using ToDoList.Core.Models.Domain;

namespace TodoList.DataAccess.Database.DbContexts
{
    public class TodoListDbContext : DbContext
    {
        public TodoListDbContext(DbContextOptions<TodoListDbContext> options) : base(options)
        {
        }

        public virtual DbSet<TodoListModel> TodoLists { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TodoListModelConfiguration());
            modelBuilder.ApplyConfiguration(new TodoTaskModelConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
