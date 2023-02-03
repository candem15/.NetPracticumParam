using Hafta2.Odev2.DbOperations;
using Hafta2.Odev2.Middlewares;
using Hafta2.Odev2.Services;

var builder = WebApplication.CreateBuilder(args);

// Custom Services here.
ConfigureServices(builder.Services);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Global Exception handler.
app.ConfigureExceptionHandler(app.Services.GetRequiredService<ILogger<Program>>());

//Seeding to BookStoreDb.
BookStoreDbContextSeed.Seed(app.Services);

// Request&Response logging middleware
app.UseHttpLogging();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


void ConfigureServices(IServiceCollection services)
{
    services.AddDbContext<BookStoreDbContext>();
    services.AddScoped<BookService>();
    services.AddScoped<AuthService>();
    services.AddHttpLogging(logging =>
    {
        logging.LoggingFields = Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.All;
    });
}