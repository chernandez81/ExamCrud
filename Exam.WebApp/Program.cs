using Exam.Infrastructure.Data;
using Exam.Services;
using Exam.SqlServer;
using Exam.SqlServer.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped<Services>();
builder.Services.AddScoped<ISuscripcionRepository, SuscripcionRepository>();
builder.Services.AddScoped<ISuscriptorRepository, SuscriptorRepository>();
//builder.Services.AddAutoMapper();

//DbContext
builder.Services.AddDbContext<ExamContext>(
        options => options.UseSqlServer(builder.Configuration.GetConnectionString("Sql")), ServiceLifetime.Singleton);



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
