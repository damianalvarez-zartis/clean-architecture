namespace ToDoList.Core.Models.Requests
{
  public partial class AddTaskToListRequest
    {
        public class TodoTaskDto
        {
            public string? Description { get; set; }
            public bool IsDone { get; set; }
        }
    }
}
