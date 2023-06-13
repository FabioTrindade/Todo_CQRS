using Todo.Domain.Entities;
using Todo.Domain.Repositories;

namespace Todo.Domain.Tests.Repositories;

public class FakeTodoRepository : ITodoRepository
{
    public void Create(TodoItem todo)
    {
    }

    public IEnumerable<TodoItem> GetAll(string user)
    {
        return new List<TodoItem>();
    }

    public IEnumerable<TodoItem> GetAllDone(string user)
    {
        return new List<TodoItem>();
    }

    public IEnumerable<TodoItem> GetAllUndone(string user)
    {
        return new List<TodoItem>();
    }

    public TodoItem GetById(Guid id, string user)
    {
       return new TodoItem("", DateTime.Now, "");
    }

    public IEnumerable<TodoItem> GetPeriod(string user, DateTime date, bool done)
    {
        return new List<TodoItem>();
    }

    public void Update(TodoItem todo)
    {
    }
}