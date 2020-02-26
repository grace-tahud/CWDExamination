using CWDExamination.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CWDExamination.Repository.Contract
{
    public interface ITodoRepository<T>
    {
        IEnumerable<T> GetAllTodoItems();
        TodoItem PostTodoItems(TodoItem saveTodoItem);
        TodoItem GetTodoItems(int id);
        TodoItem UpdateTodoItems(TodoItem savedTodoItem);
        int DeleteTodoItems(int id);
    }
}
