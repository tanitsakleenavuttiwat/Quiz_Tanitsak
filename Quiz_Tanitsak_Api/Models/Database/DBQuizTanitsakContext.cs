using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Quiz_Tanit_API.Models.Database;

public partial class DBQuizTanitsakContext : DbContext
{
    public DBQuizTanitsakContext()
    {
    }

    public DBQuizTanitsakContext(DbContextOptions<DBQuizTanitsakContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbMimformationUser> TbMimformationUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=10.5.56.35;Database=DBQuiz_Tanitsak;User ID=sa;Password=P@ssw0rd;Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbMimformationUser>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__TbMImfor__1788CC4C75E5AD9E");

            entity.ToTable("TbMImformationUser");

            entity.Property(e => e.Address).HasMaxLength(500);
            entity.Property(e => e.Birthday).HasColumnType("datetime");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Firstname).HasMaxLength(300);
            entity.Property(e => e.LastName).HasMaxLength(300);
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
