
using Microsoft.EntityFrameworkCore;
using Todo.Domain.Entities;
using Todo.Domain.Infra.Contexts;
using Todo.Domain.Queries;
using Todo.Domain.Repositories;

namespace Todo.Domain.Infra.Repositories;

public class TodoRepository : ITodoRepository
{
    private readonly TodoDataContext _context;

    public TodoRepository(TodoDataContext context)
    {
        _context = context;
    }

    public void Create(TodoItem todo)
    {
        _context.Todos.Add(todo);
        _context.SaveChanges();
    }

    public IEnumerable<TodoItem> GetAll(string user)
        => _context
                .Todos
                .AsNoTracking()
                .Where(TodoQueries.GetAll(user))
                .OrderBy(o => o.Date);


    public IEnumerable<TodoItem> GetAllDone(string user)
        => _context
                .Todos
                .AsNoTracking()
                .Where(TodoQueries.GetAllDone(user))
                .OrderBy(o => o.Date);

    public IEnumerable<TodoItem> GetAllUndone(string user)
        => _context
                .Todos
                .AsNoTracking()
                .Where(TodoQueries.GetAllUndone(user))
                .OrderBy(o => o.Date);

    public TodoItem GetById(Guid id, string user)
        => _context
                .Todos
                .FirstOrDefault(w => w.Id == id && w.User == user);

    public IEnumerable<TodoItem> GetPeriod(string user, DateTime date, bool done)
        => _context
                .Todos
                .AsNoTracking()
                .Where(TodoQueries.GetPeriod(user, date, done))
                .OrderBy(o => o.Date);

    public void Update(TodoItem todo)
    {
        _context.Entry(todo).State = EntityState.Modified;
        _context.SaveChanges();
    }
}