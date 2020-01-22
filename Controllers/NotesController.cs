using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using NotesAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using NotesAPI.Dtos;
using NotesAPI.Models;

namespace NotesAPI.Controllers
{
    [Route("api/[controller]")]
    
    //[EnableCors("AllowMyOrigin")]
    [ApiController]
    
    public class NotesController : ControllerBase
    {
        private INotesService service;

        public NotesController(INotesService service)
        {
            this.service = service;
        }
        [HttpPost("Add")]
        public IActionResult SaveNote(NoteDto model)
        {
            var result = service.addNote(model);
            return result!=null?(IActionResult) Created("new note ",result):BadRequest("Failed To Save Note");
        }
        [HttpGet("List")]
        public IActionResult ListNotes()
        {
            var notesList = service.getAllNotes().OrderBy(note => note.Date);
            return Ok(notesList);
        }
        [HttpDelete("remove/{noteId}")]
        public IActionResult DeleteNote(int noteId)
        {
            Note deletedNote = service.removeNote(noteId);
            if (deletedNote == null)
            {
                return BadRequest("Failed To Delete Note");
            }
            else
            {
                return Ok(deletedNote);
            }
            //return null;
        }
        [HttpGet("details/{noteId}")]
        public IActionResult GetNoteDetails(int noteId)
        {
            var resultNote = service.getNoteDetails(noteId);
            if (resultNote == null)
            {
                return BadRequest("Something Wrong In Request");
            }
            else
            {
                return Ok(resultNote);
            }

            
        }
        [HttpPut("update")]
        public IActionResult UpdateNote(Note model)
        {
            if (service.editNote(model) != null)
            {
                return NoContent();
            }
            else
            {
                return BadRequest("Failed To Update Note");
            }
            
        }
        
    }
}