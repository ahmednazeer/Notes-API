using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NotesAPI.Models
{
    public class Note
    {
        public int ID { get; set; }
        //[Required(ErrorMessage = "Note Date Is Required")]
        public DateTime Date { get; set; }
        [MaxLength(256)]
        public string ImagePath { get; set; }
        //[Required(ErrorMessage = "Note Date Is Required")]
        public string Text { get; set; }
        [MaxLength(256)]
        public string Title { get; set; }
        
    }
}
