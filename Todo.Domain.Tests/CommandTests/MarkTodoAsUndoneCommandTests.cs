using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Commands;

namespace Todo.Domain.Tests.CommandTests;

[TestClass]
public class MarkTodoAsUndoneCommandTests
{
    private readonly MarkTodoAsUndoneCommand _invalidCommand = new(Guid.NewGuid(), "");
    private readonly MarkTodoAsUndoneCommand _validCommand = new(Guid.NewGuid(), "Fábio Trindade");

    public MarkTodoAsUndoneCommandTests()
    {
        _invalidCommand.Validate();
        _validCommand.Validate();
    }

    [TestMethod]
    public void Given_an_invalid_mark_as_undone_command()
    {
        Assert.AreEqual(_invalidCommand.IsValid, false);
    }

    [TestMethod]
    public void Given_an_valid_mark_as_undone_command()
    {
        Assert.AreEqual(_validCommand.IsValid, true);
    }
}