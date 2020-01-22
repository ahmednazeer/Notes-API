using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotesAPI.Dtos;
using NotesAPI.Models;
using NotesAPI.Repository;
using Microsoft.EntityFrameworkCore;

namespace NotesAPI.Repository
{
    public class NotesService:INotesService
    {
        private readonly DBContext context;

        public NotesService(DBContext context)
        {
            this.context = context; 
        }
        public Note addNote(NoteDto model)
        {
            if (model != null)
            {
                Note Note = new Note
                {
                    Title = model.Title,
                    Text = model.Text,
                    ImagePath = model.ImagePath,
                    Date = DateTime.Parse(model.Date.ToString())//model.Date,
                    
                };
                var result = context.Notes.Add(Note);
                context.SaveChanges();
                return result != null ? Note : null;


            }
            else return null;
            //throw new NotImplementedException();
        }

        public Note editNote(Note Note)
        {
            var NoteResult = context.Notes.SingleOrDefault(n => n.ID == Note.ID);
            if (NoteResult == null) return null;
            NoteResult.Date = Note.Date;
            NoteResult.Title = Note.Title;
            NoteResult.Text = Note.Text;
            NoteResult.ImagePath = Note.ImagePath;
            
            
            context.SaveChanges();
            return NoteResult;
        }

        public ICollection<Note> getAllNotes()
        {
            var NoteList = context.Notes.ToList();
            return NoteList;

        }

        public Note removeNote(int NoteId)
        {
            var NoteResult = context.Notes.SingleOrDefault(Note => Note.ID == NoteId);
            if (NoteResult != null)
            {
                var result = context.Notes.Remove(NoteResult);
                context.SaveChanges();
                return result!=null?NoteResult:null;
            }
            else return null;
        }
        public Note getNoteDetails(int NoteId)
        {
            var NoteResult = context.Notes.SingleOrDefault(Note => Note.ID == NoteId);
            return NoteResult != null ? NoteResult : null;
        }

        

        
    }
}
