// <auto-generated />
using Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Database.Migrations
{
    [DbContext(typeof(SchoolsContext))]
    partial class SchoolsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Database.Career", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("DegreeId")
                        .HasColumnType("int")
                        .HasColumnName("idGrado");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("nombre");

                    b.HasKey("Id");

                    b.HasIndex("DegreeId");

                    b.ToTable("CatCarrera");
                });

            modelBuilder.Entity("Database.Degree", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("nombre");

                    b.HasKey("Id");

                    b.ToTable("CatGradoCarrera");
                });

            modelBuilder.Entity("Database.Institution", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("nombre");

                    b.HasKey("Id");

                    b.ToTable("CatInstitucion");
                });

            modelBuilder.Entity("Database.InstitutionCareer", b =>
                {
                    b.Property<int>("InstitutionId")
                        .HasColumnType("int")
                        .HasColumnName("idInstitucion");

                    b.Property<int>("CareerId")
                        .HasColumnType("int")
                        .HasColumnName("idCarrera");

                    b.HasKey("InstitutionId", "CareerId");

                    b.HasIndex("CareerId");

                    b.ToTable("CatRelacionInstitucionCarrera");
                });

            modelBuilder.Entity("Database.Career", b =>
                {
                    b.HasOne("Database.Degree", "Degree")
                        .WithMany("Careers")
                        .HasForeignKey("DegreeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Degree");
                });

            modelBuilder.Entity("Database.InstitutionCareer", b =>
                {
                    b.HasOne("Database.Career", "Career")
                        .WithMany("InstitutionCareers")
                        .HasForeignKey("CareerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Database.Institution", "Institution")
                        .WithMany("InstitutionCareers")
                        .HasForeignKey("InstitutionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Career");

                    b.Navigation("Institution");
                });

            modelBuilder.Entity("Database.Career", b =>
                {
                    b.Navigation("InstitutionCareers");
                });

            modelBuilder.Entity("Database.Degree", b =>
                {
                    b.Navigation("Careers");
                });

            modelBuilder.Entity("Database.Institution", b =>
                {
                    b.Navigation("InstitutionCareers");
                });
#pragma warning restore 612, 618
        }
    }
}
