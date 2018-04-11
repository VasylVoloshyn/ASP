using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MyQASPTr.Models
{
    public class GuestResponse
    {
        [Required(ErrorMessage ="Please enter your Name")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Please enter you EMail")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage ="Please enter valid Email")]
        public string EMail { get; set; }
        [Required(ErrorMessage = "Please enter your Phone")]
        public string Phone { get; set; }
        [Required(ErrorMessage ="Please specify your answer")]
        public bool? WillAttend { get; set; }
    }
}