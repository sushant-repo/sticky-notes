using Microsoft.EntityFrameworkCore;
using StickyNote.API.Services;
using StickyNote.API.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<StickyNoteDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("StickyNoteDbConnectionString")));

builder.Services.AddScoped<IColourService, ColourService>();
builder.Services.AddScoped<INoteService, NoteService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using(var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<StickyNoteDbContext>();
    DbSeeder.Seed(dbContext);
}

app.Run();
