using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Commands;

namespace Todo.Domain.Tests.CommandTests;

[TestClass]
public class CreateTodoCommandTests
{
    private readonly CreateTodoCommand _invalidCommand = new("", DateTime.Now, "");
    private readonly CreateTodoCommand _validCommand = new("Titulo da tarefa", DateTime.Now, "Fábio Trindade");

    public CreateTodoCommandTests()
    {
        _invalidCommand.Validate();
        _validCommand.Validate();
    }

    [TestMethod]
    public void Given_an_invalid_create_command()
    {
        Assert.AreEqual(_invalidCommand.IsValid, false);
    }

    [TestMethod]
    public void Given_an_valid_create_command()
    {
        Assert.AreEqual(_validCommand.IsValid, true);
    }
}