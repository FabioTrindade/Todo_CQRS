
using System.Linq.Expressions;
using Todo.Domain.Entities;

namespace Todo.Domain.Queries;

public static class TodoQueries
{
    public static Expression<Func<TodoItem, bool>> GetAll(string user)
        => t => t.User == user;

    public static Expression<Func<TodoItem, bool>> GetAllDone(string user)
        => t => t.User == user && t.Done;

    public static Expression<Func<TodoItem, bool>> GetAllUndone(string user)
        => t => t.User == user && !t.Done;

    public static Expression<Func<TodoItem, bool>> GetPeriod(string user, DateTime date, bool done)
        => t =>
            t.User == user &&
            t.Done == done &&
            t.CreatedAt.Date == date.Date;

    public static Expression<Func<TodoItem, bool>> GetById(Guid id, string user)
        => t =>
            t.Id == id &&
            t.User == user;
}