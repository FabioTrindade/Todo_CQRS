using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Commands;
using Todo.Domain.Handlers;
using Todo.Domain.Tests.Repositories;

namespace Todo.Domain.Tests.HandlerTests;

[TestClass]
public class CreateTodoHandlerTest
{
    private readonly CreateTodoCommand _invalidCommand = new("", DateTime.Now, "");
    private readonly CreateTodoCommand _validCommand = new("Titulo da tarefa", DateTime.Now, "Fábio Trindade");
    private readonly TodoHandler _handler = new TodoHandler(new FakeTodoRepository());
    private GenericCommandResult _result = new GenericCommandResult();

    public CreateTodoHandlerTest()
    {
        
    }

    [TestMethod]
    public void Dado_um_comando_invalido_deve_interromper_a_execucao()
    {
        _result = (GenericCommandResult)_handler.Handler(_invalidCommand);
        Assert.AreEqual(_result.Success, false);
    }

    [TestMethod]
    public void Dado_um_comando_valido_deve_criar_a_tarefa()
    {
        _result = (GenericCommandResult)_handler.Handler(_validCommand);
        Assert.AreEqual(_result.Success, true);
    }
}