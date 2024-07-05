using OpenAI.ChatGPT.Examples.Web.Interfaces;
using OpenAI.ChatGPT.Examples.Web.Helpers;
using OpenAI_API;

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    builder.Services.AddControllersWithViews();
    builder.Services.AddSingleton<IFileHelper, FileHelper>();

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
        pattern: "{controller=Home}/{action=Index}");

    app.Run();

}
catch (Exception ex)
{
    System.IO.File.WriteAllText("Startup.txt", ex.Message);
    throw;
}
