using GastroAPI.Models;
using GastroAPI.Repositories;
using GastroAPI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// luodaan tietokantakonteksti, k‰ytet‰‰n sqlserveri‰ ja k‰ytet‰‰n gastroDB:t‰ (appsettingssiss‰)
builder.Services.AddDbContext<GastroBarContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("GastroBarDB")));

// Add services to the container.
builder.Services.AddScoped<IItemService, ItemService>();
builder.Services.AddScoped<IItemRepository, ItemRepository>();
builder.Services.AddScoped<IBasketService, BasketService>();
builder.Services.AddScoped<IBasketRepository, BasketRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "GastroBarSystem API",
        Description = "An ASP.NET Core Web API for managing items/orders/tables",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Example Contact",
            Url = new Uri("https://example.com/contact")
        },
        License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://example.com/license")
        }
    });
    // katsotaan ..portti/swagger tai ..portti/swagger.json

    // halutaan laittaa controllereihin xml kommentteja ett‰ mit‰ tietyt funktiot tekee (kommentit sitten lis‰t‰‰n controlleriin \\\)
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});
// frontendia varten
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod();
        });
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// luo tietokannan jos sita ei ole jo olemassa
using (var scope = app.Services.CreateScope())
{
    GastroBarContext dbcontext = scope.ServiceProvider.GetRequiredService<GastroBarContext>();
    dbcontext.Database.EnsureCreated();

}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
