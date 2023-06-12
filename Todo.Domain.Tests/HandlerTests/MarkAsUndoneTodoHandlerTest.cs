using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Commands;
using Todo.Domain.Handlers;
using Todo.Domain.Tests.Repositories;

namespace Todo.Domain.Tests.HandlerTests;

[TestClass]
public class MarkAsUndoneTodoHandlerTest
{
    private readonly MarkTodoAsUndoneCommand _invalidCommand = new(Guid.NewGuid(), "");
    private readonly MarkTodoAsUndoneCommand _validCommand = new(Guid.NewGuid(), "Fábio Trindade");
    private readonly TodoHandler _handler = new(new FakeTodoRepository());
    private GenericCommandResult _result = new();

    public MarkAsUndoneTodoHandlerTest() { }

    [TestMethod]
    public void Given_an_invalid_command_must_interrupt_execution()
    {
        _result = (GenericCommandResult)_handler.Handler(_invalidCommand);
        Assert.AreEqual(_result.Success, false);
    }

    [TestMethod]
    public void Given_an_valid_command_mark_as_undone_todo()
    {
        _result = (GenericCommandResult)_handler.Handler(_validCommand);
        Assert.AreEqual(_result.Success, true);
    }
}