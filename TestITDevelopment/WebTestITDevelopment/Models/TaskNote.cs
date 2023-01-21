using System;
using System.ComponentModel.DataAnnotations;

namespace WebTestITDevelopment.Models
{
    public class TaskNote
    {
        public int Id { get; set; }


        [Display(Name = "Name Project"), RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$"), StringLength(40, MinimumLength = 3), Required]
        public string NameProject { get; set; }


        [Display(Name = "Lead Times"), DataType(DataType.Time)]
        public DateTime Times { get; set; }
        

        [Display(Name = "Start Times")]
        public DateTime StartTimes { get; set; }


        [Display(Name = "End Times")]
        public DateTime EndTimes { get; set; }


        [Display(Name = "Name Task"), RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$"), StringLength(40, MinimumLength = 3), Required]
        public string NameTask { get; set; }

    
        [StringLength(200, MinimumLength = 3), Required]
        public string Comment { get; set; }


        [Display(Name = "Data Create"), DataType(DataType.Date)]
        public DateTime DataCreate { get; set; }



    }
}
