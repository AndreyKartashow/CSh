using Microsoft.EntityFrameworkCore;
using MvcNote.Models;

namespace MvcNote.Data
{

    public class MvcNoteContext : DbContext
        {
            public MvcNoteContext(DbContextOptions<MvcNoteContext> options)
                : base(options)
            {
            }

            public DbSet<Note> Note { get; set; }
        }
    }

