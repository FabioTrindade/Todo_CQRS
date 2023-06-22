using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Todo.Domain.Configurations;
using Todo.Domain.Handlers;
using Todo.Domain.Infra.Contexts;
using Todo.Domain.Infra.Repositories;
using Todo.Domain.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// builder.Services.AddDbContext<TodoDataContext>(opt => opt.UseInMemoryDatabase("Database"));
builder.Services.AddDbContext<TodoDataContext>(options
    => options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));

builder.Services.AddTransient<ITodoRepository, TodoRepository>();
builder.Services.AddTransient<TodoHandler, TodoHandler>();

var authenticationSettings = new AuthenticationSettings();
builder.Configuration.GetSection(nameof(AuthenticationSettings)).Bind(authenticationSettings);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => {
        options.Authority = authenticationSettings.Authority;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = authenticationSettings.ValidateIssuer,
            ValidIssuer = authenticationSettings.ValidIssuer,
            ValidateAudience = authenticationSettings.ValidateAudience,
            ValidAudience = authenticationSettings.ValidAudience,
            ValidateLifetime = authenticationSettings.ValidateLifetime
        };
    });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors(c => c
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
