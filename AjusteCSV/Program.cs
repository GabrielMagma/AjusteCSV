using AjusteCSV.Access.Access;
using AjusteCSV.Access.Data;
using AjusteCSV.Access.DataDev;
using AjusteCSV.Access.DataEep;
using AjusteCSV.Access.Utilities;
using AjusteCSV.BL.Interfaces;
using AjusteCSV.BL.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(options => options.Limits.MaxRequestBodySize = 50 * 1024 * 1024);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost",
        builder => builder
            .WithOrigins("http://127.0.0.1:5500") // Direcci�n de tu frontend
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
builder.Services.AddTransient<IAllAssetServices, AllAssetServices>();
builder.Services.AddTransient<IAllAssetDataAccess, AllAssetDataAccess>();
builder.Services.AddTransient<IAllAssetOracleServices, AllAssetOracleServices>();
builder.Services.AddTransient<IAllAssetOracleDataAccess, AllAssetOracleDataAccess>();
builder.Services.AddTransient<IExcelCSVServices, ExcelCSVServices>();
builder.Services.AddTransient<IFileLACValidationServices, FileLACValidationServices>();
builder.Services.AddTransient<IFileTC1ValidationServices, FileTC1ValidationServices>();
builder.Services.AddTransient<IFileTT2ValidationServices, FileTT2ValidationServices>();
builder.Services.AddTransient<ITokenServices, TokenServices>();
builder.Services.AddTransient<IExcelCSVCompensacionesEEPServices, ExcelCSVCompensacionesEEPServices>();
builder.Services.AddTransient<IExcelCSVCompensacionesESSAServices, ExcelCSVCompensacionesESSAServices>();
builder.Services.AddTransient<IRayosCSVServices, RayosCSVServices>();
builder.Services.AddTransient<IRayosCSVDataAccess, RayosCSVDataAccess>();
builder.Services.AddTransient<IRamalesServices, RamalesServices>();
builder.Services.AddTransient<IRamalesDataAccess, RamalesDataAccess>();

builder.Services.AddDbContext<DannteEssaTestingContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PgDbConnection")));

builder.Services.AddDbContext<DannteEepTestingContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PgDbEepConnection")));

builder.Services.AddDbContext<DannteDevelopmentContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PgDbDevConnection")));

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "AjusteCSV v1", Version = "v1" });
    var filePath = Path.Combine(System.AppContext.BaseDirectory, "AjusteCSV.xml");
    c.IncludeXmlComments(filePath);
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Insert Token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[]{}
        }
    });
});

//jwt
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = false,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("JWT:Key").Value)),
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true
        };
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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
