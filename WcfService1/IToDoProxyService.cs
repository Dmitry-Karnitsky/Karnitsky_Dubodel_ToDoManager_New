using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ToDo.Infrastructure;

namespace WcfService1
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
