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

    public class Exam_Work : Exam_Operation
    {
        Exam e;
        Exam_Factory ef;
        DataModelContext db;
        public Exam_Work(string et,string sem)
        {
            db = new DataModelContext();
            ef = new Exam_Factory();
            e = ef.GetExam(et);
            e.sem = sem;
            e.branch = null;
         }
        public void Addpapers()
        {
            throw new NotImplementedException();
        }

        public void Create_Exam()
        {
            db.Exams.Add(e);
            db.SaveChanges();
        }

        public void Schedule_Exam()
        {
            throw new NotImplementedException();
        }
    }

    public class Exam_Factory
    {
        public Exam GetExam(string type)
        {
            if(type.Equals("Internal"))
            {
                return new Sessional_Exam();
            }
            else if(type.Equals("External"))
            {
                return new External_Exam();
            }
            return null;
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
        ICollection<Paper> papers { get; set; }
    }

    public class Sessional_Exam:Exam
    {
        public Sessional_Exam()
        {
            Name = "Sessional";
            type = "Internal";
        }
    }

    public class External_Exam : Exam
    {
        public External_Exam()
        {
            Name = "External";
            type = "External";
        }
    }
}