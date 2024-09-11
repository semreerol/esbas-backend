using esbas_internship_backendproject.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Reflection.Emit;


namespace esbas_internship_backendproject
{
    public class EsbasDbContext : DbContext
    {
#nullable disable
        public DbSet<Events_Users> Events_Users { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Events> Events { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Taskk> Task { get; set; }
        public DbSet<Main_Characteristicts> Main_Characteristicts { get; set; }
        public DbSet<Other_Characteristicts> Other_Characteristicts { get; set; }
        public DbSet<CostCenters> CostCenters { get; set; }
        public DbSet<Event_Type> Event_Type { get; set; }
        public DbSet<Event_Location> Event_Location { get; set; }
        public DbSet<User_Gender> User_Gender { get; set; }


        public EsbasDbContext(DbContextOptions<EsbasDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder Modelbuilder)
        {

            Modelbuilder.Entity<Events_Users>().HasKey(eu => eu.ID);
            Modelbuilder.Entity<Events_Users>().ToTable("Events_Users");

            Modelbuilder.Entity<Users>().HasKey(u => u.UserID);
            Modelbuilder.Entity<Users>().HasIndex(u => u.CardID).IsUnique();
            Modelbuilder.Entity<Users>().ToTable("Users");

            Modelbuilder.Entity<Events>().HasKey(e => e.EventID);
            Modelbuilder.Entity<Events>().ToTable("Events");

            Modelbuilder.Entity<Department>().HasKey(d => d.DepartmentID);
            Modelbuilder.Entity<Department>().ToTable("Department");

            Modelbuilder.Entity<Taskk>().HasKey(t => t.TaskID);
            Modelbuilder.Entity<Taskk>().ToTable("Taskk");

            Modelbuilder.Entity<Main_Characteristicts>().HasKey(mc => mc.MC_ID);
            Modelbuilder.Entity<Main_Characteristicts>().ToTable("Main_Characteristicts");

            Modelbuilder.Entity<Other_Characteristicts>().HasKey(oc => oc.OC_ID);
            Modelbuilder.Entity<Other_Characteristicts>().ToTable("Other_Characteristicts");

            Modelbuilder.Entity<CostCenters>().HasKey(cc => cc.CostCenterID);
            Modelbuilder.Entity<CostCenters>().ToTable("CostCenters");

            Modelbuilder.Entity<Event_Type>().HasKey(et => et.T_ID);
            Modelbuilder.Entity<Event_Type>().ToTable("Event_Type");

            Modelbuilder.Entity<Event_Location>().HasKey(el => el.L_ID);
            Modelbuilder.Entity<Event_Location>().ToTable("Event_Location");
   

            Modelbuilder.Entity<User_Gender>().HasKey(ug => ug.G_ID);
            Modelbuilder.Entity<User_Gender>().ToTable("User_Gender");

            Modelbuilder.Entity<Events_Users>()
                 .HasOne(eu => eu.Event)
                 .WithMany()
                 .HasForeignKey(eu => eu.EventID);

            Modelbuilder.Entity<Events_Users>()
                .HasOne(eu => eu.User)
                .WithMany()
                .HasForeignKey(eu => eu.CardID)
                .HasPrincipalKey(u => u.CardID);

            Modelbuilder.Entity<Events>()
                .HasOne(e => e.Event_Location)
                .WithMany()
                .HasForeignKey(e => e.L_ID);

            Modelbuilder.Entity<Events>()
                .HasOne(e => e.Event_Type)
                .WithMany()
                .HasForeignKey(e => e.T_ID);

            Modelbuilder.Entity<Users>()
                .HasOne(u => u.User_Gender)
                .WithMany()
                .HasForeignKey(u => u.G_ID);

            Modelbuilder.Entity<Users>()
                .HasOne(u => u.Main_Characteristicts)
                .WithMany()
                .HasForeignKey(u => u.MC_ID);

            Modelbuilder.Entity<Users>()
               .HasOne(u => u.Other_Characteristicts)
               .WithMany()
               .HasForeignKey(u => u.OC_ID);

            Modelbuilder.Entity<Users>()
               .HasOne(u => u.Department)
               .WithMany()
               .HasForeignKey(u => u.DepartmentID);

            Modelbuilder.Entity<Department>()
                .HasOne(d => d.Task)
                .WithMany()
                .HasForeignKey(d => d.TaskID);

            Modelbuilder.Entity<Department>()
                .HasOne(d => d.CostCenters)
                .WithMany()
                .HasForeignKey(d => d.CostCenterID);


            base.OnModelCreating(Modelbuilder);
        }
    }
}
