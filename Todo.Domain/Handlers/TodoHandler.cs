using Flunt.Notifications;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;
using Todo.Domain.Handlers.Contracts;
using Todo.Domain.Repositories;

namespace Todo.Domain.Handlers;

public class TodoHandler :
    Notifiable<Notification>,
    IHandler<CreateTodoCommand>
{
    private readonly ITodoRepository _repository;

    public TodoHandler(ITodoRepository repository)
    {
        _repository = repository;
    }

    public ICommandResult Handler(CreateTodoCommand command)
    {
        command.Validate();

        if(!command.IsValid)
            return new GenericCommandResult(
                false,
                "Ops, parece que sua tarefa está errada!",
                command.Notifications
            );

        var todo = new TodoItem(command.Title, command.Date, command.User);
        
        _repository.Create(todo);

        return new GenericCommandResult(true, "Tarefa salva.", todo);
    }
}