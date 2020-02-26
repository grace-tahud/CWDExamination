using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CWDExaminationFront.Helper;
using CWDExaminationFront.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CWDExaminationFront.Controllers
{
    public class NoteAPIController : Controller
    {
        NoteAPI noteAPI = new NoteAPI();
        public async Task<IActionResult> Notes()
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
    }
}