using Microsoft.EntityFrameworkCore;
using Summary_Application.Data;
using Summary_Application.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IBookService, BookService>();
builder.Services.AddDbContext<BooksDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("BooksSummaryAppConnectionString"));
});

//:CORS
builder.Services.AddCors(options => options.AddPolicy(name:"FrontendUI",
    policy => 
    {
        policy.WithOrigins("https://localhost:44412").AllowAnyMethod().AllowAnyHeader();
    }
));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//CORS
app.UseCors("FrontendUI");
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
