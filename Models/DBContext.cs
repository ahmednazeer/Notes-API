using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesAPI.Models
{
    public class DBContext:DbContext
    {
        public DBContext(DbContextOptions options):base(options)
        {
            
        }

        public DbSet<Note> Notes { get; set; }
    }
}
