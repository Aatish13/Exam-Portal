using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityExaminationMVC.Models
{
    public class Options
    {
        

            [Key]
            public int OptionsId { get; set; }
            [Required]
            public string ans { get; set; }
            
            [Required]
            public bool isAnswer { get; set; }
        
    }
}