using PathfinderCrawlerWebSite.IService;
using PathfinderCrawlerWebSite.IService.Magic;
using PathfinderCrawlerWebSite.Service.Implement;
using PathfinderCrawlerWebSite.Service.Implement.Magic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// 1. Dependency Injection
builder.Services.AddScoped<ICrawlerService, CrawlerService>();
builder.Services.AddScoped<IArcaneSpellsService, ArcaneSpellsService>();
builder.Services.AddScoped<IDivineSpellsService, DivineSpellsService>();
builder.Services.AddScoped<IOccultSpellsService, OccultSpellsService>();
builder.Services.AddScoped<IPrimalSpellsService, PrimalSpellsService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Index");
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
