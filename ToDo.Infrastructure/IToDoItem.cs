using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToDo.Infrastructure
{
    public interface IToDoItem
    {
        bool IsCompleted { get; set; }
        string Name { get; set; }
        int ToDoId { get; set; }
        int UserId { get; set; }
    }
}
