using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using WeCare_Api.Helper;
using WeCare_Api.Modals;
using WeCare_Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Connection String
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(connectionString));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddTransient<IAppService, AppService>();
builder.Services.AddTransient<IDoctorService, DoctorService>();
builder.Services.AddTransient<IPatientService, PatientService>();
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(option =>
     option.SerializerSettings
     .ReferenceLoopHandling =
     Newtonsoft.Json.ReferenceLoopHandling.Ignore);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidAudience = builder.Configuration["JWT:Audience"],
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:key"]))
    };
});

builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter ‘Bearer’ [space] then your valid token from the login response.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJytfdseesersdttdaDFXDXZWETEESDDX9\"",
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                {
                  new OpenApiSecurityScheme
                   {
                      Reference = new OpenApiReference
                        {
                          Type = ReferenceType.SecurityScheme,
                           Id = "Bearer"
                        }
                   },
                     new string[] {}
                     }
                     });
});

builder.Services.Configure<TokenOption>(builder.Configuration.GetSection("JWT"));
//Identity Role
builder.Services.AddIdentity<ApplicationUsers, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();
var app = builder.Build();
///
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseCors(x => x
          .AllowAnyOrigin()
          .AllowAnyMethod()
          .AllowAnyHeader());
app.MapControllers();

app.Run();
