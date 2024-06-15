using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using si730pc2u202211399.API.Sale.Application.Internal.CommandServices;
using si730pc2u202211399.API.Sale.Domain.Repositories;
using si730pc2u202211399.API.Sale.Domain.Services;
using si730pc2u202211399.API.Sale.Infrastructure.Persistence.EFC.Repositories;
using si730pc2u202211399.API.Shared.Domain.Repositories;
using si730pc2u202211399.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using si730pc2u202211399.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using si730pc2u202211399.API.Shared.Interfaces.ASP.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");


builder.Services.AddDbContext<AppDbContext>(
    options =>
    {
        if (connectionString != null)
            if (builder.Environment.IsDevelopment())
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Information)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors();
            else if (builder.Environment.IsProduction())
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Error)
                    .EnableDetailedErrors();
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Title = "si730pc2u202211399.API",
            Version = "v1",
            Description = "si730pc2u202211399.API",
            TermsOfService = new Uri("https://example.com/terms"),
            Contact = new OpenApiContact
            {
                Name = "si730pc2u202",
                Email = "u202211399@upc.edu.pe" 
            }
        });
    c.EnableAnnotations();
});

builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IPurchaseOrderRepository, PurchaseOrderRepository>();
builder.Services.AddScoped<IPurchaseOrderCommandService, PurchaseOrderCommandService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();