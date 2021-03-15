using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuizApp_CoreWebAPI.Models
{
    public partial class McqDBContext : DbContext
    {
      

        public McqDBContext(DbContextOptions<McqDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<McqQuestion> McqQuestion { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<McqQuestion>(entity =>
            {
                entity.HasKey(e => e.McqId)
                    .HasName("PK__mcqQuest__FD2C2EC251467301");

                entity.ToTable("mcqQuestion");

                entity.Property(e => e.McqId).HasColumnName("mcqId");

                entity.Property(e => e.Ans)
                    .HasColumnName("ans")
                    .HasMaxLength(255);

                entity.Property(e => e.ExtraAnswer)
                    .HasColumnName("extraAnswer")
                    .HasMaxLength(255);

                entity.Property(e => e.Img).HasColumnName("img");

                entity.Property(e => e.Question)
                    .HasColumnName("question")
                    .HasMaxLength(255);

                entity.Property(e => e.QuestionNo)
                    .HasColumnName("questionNo")
                    .HasMaxLength(100);

                entity.Property(e => e.QuizType)
                    .HasColumnName("quizType")
                    .HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
