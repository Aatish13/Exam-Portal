using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityExaminationMVC.Models
{
    public class Faculty
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Branch { get; set; }
        [Required]
        public string EducationalQualifications { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string DOB { get; set; }
    }
}