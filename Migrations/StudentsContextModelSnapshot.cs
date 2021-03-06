// <auto-generated />
using System;
using LearnerAPI.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LearnerAPI.Migrations
{
    [DbContext(typeof(StudentsContext))]
    partial class StudentsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.7");

            modelBuilder.Entity("LearnerAPI.Models.Student", b =>
                {
                    b.Property<byte[]>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varbinary(16)");

                    b.Property<string>("Initials")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("StudentNumber")
                        .HasMaxLength(8)
                        .HasColumnType("int");

                    b.Property<int>("StudyId")
                        .HasColumnType("int");

                    b.HasKey("StudentId");

                    b.HasIndex("StudyId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("LearnerAPI.Models.Study", b =>
                {
                    b.Property<int>("StudyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("StudyName")
                        .HasColumnType("text");

                    b.HasKey("StudyId");

                    b.ToTable("Studies");
                });

            modelBuilder.Entity("LearnerAPI.Models.Student", b =>
                {
                    b.HasOne("Learner.Models.Study", "Study")
                        .WithMany()
                        .HasForeignKey("StudyId");

                    b.Navigation("Study");
                });

            modelBuilder.Entity("LearnerAPI.Models.Study", b =>
                {
                    b.Navigation("Students");
                });
#pragma warning restore 612, 618
        }
    }
}
