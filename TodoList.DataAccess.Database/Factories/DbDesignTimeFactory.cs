using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using TodoList.DataAccess.Database.DbContexts;

namespace TodoList.DataAccess.Database.Factories
{
    public  class DbDesignTimeFactory : IDesignTimeDbContextFactory<TodoListDbContext>
    {
        public TodoListDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TodoListDbContext>();
            optionsBuilder.UseSqlite("Data Source=C:\\repos\\training\\clean-architecture\\TodoList.DataAccess.Database\\LocalDatabase.db");

            return new TodoListDbContext(optionsBuilder.Options);
        }
    }
}
