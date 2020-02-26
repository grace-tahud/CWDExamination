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
    public class NoteController : ControllerBase
    {
        private readonly INoteRepository<Note> _noteRepository;

        public NoteController(INoteRepository<Note> noteRepository)
        {
            _noteRepository = noteRepository;
        }

        // GET: api/Note/NoteList  
        [HttpGet]
        
        public IActionResult GetAllNote()
        {
            IEnumerable<Note> note = _noteRepository.GetAllNote();
            return Ok(note);
        }

        [HttpPost]
        //[Route("AddNote")]
        public IActionResult AddNote([FromBody]Note saveNote)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Note note = _noteRepository.PostNote(saveNote);
                    return Ok(note);
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
        //[Route("GetNote")]
        public IActionResult GetNote(int Id)
        {
            try
            {
                Note note = _noteRepository.GetNote(Id);
                return Ok(note);
            }
            catch (Exception ex)
            {
                //log exception   
                return BadRequest();
            }
        }

        [HttpPut]
        //[Route("UpdateNote")]
        public IActionResult UpdateNote([FromBody]Note savedNote)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Note note = _noteRepository.UpdateNote(savedNote);
                    return Ok(note);
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
        //[Route("DeleteNote")]
        public IActionResult DeleteNote(int Id)
        {
            try
            {
                int result = _noteRepository.DeleteNote(Id);
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