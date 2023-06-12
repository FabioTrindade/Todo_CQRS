
using Microsoft.EntityFrameworkCore;
using Todo.Domain.Entities;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base()
    {
    }

    public DbSet<TodoItem> Todos { get; set;}
} 