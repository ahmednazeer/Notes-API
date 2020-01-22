using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotesAPI.Dtos;
using NotesAPI.Models;

namespace NotesAPI.Repository
{
    public interface INotesService
    {
        ICollection<Note> getAllNotes();
        Note addNote(NoteDto model);
        Note editNote(Note Note);
        Note removeNote(int NoteId);
        Note getNoteDetails(int NoteId);
        
    }
}
