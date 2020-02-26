using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CWDExaminationFront.Models;
using System.Net.Http;
using CWDExaminationFront.Helper;
using Newtonsoft.Json;

namespace CWDExaminationFront.Controllers
{
    public class HomeController : Controller
    {
        NoteAPI noteAPI = new NoteAPI();
        public async Task<IActionResult> Index()
        {
            
            
                List<NoteModelData> notes = new List<NoteModelData>();
                HttpClient client = noteAPI.Initial();
                HttpResponseMessage response = await client.GetAsync("api/note");
                if (response.IsSuccessStatusCode)
                {
                    var results = response.Content.ReadAsStringAsync().Result;
                    notes = JsonConvert.DeserializeObject<List<NoteModelData>>(results);
                }
                return View(notes);
            
        }

        public async Task<IActionResult> Details(int Id)
        {


            NoteModelData notes = new NoteModelData();
            HttpClient client = noteAPI.Initial();
            HttpResponseMessage response = await client.GetAsync($"api/note/{Id}");
            if (response.IsSuccessStatusCode)
            {
                var results = response.Content.ReadAsStringAsync().Result;
                notes = JsonConvert.DeserializeObject<NoteModelData>(results);
            }
            return View(notes);

        }

        public async Task<IActionResult> Edit(int Id)
        {


            NoteModelData notes = new NoteModelData();
            HttpClient client = noteAPI.Initial();
            HttpResponseMessage response = await client.GetAsync($"api/note/{Id}");
            if (response.IsSuccessStatusCode)
            {
                var results = response.Content.ReadAsStringAsync().Result;
                notes = JsonConvert.DeserializeObject<NoteModelData>(results);
            }
            return View(notes);

        }


        [HttpPost]
        public IActionResult Edit(NoteModelData note)
        {
            NoteModelData savedNote = new NoteModelData();
            HttpClient client = noteAPI.Initial();
            //using (var httpClient = new HttpClient())
            //{
                //httpClient.BaseAddress = new Uri("http://localhost:64189/api/student");

                //HTTP POST
                var putTask = client.PutAsJsonAsync<NoteModelData>("api/note", note);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            //}
            //return View(savedNote);
            return RedirectToAction("Index");
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(NoteModelData note)
        {
            HttpClient client = noteAPI.Initial();

            var postTask = client.PostAsJsonAsync<NoteModelData>("api/note", note);
            postTask.Wait();

            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }


        public async Task<IActionResult> Delete(int Id)
        {
            var note = new NoteModelData();
            HttpClient client = noteAPI.Initial();
            HttpResponseMessage response = await client.DeleteAsync($"api/note/{Id}");
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Todo()
        {


            List<TodoModelData> todoList = new List<TodoModelData>();
            HttpClient client = noteAPI.Initial();
            HttpResponseMessage response = await client.GetAsync("api/todo");
            if (response.IsSuccessStatusCode)
            {
                var results = response.Content.ReadAsStringAsync().Result;
                todoList = JsonConvert.DeserializeObject<List<TodoModelData>>(results);
            }
            return View("TodoView", todoList);

        }

        public async Task<IActionResult> TodoDetails(int Id)
        {


            TodoModelData todoItem = new TodoModelData();
            HttpClient client = noteAPI.Initial();
            HttpResponseMessage response = await client.GetAsync($"api/todo/{Id}");
            if (response.IsSuccessStatusCode)
            {
                var results = response.Content.ReadAsStringAsync().Result;
                todoItem = JsonConvert.DeserializeObject<TodoModelData>(results);
            }
            return View("TodoDetailsView",todoItem);

        }

        public async Task<IActionResult> TodoEdit(int Id)
        {


            TodoModelData todoItems = new TodoModelData();
            HttpClient client = noteAPI.Initial();
            HttpResponseMessage response = await client.GetAsync($"api/todo/{Id}");
            if (response.IsSuccessStatusCode)
            {
                var results = response.Content.ReadAsStringAsync().Result;
                todoItems = JsonConvert.DeserializeObject<TodoModelData>(results);
            }
            return View("TodoEditView", todoItems);

        }


        [HttpPost]
        public IActionResult TodoEdit(TodoModelData todoItem)
        {
            TodoModelData savedTodoItem = new TodoModelData();
            HttpClient client = noteAPI.Initial();
            

            //HTTP POST
            var putTask = client.PutAsJsonAsync<TodoModelData>("api/todo", todoItem);
            putTask.Wait();

            var result = putTask.Result;
            if (result.IsSuccessStatusCode)
            {

                return RedirectToAction("Todo");
            }
            //}
            //return View(savedNote);
            return RedirectToAction("Todo");
        }

        public IActionResult TodoCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult TodoCreate(TodoModelData todoItem)
        {
            HttpClient client = noteAPI.Initial();

            var postTask = client.PostAsJsonAsync<TodoModelData>("api/todo", todoItem);
            postTask.Wait();

            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Todo");
            }
            return View();
        }

        public async Task<IActionResult> TodoDelete(int Id)
        {
            var note = new NoteModelData();
            HttpClient client = noteAPI.Initial();
            HttpResponseMessage response = await client.DeleteAsync($"api/todo/{Id}");
            return RedirectToAction("Todo");
        }

    }
}
