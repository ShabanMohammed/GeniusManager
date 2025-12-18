using GeniusManager.App.Components;
using Microsoft.EntityFrameworkCore;
using GeniusManager.Persistence.Data;
using GeniusManager.Domain.Contracts.Repositories;
using GeniusManager.Persistence.Repositories;
using GeniusManager.Application.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var provider=builder.Configuration.GetValue<string>("Database:Provider")??"Sqlite";
var connstr=builder.Configuration.GetConnectionString(provider)??"Data Source=GeniusManager.db";
builder.Services.AddDbContext<AppDbContext>(options =>
{
   if(provider=="SqlServer")
       options.UseSqlServer(connstr);
   else
       options.UseSqlite(connstr);
});
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(GenericService<>));
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
