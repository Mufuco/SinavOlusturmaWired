using Microsoft.EntityFrameworkCore;
using ProjectTek.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTek.DataAccesLayer.Contexts
{
    public class ProjectTekDbContext : DbContext
    {
        public ProjectTekDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answer>().HasKey(x => x.Id);
            modelBuilder.Entity<Exam>().HasKey(x => x.Id);
            modelBuilder.Entity<ExamQuestion>().HasKey(x => x.Id);
            modelBuilder.Entity<User>().HasKey(x => x.Id);
            modelBuilder.Entity<WiredArticle>().HasKey(x => x.Id);
        }


        public DbSet<Answer> answers { get; set; }  
        public DbSet<Exam> exams { get; set; }  
        public DbSet<ExamQuestion> examQuestions { get; set; }  
        public DbSet<User> users { get; set; }
        public DbSet<WiredArticle> wiredArticles { get; set;}
    }
}
