using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace UniversityExaminationMVC.Models
{
    public class Branch
    {
        [Key]
        public int Branch_Id { get; set; }
        [Required]
        public string Name { get; set; }

    }
}