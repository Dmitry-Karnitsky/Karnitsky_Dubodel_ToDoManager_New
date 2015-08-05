using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Infrastructure;
using DummyToDoManager.ToDoClientManager;
using System.ServiceModel;

namespace DummyToDoManager
{
    public class ToDoManager : IToDoManager
    {
        ToDoProxyServiceClient client = null;

        public ToDoManager()
        {
            var binding = new BasicHttpBinding(BasicHttpSecurityMode.None);
            //var security = new WSHttpSecurity();
            //security.Mode = SecurityMode.None;
            //security.Transport = new HttpTransportSecurity() { ClientCredentialType = HttpClientCredentialType.None };
            //binding.Security = security;

            binding.SendTimeout = new TimeSpan(0, 0, 0, 0, 100000);
            binding.OpenTimeout = new TimeSpan(0, 0, 0, 0, 100000);
            binding.MaxReceivedMessageSize = 10000;
            binding.ReaderQuotas.MaxStringContentLength = 10000;
            binding.ReaderQuotas.MaxDepth = 10000;
            binding.ReaderQuotas.MaxArrayLength = 10000;
            EndpointIdentity epid = EndpointIdentity.CreateSpnIdentity("host/WIN5029.smarterasp.net");
            Uri uri = new Uri("http://dubodel-001-site1.mywindowshosting.com/ToDoProxyService.svc");
            var endpoint = new EndpointAddress(uri, epid);
            client = new ToDoProxyServiceClient(binding, endpoint);
        }


        public void CreateToDoItem(IToDoItem item)
        {
            //var client = new ToDoProxyServiceClient();
            var toDoItem = new ToDoProxyItem()
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
            //var client = new ToDoProxyServiceClient();
            var id = client.CreateUser(name);
            return id;
        }

        public void DeleteToDoItem(int todoItemId)
        {
            //var client = new ToDoProxyServiceClient();
            client.DeleteToDoItem(todoItemId);
        }

        public List<IToDoItem> GetTodoList(int userId)
        {
            //var client = new ToDoProxyServiceClient();
            var userList = client.GetTodoList(userId);

            var result = new List<IToDoItem>();

            foreach (var tempItem in userList)
            {
                ToDoItem item = new ToDoItem()
                {
                    IsCompleted = tempItem.IsCompleted,
                    Name = tempItem.Name,
                    ToDoId = tempItem.ToDoId,
                    UserId = tempItem.UserId
                };
                result.Add(item);
            }

            return result;
        }

        public void UpdateToDoItem(IToDoItem item)
        {
            //var client = new ToDoProxyServiceClient();
            var toDoItem = new ToDoProxyItem()
            {
                Name = item.Name,
                IsCompleted = item.IsCompleted,
                ToDoId = item.ToDoId,
                UserId = item.UserId
            };
            client.UpdateToDoItem(toDoItem);
        }
    }


    public class ToDoItem : IToDoItem
    {
        public bool IsCompleted { get; set; }

        public string Name { get; set; }

        public int ToDoId { get; set; }

        public int UserId { get; set; }
    }
}
