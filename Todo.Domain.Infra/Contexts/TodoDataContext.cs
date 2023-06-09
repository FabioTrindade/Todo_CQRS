using Microsoft.EntityFrameworkCore;
using Todo.Domain.Entities;

namespace Todo.Domain.Infra.Contexts;

public class TodoDataContext : DbContext
{
    public TodoDataContext(DbContextOptions<TodoDataContext> options) : base(options)
    {
    }

    public DbSet<TodoItem> Todos { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<TodoItem>().ToTable("Todo");
        builder.Entity<TodoItem>().Property(p => p.Id);
        builder.Entity<TodoItem>().Property(p => p.User).HasMaxLength(120).HasColumnType("varchar(120)");
        builder.Entity<TodoItem>().Property(p => p.Title).HasMaxLength(160).HasColumnType("varchar(160)");
        builder.Entity<TodoItem>().Property(p => p.Done).HasColumnType("bit");
        builder.Entity<TodoItem>().Property(p => p.CreatedAt).HasColumnType("datetime");
        builder.Entity<TodoItem>().HasIndex(i => i.User);
    }
}