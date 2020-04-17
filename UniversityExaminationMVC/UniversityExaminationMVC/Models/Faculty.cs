using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UniversityExaminationMVC.Models
{
    public class Faculty_Work
    {
        public string Name;
        public string Branch;
        public string EducationalQualifications;
        public string Email;
        public string DOB;
        public Faculty f;
        public static DataModelContext db=new DataModelContext();

        public Faculty_Work()
        {
            f = new Faculty();
        }

        public int Add_Faculty(string name,string branch,string EQ,string email,string password,string Dob)
        {
            f.Name = name;
            f.EducationalQualifications = EQ;
            f.Email = email;
            f.Password = password;
            f.DOB = Dob;
            f.BranchId = 1;
            try
            {
                db.Facultys.Add(f);
                db.SaveChanges();
                return 1;
            }

            catch(Exception e)
            {
                Console.WriteLine(e);
                return -1;
            }
        }

        public int Remove_Faculty(int id)
        {
            try
            {
                db.Facultys.Remove(db.Facultys.Find(id));
                return 1;
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return -1;
            }
        }

        public void Add_Result()
        {

        }
    }
    public class Faculty
    {
        [Key]
        public int Id { get; set; }
        
        public string Name { get; set; }

        [ForeignKey("Branch")]
        public int BranchId { get; set; }

        public virtual Branch Branch { get; set; }

        public string EducationalQualifications { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        public string DOB { get; set; }

        public virtual ICollection<Paper> Papers { get; set; }
  
        public virtual ICollection<Question> Questions { get; set; }
    }
}