using ArbioFlow.Data;
using ArbioFlow.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using ArbioFlow.Models;
using ArbioFlow.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IPasswordHasher<UtilisateurArbio>, PasswordHasher<UtilisateurArbio>>();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("sage"),
        sql => sql.CommandTimeout(120)));

builder.Services.AddDbContext<ArbioDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("ArbioFlow"),
        sql => sql.CommandTimeout(120)));

builder.Services.AddScoped<PreparationRepo>();
builder.Services.AddScoped<AuthentificationRepo>();
builder.Services.AddScoped<ValiderLigneRepo>();
builder.Services.AddScoped<IPreparation, Preparation>();
builder.Services.AddScoped<IAuthentification, Authentification>();
builder.Services.AddScoped<IValiderLigne, ValiderLigne>();

builder.Services
    .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Home/Login";
        options.LogoutPath = "/Home/Logout";
        options.ExpireTimeSpan = TimeSpan.FromHours(8);
        options.SlidingExpiration = true;
    });

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
    pattern: "{controller=Home}/{action=Login}/{id?}");

app.Run();
