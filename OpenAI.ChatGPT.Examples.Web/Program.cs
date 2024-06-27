using OpenAI.ChatGPT.Examples.Web.Interfaces;
using OpenAI.ChatGPT.Examples.Web.Helpers;
using OpenAI_API;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IOpenAIHelper, OpenAIHelper>(); // Added DI so classes can be tested
builder.Services.AddSingleton<IFileHelper, FileHelper>();
builder.Services.AddSingleton<IOpenAIAPI, OpenAIAPI>();

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

app.MapControllerRoute(
    name: "naturalLanguageTranslator",
    pattern: "{controller=NaturalLanguageTranslator}/{action=Index}");

app.MapControllerRoute(
    name: "codeExplainer",
    pattern: "{controller=CodeExplainer}/{action=Index}");

app.MapControllerRoute(
    name: "jobCoverLetter",
    pattern: "{controller=JobCoverLetter}/{action=Index}");

app.MapControllerRoute(
    name: "languageToSQL",
    pattern: "{controller=LanguageToSQL}/{action=Index}");

app.Run();
