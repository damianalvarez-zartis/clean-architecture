using System.Collections.Generic;

namespace ToDoList.Core.Models.Domain
{
  public class TodoList
  {
    internal List<TodoTask> TodoTasks { get; }

    public int Id { get; internal set; }
    public string Title { get; internal set; }
    public IReadOnlyList<TodoTask> Tasks => TodoTasks;

    public TodoList(string title)
    {
      TodoTasks = new List<TodoTask>();

      Title = title;
    }
  }
}
