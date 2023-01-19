using System.Collections.Generic;

namespace ToDoList.Core.Models.Domain
{
  public class TodoListModel
  {
    internal List<TodoTask> TodoTasks { get; }

    public int Id { get; internal set; }
    public string Title { get; internal set; }
    public IReadOnlyList<TodoTask> Tasks => TodoTasks.AsReadOnly();

    public TodoListModel(string title)
    {
      TodoTasks = new List<TodoTask>();

      Title = title;
    }
  }
}
