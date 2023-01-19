namespace ToDoList.Core.Models.Domain
{
  public class TodoTask
  {
    public int Id { get; internal set; }
    public string Description { get; internal set; }
    public bool IsDone { get; internal set; }

    public TodoListModel Parent { get; internal set; }

    internal TodoTask(string description, bool isDone, TodoListModel parent)
    {
      Description = description;
      IsDone = isDone;
      Parent = parent;
    }
  }
}

