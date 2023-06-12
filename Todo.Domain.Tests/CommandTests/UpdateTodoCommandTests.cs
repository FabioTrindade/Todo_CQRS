using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Commands;

namespace Todo.Domain.Tests.CommandTests;

[TestClass]
public class UpdateTodoCommandTests
{
    private readonly UpdateTodoCommand _invalidCommand = new(Guid.NewGuid(), "", "");
    private readonly UpdateTodoCommand _validCommand = new(Guid.NewGuid(), "Titulo da tarefa", "Fábio Trindade");

    public UpdateTodoCommandTests()
    {
        _invalidCommand.Validate();
        _validCommand.Validate();
    }

    [TestMethod]
    public void Given_an_invalid_update_command()
    {
        Assert.AreEqual(_invalidCommand.IsValid, false);
    }

    [TestMethod]
    public void Given_an_valid_update_command()
    {
        Assert.AreEqual(_validCommand.IsValid, true);
    }
}