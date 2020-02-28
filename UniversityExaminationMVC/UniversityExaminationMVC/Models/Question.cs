using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UniversityExaminationMVC.Models
{
    public class Question
    {
            [Key]
            public int QuestionId { get; set; }
            [Required]
            public string Description { get; set; }
            [Required]
            public int Marks { get; set; }

            public string Hint { get; set; }

           
            [Required]
            public bool isPublic { get; set; }

            [ForeignKey("Faculty")]
            public int FacultyProfileId { get; set; }
            
            public Faculty Faculty { get; set; }

            public virtual ICollection<Options> Optionss { get; set; }

            public virtual ICollection<PaperQuestion> PaperQuestions { get; set; }
        
    }
}