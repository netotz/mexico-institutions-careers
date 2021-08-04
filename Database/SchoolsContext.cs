using System.IO;
using Microsoft.EntityFrameworkCore;

namespace Database
{
    public class SchoolsContext : DbContext
    {
        private readonly string _connectionString;

        public SchoolsContext()
        {
            var path = ".connection";
            // if the instance is being created outside the project
            if (!File.Exists(path)){
                path = @"Database\.connection";
            }
            _connectionString = File.ReadAllText(path);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        public DbSet<Institution> Institutions { get; set; }
        public DbSet<Career> Careers { get; set; }
        public DbSet<Degree> Degrees { get; set; }
        public DbSet<InstitutionCareer> InstitutionCareers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Institution>(institution =>
            {
                institution.ToTable("CatInstitucion");

                institution.Property(i => i.Id)
                    .ValueGeneratedNever();
                institution.Property(i => i.Name)
                    .HasColumnName("nombre");

                institution.HasMany(i => i.Careers)
                    .WithMany(c => c.Institutions)
                    .UsingEntity<InstitutionCareer>(
                        ic => ic.HasOne(j => j.Career)
                            .WithMany(jc => jc.InstitutionCareers)
                            .HasForeignKey(j => j.CareerId),
                        ic => ic.HasOne(j => j.Institution)
                            .WithMany(ji => ji.InstitutionCareers)
                            .HasForeignKey(j => j.InstitutionId),
                        ic =>
                        {
                            ic.ToTable("CatRelacionInstitucionCarrera");

                            ic.Property(j => j.InstitutionId)
                                .HasColumnName("idInstitucion");
                            ic.Property(j => j.CareerId)
                                .HasColumnName("idCarrera");

                            ic.HasKey(j => new { j.InstitutionId, j.CareerId });
                        });
            });

            modelBuilder.Entity<Career>(career =>
            {
                career.ToTable("CatCarrera");

                career.HasOne(c => c.Degree)
                    .WithMany(d => d.Careers)
                    .HasForeignKey(c => c.DegreeId);
                career.Property(c => c.Id)
                    .ValueGeneratedNever();
                career.Property(c => c.Name)
                    .HasColumnName("nombre");
                career.Property(c => c.DegreeId)
                    .HasColumnName("idGrado");
            });

            modelBuilder.Entity<Degree>(degree =>
            {
                degree.ToTable("CatGradoCarrera");

                degree.Property(d => d.Id)
                    .ValueGeneratedNever();
                degree.Property(c => c.Name)
                    .HasColumnName("nombre");
            });
        }
    }
}
