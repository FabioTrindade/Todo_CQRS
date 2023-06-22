using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Todo.Domain.Commands;
using Todo.Domain.Entities;
using Todo.Domain.Handlers;
using Todo.Domain.Repositories;

namespace Todo.Api.Controllers;

[ApiController]
[Route("v1/todos")]
[Authorize]
public class TodoController : MainController
{
    [Route("")]
    [HttpGet]
    public IEnumerable<TodoItem> GetAll(
        [FromServices] ITodoRepository repository
    )
        => repository.GetAll(GetCurrentUser);

    [Route("done")]
    [HttpGet]
    public IEnumerable<TodoItem> GetAllDone(
        [FromServices] ITodoRepository repository
    )
        => repository.GetAllDone(GetCurrentUser);
    

    [Route("undone")]
    [HttpGet]
    public IEnumerable<TodoItem> GetAllUndone(
        [FromServices] ITodoRepository repository
    )
        => repository.GetAllUndone(GetCurrentUser);
    

    [Route("done/today")]
    [HttpGet]
    public IEnumerable<TodoItem> GetDoneForToday(
        [FromServices] ITodoRepository repository
    )
        => repository.GetPeriod(
            GetCurrentUser
            , DateTime.Now.Date
            , true);
    

    [Route("undone/today")]
    [HttpGet]
    public IEnumerable<TodoItem> GetUndoneForToday(
        [FromServices] ITodoRepository repository
    )
        => repository.GetPeriod(
            GetCurrentUser
            , DateTime.Now.Date
            , false);

    [Route("done/tomorrow")]
    [HttpGet]
    public IEnumerable<TodoItem> GetDoneForTomorrow(
        [FromServices] ITodoRepository repository
    )
        => repository.GetPeriod(
            GetCurrentUser
            , DateTime.Now.Date.AddDays(1)
            , true);

    [Route("undone/tomorrow")]
    [HttpGet]
    public IEnumerable<TodoItem> GetUndoneForTomorrow(
        [FromServices] ITodoRepository repository
    )
        => repository.GetPeriod(
            GetCurrentUser
            , DateTime.Now.Date.AddDays(1)
            , false);

    [Route("")]
    [HttpPost]
    public GenericCommandResult Create(
        [FromBody] CreateTodoCommand command,
        [FromServices] TodoHandler handler)
    {
        command.User = GetCurrentUser;
        return (GenericCommandResult)handler.Handler(command);
    }

    [Route("")]
    [HttpPut]
    public GenericCommandResult Update(
        [FromBody] UpdateTodoCommand command,
        [FromServices] TodoHandler handler)
    {
        command.User = GetCurrentUser;
        return (GenericCommandResult)handler.Handler(command);
    }

    [Route("mark-as-done")]
    [HttpPut]
    public GenericCommandResult MaskAsDone(
        [FromBody] MarkTodoAsDoneCommand command,
        [FromServices] TodoHandler handler)
    {
        command.User = GetCurrentUser;
        return (GenericCommandResult)handler.Handler(command);
    }

    [Route("masrk-as-undone")]
    [HttpPut]
    public GenericCommandResult MarkAsUndone(
        [FromBody] MarkTodoAsUndoneCommand command,
        [FromServices] TodoHandler handler)
    {
        command.User = GetCurrentUser;
        return (GenericCommandResult)handler.Handler(command);
    }
}