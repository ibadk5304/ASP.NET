using Microsoft.EntityFrameworkCore;
using nscccoursemap_ibadk5304.Models;

namespace nscccoursemap_ibadk5304.Data {
    public class NSCCCourseMapContext : DbContext
    {
        public NSCCCourseMapContext(DbContextOptions<NSCCCourseMapContext> options)
                : base(options)
        {


        }

        //Define dbsets-> tables
        public DbSet<DiplomaProgram> DiplomaPrograms { get; set; }
        public DbSet<DiplomaProgramYear> DiplomaProgramYears { get; set; }
        public DbSet<DiplomaProgramYearSection> DiplomaProgramYearSections { get; set; }
        public DbSet<AcademicYear> AcademicYears { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<CourseOffering> CourseOfferings { get; set; }
        public DbSet<CoursePrerequisite> CoursePrerequisites { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<AdvisingAssignment> AdvisingAssignments { get; set; }


        //Define programatically othe properties/ relationships/ etc
        //Fluent API

        // CUSTOM CONFIGURATION WITH FLUENT API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // RECONCILE THE MANY TO MANY RECURSIVE (VERSION 1)
            modelBuilder.Entity<Course>()
                .HasMany(c => c.Prerequisites)
                .WithOne(cpr => cpr.Course)
                .HasForeignKey(cpr => cpr.CourseId);
                
            modelBuilder.Entity<Course>()
                .HasMany(c => c.IsPrerequisiteFor)
                .WithOne(cpr => cpr.Prerequisite)
                .HasForeignKey(cpr => cpr.PrerequisiteId);
            modelBuilder.Entity<Course>()
                .HasIndex(c => c.CourseCode)
                .IsUnique();
            modelBuilder.Entity<Instructor>()
                .Property(i=> i.FirstName)
                .IsRequired();
            
            modelBuilder.Entity<Semester>()
                .Property(s=> s.EndDate)
                .HasColumnType("Date");

            //////////////////////////////////
            modelBuilder.Entity<AcademicYear>()
                .HasIndex(ay => ay.Title)
                .IsUnique();

            
            
            // // RECONCILE THE MANY TO MANY RECURSIVE (VERSION 2)
            // modelBuilder.Entity<Course>()
            // .HasMany(c => c.Prerequisites)
            // .WithMany(c => c.IsPrerequisiteFor);
        
            // TURN OFF CASCADE DELETE FOR ALL RELATIONSHIPS
            foreach(var entity in modelBuilder.Model.GetEntityTypes())
            {
                foreach(var fk in entity.GetForeignKeys()){
                    fk.DeleteBehavior = DeleteBehavior.NoAction;
                }
            }
        }
    }
}
