using Microsoft.EntityFrameworkCore;
using SistemaDeContatos.Data;
using SistemaDeContatos.Repositorio;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configuração do banco de dados :)

/*

builder.Services.AddDbContext<BancoContexto>(options => options.UseMySql
("server=localhost;initial catalog=BD_CONTATOS_MVC_ASP;uid=root;pwd=",
    Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.32-mysql")));

Tentar da forma abaixo, caso não dê certo, tentar desse jeito aqui

*/

builder.Services.AddDbContext<BancoContexto>(options => options.UseMySql
(builder.Configuration.GetConnectionString("Database"),
	Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.32-mysql")));

// Injeção de depêndencia da interface - Deixar sem, tá dando erro
 builder.Services.AddScoped<IContatoRepositorio,ContatoRepositorio>();

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
