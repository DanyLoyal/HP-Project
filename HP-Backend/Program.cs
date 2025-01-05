using HP_Backend.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register the DbContext
builder.Services.AddDbContext<XdcCpqContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Tilføj session til at håndtere TempData
builder.Services.AddSession();

// Add Swagger only for development purposes
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddSwaggerGen();
    builder.Services.AddEndpointsApiExplorer();
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Enable HTTPS redirection and static file serving
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Aktiver session før authorization og endpoints
app.UseSession();

app.UseAuthorization();

// Set default routing to load the CustomerController's SelectOrAdd page
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Customer}/{action=SelectOrAdd}/{id?}");

// Run the application
app.Run();
