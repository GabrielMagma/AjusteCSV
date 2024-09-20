using AjusteCSV.Access.Access;
using AjusteCSV.Access.Data;
using AjusteCSV.Access.Utilities;
using AjusteCSV.BL.Interfaces;
using AjusteCSV.BL.Services;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost",
        builder => builder
            .WithOrigins("http://127.0.0.1:5500") // Dirección de tu frontend
            .AllowAnyMethod()
            .AllowAnyHeader());
});

var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new GlobalMapper());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddTransient<IFileServices, FileServices>();
builder.Services.AddTransient<IFileDataAccess, FileDataAccess>();

builder.Services.AddDbContext<DannteEssaContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PgDbConnection")));

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "AjusteCSV v1", Version = "v1" });
    var filePath = Path.Combine(System.AppContext.BaseDirectory, "AjusteCSV.xml");
    c.IncludeXmlComments(filePath);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    //app.UseExceptionHandler("/Home/Error");
    //// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    //app.UseHsts();
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AjusteCSV v1"));
}

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AjusteCSV v1"));
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseCors("AllowLocalhost");

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
