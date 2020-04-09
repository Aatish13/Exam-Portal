using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityExaminationMVC.Models
{
    public class CheckModelPaper
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public bool check { get; set; }
    }
}