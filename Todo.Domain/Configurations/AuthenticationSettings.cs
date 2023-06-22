namespace Todo.Domain.Configurations;

public class AuthenticationSettings
{
    public string? Authority { get; set; }

    public bool ValidateIssuer { get; set; }

    public string? ValidIssuer { get; set; }

    public bool ValidateAudience { get; set; }

    public string? ValidAudience { get; set; }

    public bool ValidateLifetime { get; set; }
}