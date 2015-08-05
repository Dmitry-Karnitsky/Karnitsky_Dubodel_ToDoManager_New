using System.Collections.Generic;
using System.Linq;
using ToDo.Infrastructure;
using WcfService1.SlowToDoManager;

namespace WcfService1
{
    public class ToDoProxyService : IToDoProxyService
    {
        private Dictionary<int, List<IToDoItem>> cache = new Dictionary<int, List<IToDoItem>>(); 


        public void CreateToDoItem(IToDoItem item)
        {
            var client = new ToDoManagerClient();
            var toDoItem = new ToDoItem()
            {
                Name = item.Name,
                IsCompleted = item.IsCompleted,
                ToDoId = item.ToDoId,
                UserId = item.UserId
            };
            
            client.CreateToDoItem(toDoItem);
        }

        public int CreateUser(string name)
        {
            var client = new ToDoManagerClient();
            var id = client.CreateUser(name);
            return id;
        }

        public void DeleteToDoItem(int todoItemId)
        {
            var client = new ToDoManagerClient();
            client.DeleteToDoItem(todoItemId);
        }

        public List<ToDoProxyItem> GetTodoList(int userId)
        {
            var client = new ToDoManagerClient();
            var userList = client.GetTodoList(userId);
            return userList.Select(x => new ToDoProxyItem()
            {
                IsCompleted = x.IsCompleted,
                Name = x.Name,
                ToDoId = x.ToDoId,
                UserId = x.UserId
            }).ToList();
        }

        public void UpdateToDoItem(ToDoProxyItem item)
        {
            var client = new ToDoManagerClient();
            var toDoItem = new ToDoItem()
            {
                Name = item.Name,
                IsCompleted = item.IsCompleted,
                ToDoId = item.ToDoId,
                UserId = item.UserId
            };
            client.UpdateToDoItem(toDoItem);
        }
    }
}
