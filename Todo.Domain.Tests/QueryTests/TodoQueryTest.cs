using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Entities;
using Todo.Domain.Queries;

namespace Todo.Domain.Tests.QueryTests;

[TestClass]
public class TodoQueryTest
{
    private List<TodoItem> _items;

    public TodoQueryTest()
    {
        _items = new List<TodoItem>
        {
            new TodoItem("Tarefa 1", "Fábio Trindade"),
            new TodoItem("Tarefa 2", "Fábio Trindade"),
            new TodoItem("Tarefa 3", "Bruna Trindade"),
            new TodoItem("Tarefa 4", "Bruna Trindade"),
        };
    }

    [TestMethod]
    public void Given_an_query_should_return_user_tasks()
    {
        var result = _items.AsQueryable().Where(TodoQueries.GetAll("Fábio Trindade"));
        Assert.AreEqual(2, result.Count());
    }

    [TestMethod]
    public void Given_an_query_should_return_user_tasks_as_done()
    {
        var result = _items.AsQueryable().Where(TodoQueries.GetAllDone("Fábio Trindade"));
        Assert.AreEqual(0, result.Count());
    }

    [TestMethod]
    public void Given_an_query_should_return_user_tasks_as_undone()
    {
        var result = _items.AsQueryable().Where(TodoQueries.GetAllUndone("Fábio Trindade"));
        Assert.AreEqual(2, result.Count());
    }

    [TestMethod]
    public void Given_an_query_should_return_user_tasks_by_period()
    {
        var result = _items.AsQueryable().Where(TodoQueries.GetPeriod("Fábio Trindade", DateTime.Now, false));
        Assert.AreEqual(2, result.Count());
    }
}