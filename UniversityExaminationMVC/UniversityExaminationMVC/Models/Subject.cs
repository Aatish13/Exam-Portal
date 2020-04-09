using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityExaminationMVC.Models
{
    public class Subject_Work
    {
        public string Name;
        public int Sem;
        Subject s;
        DataModelContext db;

        Subject_Work()
        {
            s = new Subject();
            db = new DataModelContext();
        }

        public int Add_Subject(string name,int sem)
        {
            s.Name = name;
            s.Sem = sem;
            try
            {
                db.Subjects.Add(s);
                return 1;
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return -1;
            }
        }
        public int Remove_Subject(int id)
        {
            try
            {
                db.Subjects.Remove(db.Subjects.Find(id));
                return 1;
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return -1;
            }

        }
    }

    public class Subject
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
         
        public int Sem { get; set; }


    }
}