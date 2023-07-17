using AddressBook.Application;
using AddressBook.Domain;
using AddressBook.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IContactService, ContactService>();
builder.Services.AddScoped<IRepository<Contact>, ContactMsSqlRepository>();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddCors(c =>  
{  
    c.AddPolicy("CorsPolicy", options =>
    {
        options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });  
});

builder.Services.AddDbContext<AddressBookDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("AddressBookDb")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<DataSeeder>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var serviceScope = app.Services.GetService<IServiceScopeFactory>().CreateScope())
{
    var context = serviceScope.ServiceProvider.GetRequiredService<AddressBookDbContext>();
    context.Database.Migrate();

    var service = serviceScope.ServiceProvider.GetService<DataSeeder>();
    service.Seed();
}

app.Run();