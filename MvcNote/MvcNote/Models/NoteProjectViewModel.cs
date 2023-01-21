using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
namespace MvcNote.Models
{
    public class NoteProjectViewModel
    {
        public List<Note> ListNote { get; set; }
        public SelectList Projects { get; set; }
        public string ProjectOfNote { get; set; }
        public string SearchString { get; set; }
    }
}
