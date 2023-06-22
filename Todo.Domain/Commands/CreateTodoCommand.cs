using Flunt.Notifications;
using Flunt.Validations;
using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands;

public class CreateTodoCommand : Notifiable<Notification>, ICommand
{
    public CreateTodoCommand() { }

    public CreateTodoCommand(string? title
        , string? user)
    {
        Title = title;
        User = user;
    }

    public string? Title { get; set; }

    public string? User { get; set; }

    public void Validate()
    {
        const int minLengthTitle = 3;
        const int maxLengthUser = 6;

        AddNotifications(
            new Contract<Notification>()
                .Requires()
                .IsGreaterThan(Title, minLengthTitle, nameof(Title), string.Format(Constants.IsGreaterThan, nameof(Title), minLengthTitle))
                .IsGreaterThan(User, maxLengthUser, nameof(User), string.Format(Constants.IsGreaterThan, nameof(User), maxLengthUser))
        );
    }
}