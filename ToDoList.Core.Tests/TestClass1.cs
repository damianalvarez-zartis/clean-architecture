using Xunit;
using ToDoList.Core.Services;

namespace ToDoList.Core.Tests
{
    public class TestClass1
    {
        private readonly TodoListService _service;
        public TestClass1(TodoListService service)
        {
            _service = service;
        }
        [Fact]
        public async void Test1()
        {
            var request = new Models.Requests.CreateListRequest
            {
                Title = "test"
            };
            var list = await _service.CreateListAsync(request, new System.Threading.CancellationToken());
            var title = list.Value.Title;
            Assert.Equal("test", title);
        }
    }
}
