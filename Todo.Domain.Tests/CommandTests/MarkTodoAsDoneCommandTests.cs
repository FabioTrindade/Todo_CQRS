using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Commands;

namespace Todo.Domain.Tests.CommandTests;

[TestClass]
public class MarkTodoAsDoneCommandTests
{
    private readonly MarkTodoAsDoneCommand _invalidCommand = new(Guid.NewGuid(), "");
    private readonly MarkTodoAsDoneCommand _validCommand = new(Guid.NewGuid(), "Fábio Trindade");

    public MarkTodoAsDoneCommandTests()
    {
        _invalidCommand.Validate();
        _validCommand.Validate();
    }

    [TestMethod]
    public void Given_an_invalid_mark_as_done_command()
    {
        Assert.AreEqual(_invalidCommand.IsValid, false);
    }

    [TestMethod]
    public void Given_an_valid_mark_as_done_command()
    {
        Assert.AreEqual(_validCommand.IsValid, true);
    }
}