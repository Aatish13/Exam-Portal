using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityExaminationMVC.Models
{
    public interface Exam_Operation
    {
        int Create_Exam();
        void Schedule_Exam();
        void Addpapers();
    }

    public class Exam_Work : Exam_Operation
    {
        Exam e;
        Exam_Factory ef;
        DataModelContext db;
        public Exam_Work(string et,string sem,int brch,DateTime date)
        {
            db = new DataModelContext();
            ef = new Exam_Factory();
            e = ef.GetExam(et);
            e.sem = sem;
            e.BranchId = brch;
            e.date = date;
        }
        public void Addpapers()
        {
            throw new NotImplementedException();
        }

        public int Create_Exam()
        {
            db.Exams.Add(e);
            db.SaveChanges();
            return db.Exams.SingleOrDefault(x => x.date == e.date).Exam_Id;
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
        [Required]
        public DateTime date { get; set; }

        [ForeignKey("Branch")]
        public int BranchId { get; set; }

        public virtual Branch Branch { get; set; }

        public virtual ICollection<Paper> papers { get; set; }
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