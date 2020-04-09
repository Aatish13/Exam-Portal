using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UniversityExaminationMVC.Models
{
    public class PaperQuestion
    {
        [Key, Column(Order = 1)]
        public int PaperId { get; set; }
        [Key, Column(Order = 2)]
        public int QuestionId { get; set; }

    }
}