using CWDExamination.Models;
using CWDExamination.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CWDExamination.Repository.Implementation
{
    public class TodoRepository:ITodoRepository<TodoItem>
    {
        readonly ApplicationDbContext db;

        public TodoRepository(ApplicationDbContext context)
        {
            db = context;
        }

        public IEnumerable<TodoItem> GetAllTodoItems()
        {
            return db.TodoItems.ToList();
        }

        public TodoItem PostTodoItems(TodoItem todoItem)
        {
            try
            {
                if (db != null)
                {
                    db.Add(todoItem);
                    db.SaveChanges();
                    return todoItem;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                //log exception  
                return null;
            }
        }

        public TodoItem GetTodoItems(int Id)
        {
            try
            {
                return db.TodoItems.Where(e => e.Id == Id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                //log exception  
                return null;
            }
        }

        public TodoItem UpdateTodoItems(TodoItem todoItem)
        {
            try
            {
                if (db != null)
                {
                    db.Update(todoItem);
                    db.SaveChanges();
                    return todoItem;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                //log exception  
                return null;
            }
        }

        public int DeleteTodoItems(int Id)
        {
            try
            {
                if (db != null)
                {
                    var todoItem = db.TodoItems.FirstOrDefault(x => x.Id == Id);
                    if (todoItem != null)
                    {
                        db.Remove(todoItem);
                        db.SaveChanges();
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    return 0;
                }


            }
            catch (Exception ex)
            {
                //log exception  
                return 0;
            }
        }
    }
}
