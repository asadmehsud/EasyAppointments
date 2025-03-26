using EasyAppointments.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddServices();
builder.Services.AddCustomSwagger();
builder.Configuration.GetConfigurations();
builder.Services.AddConnections(builder.Configuration);
builder.Services.AddCors(options=>
{
    options.AddPolicy("AllowRazorUI",policy =>
    {
        policy.WithOrigins("https://localhost:7217")
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials();
    });
});
builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.MinimumSameSitePolicy = SameSiteMode.None;
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.AddMiddlewares();
app.Run();
