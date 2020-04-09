using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace UniversityExaminationMVC.Models
{
    public class Branch_Work
    {
        public string Name;
        Branch b;
        DataModelContext db;
        Branch_Work()
        {
            b = new Branch();
            db = new DataModelContext();
        }

        public int Add_Branch(string Name)
        {
            b.Name = Name;
            try
            {
                db.Branches.Add(b);
                return 1;
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return -1;
            }
        }

        public int Remove_Branch(int id)
        {
            try
            {
                db.Branches.Remove(db.Branches.Find(id));
                return 1;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return -1;
            }
        }
    }

    public class Branch
    {
        [Key]
        public int Branch_Id { get; set; }
        [Required]
        public string Name { get; set; }

       public virtual ICollection<Student> Students { get; set; }
    }
}