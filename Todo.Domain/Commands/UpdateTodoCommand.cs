using Flunt.Notifications;
using Flunt.Validations;
using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands;

public class UpdateTodoCommand : Notifiable<Notification>, ICommand
{
    public UpdateTodoCommand () { }

    public UpdateTodoCommand(Guid? id
        , string? title
        , string? user)
    {
        Id = id;
        Title = title;
        User = user;
    }

    public Guid? Id { get; set; }

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