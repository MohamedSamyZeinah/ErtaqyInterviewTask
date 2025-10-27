using Ertaqy_Task.BLL.Contract;
using Ertaqy_Task.BLL.Manager;
using Ertaqy_Task.DAL.DataAccess;
using Ertaqy_Task.DAL.Repository;
using Ertaqy_Task.DAL.Repository.Generic;
using Ertaqy_Task.DAL.Repository.ProductRepo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Register Db
builder.Services.AddScoped<AppDb>();

//Register Services
builder.Services.AddScoped<IServiceProviderService, ServiceProviderManger>();
builder.Services.AddScoped<IProductService, ProductManager>();

//Register Repos
builder.Services.AddScoped<IServiceProviderRepository, ServiceProviderRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

//Register Generic Repos
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
