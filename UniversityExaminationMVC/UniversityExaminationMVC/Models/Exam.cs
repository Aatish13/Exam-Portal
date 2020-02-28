using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace UniversityExaminationMVC.Models
{
    public interface Exam_Operation
    {
        void Create_Exam();
        void Schedule_Exam();
        void Addpapers();
    }

    public class Opertaion_On_Exam : Exam_Operation
    {
        Exam e;
        Opertaion_On_Exam(string et)
        {
            e=
        }
        public void Addpapers()
        {
            throw new NotImplementedException();
        }

        public void Create_Exam()
        {
            throw new NotImplementedException();
        }

        public void Schedule_Exam()
        {
            throw new NotImplementedException();
        }
    }

    public class Exam_Factory
    {
        public void GetExam(string name)
        {
            if(name.Equals(""))
            {

            }
        }
    }

    public class Exam
    {
        [Key]
        public int Exam_Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string type { get; set; }
        [Required]
        public string sem { get; set; }
        public Branch branch { get; set; }
    }

    public class Sessional_Exam:Exam
    {
        Sessional_Exam()
        {
            Name = "Sessional";
            type = "Internal";
        }
    }

    public class External_Exam : Exam
    {
        External_Exam()
        {
            Name = "Extnal";
            type = "External";
        }
    }
}