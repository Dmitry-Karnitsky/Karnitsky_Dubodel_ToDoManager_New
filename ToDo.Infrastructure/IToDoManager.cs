using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToDo.Infrastructure
{
    public interface IToDoManager
    {
        void CreateToDoItem(IToDoItem todo);
        int CreateUser(string name);
        void DeleteToDoItem(int todoItemId);
        List<IToDoItem> GetTodoList(int userId);
        void UpdateToDoItem(IToDoItem todo);
    }
}