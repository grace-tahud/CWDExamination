using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CWDExamination.Models;
using CWDExamination.Repository.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CWDExamination.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoRepository<TodoItem> _todoRepository;

        public TodoController(ITodoRepository<TodoItem> todoRepository)
        {
            _todoRepository = todoRepository;
        }

        // GET: api/Note/NoteList  
        [HttpGet]
        //[Route("TodoItemList")]
        public IActionResult GetAllTodoItems()
        {
            IEnumerable<TodoItem> todoItem = _todoRepository.GetAllTodoItems();
            return Ok(todoItem);
        }

        [HttpPost]
        //[Route("AddTodoItem")]
        public IActionResult AddTodoItem([FromBody]TodoItem saveTodoItem)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TodoItem todoItem = _todoRepository.PostTodoItems(saveTodoItem);
                    return Ok(todoItem);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch
            {
                //log Exception  
                return BadRequest();
            }
        }

        [HttpGet("{Id}")]
        //[Route("GetTodoItem")]
        public IActionResult GetTodoItem(int Id)
        {
            try
            {
                TodoItem todoItem = _todoRepository.GetTodoItems(Id);
                return Ok(todoItem);
            }
            catch (Exception ex)
            {
                //log exception   
                return BadRequest();
            }
        }

        [HttpPut]
        //[Route("UpdateTodoItem")]
        public IActionResult UpdateTodoItem([FromBody]TodoItem savedTodoItem)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TodoItem todoItem = _todoRepository.UpdateTodoItems(savedTodoItem);
                    return Ok(todoItem);
                }
                else
                {

                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                //log Exception  
                return BadRequest();
            }
        }

        [HttpDelete("{Id}")]
        //[Route("DeleteTodoItem")]
        public IActionResult DeleteTodoItem(int Id)
        {
            try
            {
                int result = _todoRepository.DeleteTodoItems(Id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                //log Exception  
                return BadRequest();
            }
        }
    }
}