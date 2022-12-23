using ToDoList.Core.Models.Domain;

namespace ToDoList.Core.Models.Requests
{
  public partial class AddTaskToListRequest
  {
    public TodoList? TodoList { get; set; }
    public TodoTaskDto? Task { get; set; }
  }
}
