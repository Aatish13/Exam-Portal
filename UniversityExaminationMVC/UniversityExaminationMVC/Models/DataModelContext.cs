namespace UniversityExaminationMVC.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class DataModelContext : DbContext
    {
        // Your context has been configured to use a 'DataModelContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'UniversityExaminationMVC.Models.DataModelContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'DataModelContext' 
        // connection string in the application configuration file.
        public DataModelContext()
            : base("name=DataModelContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DataModelContext, UniversityExaminationMVC.Migrations.Configuration>());
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Branch> Branches { get; set; }


        public virtual DbSet<Faculty> Facultys { get; set; }


        public virtual DbSet<Exam> Exams { get; set; }


        public virtual DbSet<Paper> Papers { get; set; }
        public virtual DbSet<PaperQuestion> PaperQuestions { get; set; }

        public virtual DbSet<Question> Questions { get; set; }

        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<PaperScore> PaperScores { get; set; }

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}