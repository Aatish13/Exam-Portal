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
            [Required]
            public string Answer { get; set; }

            public string Hint { get; set; }

            [ForeignKey("Subject")]
            public int Subject_Id { get; set; }
            public virtual Subject Subject { get; set; }

        [ForeignKey("Faculty")]
        public int Faculty_Id { get; set; }
        public virtual Faculty Faculty { get; set; }
           
          //  public virtual ICollection<PaperQuestion> PaperQuestions { get; set; }
        
    }
}