using Summary_Application.Data.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IBookService, BookService>();

//:CORS
builder.Services.AddCors(options => options.AddPolicy(name:"FrontendUI",
    policy => 
    {
        policy.WithOrigins("https://localhost:44412").AllowAnyMethod().AllowAnyHeader();
    }
));
//:CORS

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
//CORS
app.UseCors("FrontendUI");
//

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
