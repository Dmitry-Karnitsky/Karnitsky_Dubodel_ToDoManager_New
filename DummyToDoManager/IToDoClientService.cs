using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using ToDo.Infrastructure;
using DummyToDoManager.ToDoClientManager;

namespace DummyToDoManager
{
    [ServiceContract]
    public interface IToDoClientService
    {
        [OperationContract]
        void CreateToDoItem(IToDoItem todo);

        [OperationContract]
        int CreateUser(string name);

        [OperationContract]
        void DeleteToDoItem(int todoItemId);

        [OperationContract]
        List<ToDoClientItem> GetTodoList(int userId);

        [OperationContract]
        void UpdateToDoItem(ToDoClientItem todo);

    }

    [DataContract]
    public class ToDoClientItem : IToDoItem
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
