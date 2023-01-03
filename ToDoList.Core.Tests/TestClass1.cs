using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ToDoList.Core.Models.Domain;
using ToDoList.Core.Services;

namespace ToDoList.Core.Tests
{
    [TestClass]
    public class TestClass1
    {
        private readonly TodoListService _service;
        public TestClass1(TodoListService service)
        {
            _service = service;
        }
        [TestMethod]
        public async void Test1()
        {
            var request = new Models.Requests.CreateListRequest
            {
                Title = "test"
            };
            var list = await _service.CreateListAsync(request, new System.Threading.CancellationToken());
            var title = list.Value.Title;
            Assert.AreEqual(title, "test");
        }
    }
}
