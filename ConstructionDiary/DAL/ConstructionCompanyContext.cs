using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ConstructionDiary.DAL
{
    public class ConstructionCompanyContext : IdentityDbContext<User,Role,string>
    {
        public ConstructionCompanyContext(DbContextOptions<ConstructionCompanyContext> options):base(options)
        {
        }

        public DbSet<City> City { get; set; }
        public DbSet<ConstructionSite> ConstructionSites { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<ControlEntry> ControlEntries { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Machine> Machines { get; set; }
        public DbSet<Remark> Remarks { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Tool> Tools { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Worksheet> Worksheets { get; set; }
        public DbSet<ConstructionSiteManager> ConstructionSiteManagers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<WorkerTask>()
                .HasOne(wt => wt.Task)
                .WithMany(t => t.WorkerTasks)
                .HasForeignKey(wt => wt.TaskId);

            modelBuilder.Entity<WorkerTask>()
                .HasKey(wt => new { wt.WorkerId, wt.TaskId });

            modelBuilder.Entity<WorkerTask>()
                .HasOne(wt => wt.Worker)
                .WithMany(w => w.WorkerTasks)
                .HasForeignKey(wt => wt.WorkerId);

            modelBuilder.Entity<WorkerTask>()
                .HasOne(wt => wt.Task)
                .WithMany(t => t.WorkerTasks)
                .HasForeignKey(wt => wt.TaskId);

            modelBuilder.Entity<WorksheetTool>()
                .HasKey(wt => new { wt.WorksheetId, wt.ToolId });

            modelBuilder.Entity<WorksheetTool>()
                .HasOne(wt => wt.Worksheet)
                .WithMany(w => w.WorksheetTools)
                .HasForeignKey(wt => wt.WorksheetId);

            modelBuilder.Entity<WorksheetTool>()
                .HasOne(wt => wt.Tool)
                .WithMany(t => t.WorksheetTools)
                .HasForeignKey(wt => wt.ToolId);

            modelBuilder.Entity<WorksheetMaterial>()
                .HasKey(wm => new { wm.WorksheetId, wm.MaterialId });

            modelBuilder.Entity<WorksheetMaterial>()
                .HasOne(wm => wm.Worksheet)
                .WithMany(w => w.WorksheetMaterials)
                .HasForeignKey(wm => wm.WorksheetId);

            modelBuilder.Entity<WorksheetMaterial>()
                .HasOne(wm => wm.Material)
                .WithMany(m => m.WorksheetMaterials)
                .HasForeignKey(wm => wm.MaterialId);


            modelBuilder.Entity<WorksheetMachine>()
               .HasKey(wm => new { wm.WorksheetId, wm.MachineId });

            modelBuilder.Entity<WorksheetMachine>()
                .HasOne(wm => wm.Worksheet)
                .WithMany(w => w.WorksheetMachines)
                .HasForeignKey(wm => wm.WorksheetId);

            modelBuilder.Entity<WorksheetMachine>()
                .HasOne(wm => wm.Machine)
                .WithMany(m => m.WorksheetMachines)
                .HasForeignKey(wm => wm.MachineId);

            modelBuilder.Entity<ConstructionSiteSiteManager>()
                .HasKey(cssm => new { cssm.ConstructionSiteId, cssm.ConstructionSiteManagerId });

            modelBuilder.Entity<ConstructionSiteSiteManager>()
                .HasOne(cssm => cssm.ConstructionSite)
                .WithMany(cs => cs.ConstructionSiteManagers)
                .HasForeignKey(cssm => cssm.ConstructionSiteId);

            modelBuilder.Entity<ConstructionSiteSiteManager>()
                .HasOne(cssm => cssm.ConstructionSiteManager)
                .WithMany(csm => csm.ConstructionSites)
                .HasForeignKey(cssm => cssm.ConstructionSiteManagerId);
        }
    }
}
