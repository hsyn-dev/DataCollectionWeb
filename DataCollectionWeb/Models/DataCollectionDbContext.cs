using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataCollectionWeb.Models;

public partial class DataCollectionDbContext : DbContext
{
    public DataCollectionDbContext()
    {
    }

    public DataCollectionDbContext(DbContextOptions<DataCollectionDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<StoryTable> StoryTables { get; set; }

    public virtual DbSet<UserStoryTable> UserStoryTables { get; set; }

    public virtual DbSet<UserTable> UserTables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=DataCollectionDB;Trusted_Connection=True; TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserStoryTable>(entity =>
        {
            entity.HasOne(d => d.Story).WithMany(p => p.UserStoryTables).HasConstraintName("FK_UserStoryTable_StoryTable");

            entity.HasOne(d => d.User).WithMany(p => p.UserStoryTables).HasConstraintName("FK_UserStoryTable_UserTable");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
