using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace QuizApp_CoreWebAPI.Models
{
    public partial class OnlineQuizDBContext : DbContext
    {
        

        public OnlineQuizDBContext(DbContextOptions<OnlineQuizDBContext> options)
            : base(options)
        {
        }

        public DbSet<UserInfo> UserInfo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__UserInfo__CB9A1CFF43C258F2");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(255);

                entity.Property(e => e.EmailId)
                    .HasColumnName("emailId")
                    .HasMaxLength(255);

                entity.Property(e => e.FirstName)
                    .HasColumnName("firstName")
                    .HasMaxLength(255);

                entity.Property(e => e.PhoneNo)
                    .HasColumnName("phoneNo")
                    .HasMaxLength(50);

                entity.Property(e => e.UserType)
                    .HasColumnName("userType")
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .HasColumnName("lastName")
                    .HasMaxLength(255);

                entity.Property(e => e.Password)
                 .HasColumnName("password")
                 .HasMaxLength(255);

                entity.Property(e => e.Username)
                .HasColumnName("username")
                .HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
