using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using GameCatalog.BL;
using GameCatalog.DAL;
using GameCatalog.DAL.EF;

const string adminRole = "ADMIN";
const string userRole = "USER";


var builder = WebApplication.CreateBuilder(args);

Environment.SetEnvironmentVariable("HF_Api_Key", "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");

builder.Services.AddDbContext<GcDbContext>(optionsBuilder => 
    optionsBuilder.UseSqlite("Data Source=GameCatalog.db"));
builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddScoped<IManager, Manager>();
builder.Services.AddControllers();

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
    {
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = true;
        options.Password.RequireDigit = true;
        options.Password.RequiredLength = 8;
    })
    .AddEntityFrameworkStores<GcDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularDev", policy =>
        policy.WithOrigins("http://localhost:4200") // Angular dev server
            .AllowAnyHeader()
            .AllowAnyMethod());
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var ctx = scope.ServiceProvider.GetRequiredService<GcDbContext>();
    if (ctx.CreateDatabase(true)) //!!IMPORTANT: in production false!!
    {
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        IdentitySeeding(userManager, roleManager);
        DataSeeder.Seed(ctx);
    }
}

void IdentitySeeding(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
{
    roleManager.CreateAsync(new IdentityRole(adminRole)).Wait();
    roleManager.CreateAsync(new IdentityRole(userRole)).Wait();

    var admin = new IdentityUser("RobbeVO")
    {
        Email = "van.osselaer.robbe@hotmail.com"
    };
    userManager.CreateAsync(admin, "Robbe371!").Wait();
    userManager.AddToRoleAsync(admin, adminRole).Wait();

    var user = new IdentityUser("AskEfes")
    {
        Email = "filip.slaets@outlook.com"
    };
    userManager.CreateAsync(user, "FilipS196!").Wait();
    userManager.AddToRoleAsync(user, userRole).Wait();
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/error");
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors("AllowAngularDev");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program {}