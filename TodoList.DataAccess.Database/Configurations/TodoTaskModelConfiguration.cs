using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoList.Core.Models.Domain;

namespace TodoList.DataAccess.Database.Configurations
{
    public class TodoTaskModelConfiguration : IEntityTypeConfiguration<TodoTask>
    {
        public void Configure(EntityTypeBuilder<TodoTask> builder)
        {
            builder.Property(x => x.Id)
                .IsRequired()
                .HasColumnName("id")
                .HasColumnType("INTEGER");

            builder.Property(x => x.Description)
                .IsRequired()
                .HasColumnName("description")
                .HasColumnType("TEXT");

            builder.Property(x => x.IsDone)
                .IsRequired()
                .HasColumnName("is_done")
                .HasColumnType("INTEGER")
                .HasConversion(
                    to => to ? 1 : 0,
                    from => from == 1);

            builder.Property<int>("list_id")
                .HasColumnType("INTEGER")
                .HasColumnName("list_id");

            builder.HasOne(x => x.Parent)
                .WithMany("TodoTasks")
                .HasForeignKey("list_id");
        }
    }
}
