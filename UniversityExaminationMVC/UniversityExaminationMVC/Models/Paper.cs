using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UniversityExaminationMVC.Models
{
    public class Paper
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime paperDate{get;set;}
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public bool isPublic { get; set; }

        [Required]
        public Subject Subject { get; set; }

        [ForeignKey("Faculty")]
        public int FacultyProfileId { get; set; }

        public Faculty Faculty { get; set; }

        public virtual ICollection<PaperQuestion> PaperQuestions { get; set; }

        public Exam exam { get; set; }
    }
}