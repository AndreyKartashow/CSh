using System.ComponentModel.DataAnnotations;
using System;

namespace MvcNote.Models
{
    public class Note
    {
        public int Id { get; set; }


        [Display(Name = "Project Name"), RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$"), StringLength(40, MinimumLength = 3), Required]
        public string NameProject { get; set; }


        [Display(Name = "Times Lead, minutes")]
        public string Times { get; set; }


        [Display(Name = "Start Times")]
        public DateTime StartTimes { get; set; }


        [Display(Name = "End Times")]
        public DateTime EndTimes { get; set; }


        [Display(Name = "Name Task"), RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$"), StringLength(40, MinimumLength = 3), Required]
        public string NameTask { get; set; }


        [DataType(DataType.MultilineText), StringLength(200, MinimumLength = 3), Required]
        public string Comment { get; set; }


        [Display(Name = "Data Create"), DataType(DataType.Date)]
        public DateTime DataCreate { get; set; }
    }
}
