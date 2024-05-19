using CleanArchMvc.Domain.Account;
using CleanArchMvc.Infra.Data.IdentityContext;
using CleanArchMvc.Infra.IoC;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddInfraestrutura("Server=DESKTOP-NDSKUV4;Initial Catalog=CleanArchMvc;Integrated Security=True;TrustServerCertificate=True;");
// Add services to the container.
builder.Services.AddControllersWithViews();

// Registre a classe SeedUserRoleInitial
builder.Services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var seedUserRoleInitial = services.GetRequiredService<ISeedUserRoleInitial>();
    seedUserRoleInitial.SeedRoles();
    seedUserRoleInitial.SeedUsers();
}

app.Run();
