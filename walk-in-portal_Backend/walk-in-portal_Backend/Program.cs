using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using walk_in_portal_Backend.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//For connecting database
var connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<DbWalkInPortalContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// for allowing all incoming requests to this web api even from frontend.

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



// to use cors.
app.UseCors();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

// app.MapGet("/demo", async (DbWalkInPortalContext dbContext) =>
// {
//     var result = await dbContext.TblJobRoleDetails.ToListAsync();
//     return result;
// });



app.Run();

