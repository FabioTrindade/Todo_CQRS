using Microsoft.AspNetCore.Mvc;

namespace Todo.Api.Controllers;

public class MainController : Controller
{
    protected string GetCurrentUser
    {
        get => User.Claims.FirstOrDefault(u => u.Type == "user_id").Value;
    }
}