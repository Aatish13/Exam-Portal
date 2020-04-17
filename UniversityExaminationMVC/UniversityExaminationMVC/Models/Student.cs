using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UniversityExaminationMVC.Models
{
    public class Student_Work
    {
        public string Name;
        public string DOB;
        public int Sem;
        public string Branch;
        public string Email;
        public string Phone;
       public static DataModelContext db = new DataModelContext();
        Student s;
        public Student_Work()
        {
            s = new Student();
        }

        public int Create_Student(string name,string password ,string dob, int Sem, string Email, string phone)
        {
            s.Name = name;
            s.Password = password;
            s.DOB = dob;
            s.Sem = Sem;
            s.Email = Email;
            s.Phone = phone;
            s.BranchId = 1;
            s.Branch = null;
            try
            {
                db.Students.Add(s);
                db.SaveChanges();
                return 1;
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return -1;
            }
        }

        public void View_Result(int id)
        {

        }

        public int Update_Details(int id)
        {
            return -1;
        }
    }
    public class Student
    {
        [Key]
        public int Id { get; set; }
        
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
        
        public string DOB { get; set; }

        
        public int Sem { get; set; }
        [Required]
        public string Email { get; set; }
        
        public string Phone { get; set; }

        [ForeignKey("Branch")]
        public int BranchId { get; set; }

        public virtual Branch Branch { get; set; }
    }
}