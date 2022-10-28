using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EDO.Models
{
    public partial class EDOContext : DbContext
    {
        public EDOContext()
        {
        }

        public EDOContext(DbContextOptions<EDOContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Document> Documents { get; set; } = null!;
        public virtual DbSet<DocumentStage> DocumentStages { get; set; } = null!;
        public virtual DbSet<DocumentType> DocumentTypes { get; set; } = null!;
        public virtual DbSet<Stage> Stages { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Document>(entity =>
            {
                entity.ToTable("Document");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.CreateDate).HasColumnType("timestamp without time zone");

                entity.Property(e => e.Title).HasMaxLength(150);

                entity.HasOne(d => d.AuthorNavigation)
                    .WithMany(p => p.DocumentAuthorNavigations)
                    .HasForeignKey(d => d.Author)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Document_Author_fkey");

                entity.HasOne(d => d.RecipientNavigation)
                    .WithMany(p => p.DocumentRecipientNavigations)
                    .HasForeignKey(d => d.Recipient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Document_Recipient_fkey");

                entity.HasOne(d => d.TypeNavigation)
                    .WithMany(p => p.Documents)
                    .HasForeignKey(d => d.Type)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Document_Type_fkey");
            });

            modelBuilder.Entity<DocumentStage>(entity =>
            {
                entity.HasKey(e => e.VerifierId)
                    .HasName("Document_Stage_pkey");

                entity.ToTable("Document_Stage");

                entity.Property(e => e.VerifierId).ValueGeneratedNever();

                entity.Property(e => e.VerifyDate).HasColumnType("timestamp without time zone");

                entity.HasOne(d => d.Document)
                    .WithMany(p => p.DocumentStages)
                    .HasForeignKey(d => d.DocumentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Document_Stage_DocumentId_fkey");

                entity.HasOne(d => d.Stage)
                    .WithMany(p => p.DocumentStages)
                    .HasForeignKey(d => d.StageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Document_Stage_StageId_fkey");

                entity.HasOne(d => d.Verifier)
                    .WithOne(p => p.DocumentStage)
                    .HasForeignKey<DocumentStage>(d => d.VerifierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Document_Stage_VerifierId_fkey");
            });

            modelBuilder.Entity<DocumentType>(entity =>
            {
                entity.ToTable("DocumentType");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Type).HasMaxLength(150);
            });

            modelBuilder.Entity<Stage>(entity =>
            {
                entity.ToTable("Stage");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("Name");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.Login).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(64);

                entity.Property(e => e.SecondName).HasMaxLength(50);

                entity.Property(e => e.ThirdName).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
