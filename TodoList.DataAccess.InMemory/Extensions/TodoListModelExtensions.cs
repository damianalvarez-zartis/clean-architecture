using System.Reflection;
using ToDoList.Core.Models.Domain;

namespace TodoList.DataAccess.InMemory.Extensions
{
    public static class TodoListModelExtensions
    {
        private static readonly MethodInfo _idSetter = typeof(TodoListModel)
            .GetProperty(nameof(TodoListModel.Id))
            .GetSetMethod(nonPublic: true);

        public static void SetId(this TodoListModel list, int newId)
        {
            _idSetter.Invoke(list, new object[] { newId });
        }
    }
}
