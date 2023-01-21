using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace WebTestITDevelopment.Models
{
    public class ProjectOfTaskViewModel
    {
        public List<TaskNote> TaskList { get; set; }
        public SelectList Project { get; set; }
        public string ProjectOfTask { get; set; }
        public string SearchString { get; set; }
    }
}
