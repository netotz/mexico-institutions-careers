using System.IO;
using Microsoft.EntityFrameworkCore;

namespace Database
{
    public class SchoolsContext : DbContext
    {
        private readonly string _connectionString;

        public SchoolsContext()
        {
            _connectionString = File.ReadAllText(".connection");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Institution>(institution =>
            {
                institution.ToTable("CatInstitucion");
                
                institution.Property(i => i.Name)
                    .HasColumnName("nombre");
                institution.Property(i => i.OriginalId)
                    .HasColumnName("idOriginal");

                institution.HasMany(i => i.Careers)
                    .WithMany(c => c.Institutions)
                    .UsingEntity<InstitutionCareer>(
                        ic => ic.HasOne(j => j.Career)
                            .WithMany(jc => jc.InstitutionCareers)
                            .HasForeignKey(j => j.CareerId),
                        ic => ic.HasOne(j => j.Institution)
                            .WithMany(ji => ji.InstitutionCareers)
                            .HasForeignKey(j => j.InstitutionId),
                        ic => {
                            ic.ToTable("CatRelacionInstitucionCarrera");

                            ic.Property(j => j.InstitutionId)
                                .HasColumnName("idInstitucion");
                            ic.Property(j => j.CareerId)
                                .HasColumnName("idCarrera");

                            ic.HasKey(j => new { j.InstitutionId, j.CareerId });
                        });
            });

            modelBuilder.Entity<Career>(career => {
                career.ToTable("CatCarrera");

                career.Property(c => c.Name)
                    .HasColumnName("nombre");
                career.Property(c => c.OriginalId)
                    .HasColumnName("originalId");
                career.Property(c => c.DegreeId)
                    .HasColumnName("idGrado");
            });

            modelBuilder.Entity<Degree>(degree => {
                degree.ToTable("CatGradoCarrera");

                degree.Property(c => c.Name)
                    .HasColumnName("nombre");
                degree.Property(c => c.OriginalId)
                    .HasColumnName("originalId");
            });
        }
    }
}
