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

        public int Duration { get; set; }

        [ForeignKey("Subject")]
        public int Subject_Id { get; set; }
        public virtual Subject Subject { get; set; }

        [ForeignKey("Faculty")]
        public int Faculty_Id { get; set; }

        public virtual Faculty Faculty { get; set; }

      //  public virtual ICollection<PaperQuestion> PaperQuestions { get; set; }
       // [ForeignKey("Exam")]
        //public int Exam_Id { get; set; }

        public virtual Exam exam { get; set; }
    }
}