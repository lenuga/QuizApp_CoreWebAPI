using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuizApp_CoreWebAPI.Models
{
    public partial class OnlineContext : DbContext
    {
       

        public OnlineContext(DbContextOptions<OnlineContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TextQuestion> TextQuestion { get; set; }

      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TextQuestion>(entity =>
            {
                entity.HasKey(e => e.TextId)
                    .HasName("PK__textQues__CD8CEB806C22E6EB");

                entity.ToTable("textQuestion");

                entity.Property(e => e.TextId).HasColumnName("textId");

                entity.Property(e => e.Img).HasColumnName("img");

                entity.Property(e => e.Question)
                    .HasColumnName("question")
                    .HasMaxLength(255);

                entity.Property(e => e.QuestionNo)
                    .IsRequired()
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
