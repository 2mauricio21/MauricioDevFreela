using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Persistence
{
    public class DevFreelaDbContext : DbContext
    {
        public DevFreelaDbContext(DbContextOptions<DevFreelaDbContext> options) : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<UserSkill> UserSkills { get; set; }
        public DbSet<ProjectComment> ProjectComments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>()
             //.ToTable("tb_project")  - se quiser definir o nome da tabela   
             .HasKey(p => p.Id);   // Chave Primaria

            modelBuilder.Entity<Project>()
                .HasOne(p => p.Freelancer)
                .WithMany(f => f.FreeLanceProjects)
                .HasForeignKey(p => p.IdFreeLancer)
                .OnDelete(DeleteBehavior.Restrict); // restrict impede remover uma entidade que tem relacionamento com outras

            modelBuilder.Entity<Project>()
                .HasOne(p => p.Client)
                .WithMany(f => f.OwnerProjects)
                .HasForeignKey(p => p.IdClient)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProjectComment>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<ProjectComment>()
                .HasOne(p => p.Project)
                .WithMany(p => p.Comments)
                .HasForeignKey(p => p.IdProject)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProjectComment>()
                .HasOne(p => p.User)
                .WithMany(p => p.Comments)
                .HasForeignKey(p => p.IdUser)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Skill>()
                .HasKey(s => s.Id);

            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Skills)
                .WithOne()
                .HasForeignKey(u => u.IdSkill)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserSkill>()
                .HasKey(u => u.Id);
        }
    }
}
