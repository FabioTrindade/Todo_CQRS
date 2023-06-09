using Flunt.Notifications;
using Flunt.Validations;
using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands;

public class MarkTodoAsDoneCommand : Notifiable<Notification>, ICommand
{
    public MarkTodoAsDoneCommand() { }

    public MarkTodoAsDoneCommand(Guid id
        , string? user)
    {
        Id = id;
        User = user;
    }

    public Guid Id { get; set; }

    public string? User { get; set; }

    public void Validate()
    {
        const int maxLengthUser = 6;

        AddNotifications(
            new Contract<Notification>()
                .Requires()
                .IsGreaterThan(User, maxLengthUser, nameof(User), string.Format(Constants.IsGreaterThan, nameof(User), maxLengthUser))
        );
    }
}