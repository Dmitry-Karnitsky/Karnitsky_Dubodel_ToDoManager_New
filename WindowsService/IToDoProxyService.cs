using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using ToDo.Infrastructure;
using WindowsService.SlowToDoManager;

namespace WindowsService
{
    [ServiceContract]
    public interface IToDoProxyService
    {
        [OperationContract]
        void CreateToDoItem(IToDoItem todo);

        [OperationContract]
        int CreateUser(string name);

        [OperationContract]
        void DeleteToDoItem(int todoItemId);

        [OperationContract]
        List<ToDoProxyItem> GetTodoList(int userId);

        [OperationContract]
        void UpdateToDoItem(ToDoProxyItem todo);

    }

    [DataContract]
    public class ToDoProxyItem : IToDoItem
    {
        [DataMember]
        public bool IsCompleted { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int ToDoId { get; set; }

        [DataMember]
        public int UserId { get; set; }
    }
}
