using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using walk_in_portal_Backend.Models;

var builder = WebApplication.CreateBuilder(args);
// builder.Services.AddMySqlDataSource(builder.Configuration.GetConnectionString("Default")!);


builder.Services.AddEndpointsApiExplorer();

var connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<DbWalkInPortalContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

var app = builder.Build();

// Configure the HTTP request pipeline.


// using var connection = new MySqlConnection(builder.Configuration.GetConnectionString("Default")!);
//
//
// await connection.OpenAsync();
//
// using var command = new MySqlCommand("SELECT * FROM tbl_job_roles;", connection);
// using var reader = await command.ExecuteReaderAsync();
//
// app.MapGet("/demo", async () =>
// {
//     
//     
//     return reader;
// });
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/home/error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.MapGet("/demo", async (DbWalkInPortalContext dbContext) =>
{
    var result = await dbContext.TblJobRoleDetails.ToListAsync();
    return Results.Ok(result);
});

app.Run();

