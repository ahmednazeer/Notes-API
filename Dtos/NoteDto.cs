using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesAPI.Dtos
{
    public class NoteDto
    {
        public DateTime Date { get; set; }
        public string ImagePath { get; set; }
        public string Text { get; set; }
        public string Title { get; set; }
        
    }
}
