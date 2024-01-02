var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSession();// for session

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");

    app.UseHsts();// for session
}
app.UseStaticFiles();

app.UseSession();// for session
app.UseHttpsRedirection();// for session

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
      name: "Areas",
      pattern: "{Area:exists}/{controller=Home}/{action=Index}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();
