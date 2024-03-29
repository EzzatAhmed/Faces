

using Faces.WebMvc.Services;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddMassTransit(cfg =>
{
    cfg.AddBus(provider => Bus.Factory.CreateUsingRabbitMq());
});
builder.Services.AddSingleton(provider => Bus.Factory.CreateUsingRabbitMq(
    cfg => {
        cfg.Host("localhost", "/", h => { });
        builder.Services.AddSingleton<IBusControl>(provider => provider.GetRequiredService<IBusControl>());
        builder.Services.AddSingleton<IHostedService, BusService>();
    }
    ));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
