using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugProj.Data
{
    public class BugProjContext : DbContext
    {
        public DbSet<ProjTasks> ProjTasks { get; set; }
        public DbSet<Bugs> Bugs { get; set; }

        public DbSet<Projects> Projects { get; set;}

        public DbSet<Company> Company { get; set; }

        public DbSet<Clients> Clients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=wwratproj.database.windows.net;Database=WarrenPrjManagerDB;user id=wwratprojAdmin;password=14Butters!;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bugs>((e)=>{
                e.HasOne((d)=> d.Projects)
                .WithMany((b) => b.Bugs ).HasForeignKey((f)=> f.ExtractId);
                
            } );
        }
    }

    public class Bugs
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BugStatus { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? CompleteDate { get; set; }
        public string ExtDescr { get; set; }
        public string ProjType { get; set; }
        public bool? BackLog { get; set; }
        public DateTime? BacklogDate { get; set; }
        public int? CreatedBy { get; set; }
        public int? AssignedUser { get; set; }
        public int? ExtractId { get; set; }
        public virtual ICollection<ProjTasks> ProjTasks { get; set; }

        public virtual Projects Projects {get; set;}
    }

    public class ProjTasks
    {
        public int Id { get; set; }
        [ForeignKey("BugId")]
        public int? BugId { get; set; }
        public string TaskType { get; set; }
        public string Descr { get; set; }
        public string AssignedTo { get; set; }
        public DateTime? CreateDate { get; set; }
        public bool? Complete { get; set; }
        public DateTime? CompleteDate { get; set; }
        public DateTime? DueDate { get; set; }

        public virtual Bugs Bug { get; set; }
    }

    public class Company
    {
        public int Id {get; set;}
        public string Name { get; set; }
        public string Logolink { get; set; }

        public ICollection<Clients> Client { get; set; }   
    }

    public class Clients
    {
        public int id { get; set; }
        public string Name { get; set; } 
        public string Alias { get; set; }
        public string Logolink { get; set; }

        public int CompanyId { get; set;}
        public virtual Company Comp { get; set; }

    }

    public class Projects
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Descr { get; set; }
        public int? ClientId { get; set; }
        public DateTime? CreateDate { get; set; }

        public virtual ICollection<Bugs> Bugs { get; set; }
    }
}