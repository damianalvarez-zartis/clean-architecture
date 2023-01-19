using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoList.Core.Models.Domain;

namespace TodoList.DataAccess.Database.Configurations
{
    public class TodoListModelConfiguration : IEntityTypeConfiguration<TodoListModel>
    {
        public void Configure(EntityTypeBuilder<TodoListModel> builder)
        {
            builder.Property(x => x.Id)
                .IsRequired()
                .HasColumnName("id")
                .HasColumnType("INTEGER");

            builder.Property(x => x.Title)
                .IsRequired()
                .HasColumnName("title")
                .HasColumnType("TEXT");

            builder.Ignore(x => x.Tasks);

            builder.HasMany<TodoTask>("TodoTasks")
                .WithOne(t => t.Parent)
                .IsRequired(false);

            builder.HasKey(x => x.Id);
        }
    }
}
