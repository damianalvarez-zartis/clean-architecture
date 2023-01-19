using System.Reflection;
using ToDoList.Core.Models.Domain;

namespace TodoList.DataAccess.InMemory.Extensions
{
    public static class TodoTaskExtensions
    {
        private static readonly MethodInfo _idSetter = typeof(TodoTask)
            .GetProperty(nameof(TodoTask.Id))
            .GetSetMethod(nonPublic: true);

        public static void SetId(this TodoTask list, int newId)
        {
            _idSetter.Invoke(list, new object[] { newId });
        }
    }
}
