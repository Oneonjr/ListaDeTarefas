using ListaDeTarefas.Data;
using ListaDeTarefas.Helper;
using ListaDeTarefas.Repositorio;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;
using Repositorio;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionStringMysql = builder.Configuration.GetConnectionString("ConexaoPadrao");
builder.Services.AddDbContext<BancoContext>(options => 
    options.UseMySql(connectionStringMysql,ServerVersion.Parse("8.0.31 MySQL"))); //utilizando MySql

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<ItarefaRepositorio, TarefaRepositorio>();
builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
builder.Services.AddScoped<ISessao, Sessao>();

builder.Services.AddSession(o => 
{
    o.Cookie.HttpOnly = true;
    o.Cookie.IsEssential = true;
});

builder.Services.AddControllersWithViews();

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

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
