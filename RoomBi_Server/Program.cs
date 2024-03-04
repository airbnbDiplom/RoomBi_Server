using RoomBi.BLL.Infrastructure;
using RoomBi.DAL.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using MySqlConnector;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using RoomBi.BLL.Services;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using RoomBi.BLL.DTO;
using RoomBi_Server.Token;


var builder = WebApplication.CreateBuilder(args);

MySqlConnection connection = new(builder.Configuration.GetConnectionString("DefaultConnection"));//DefaultConnection- назва рядка підключення в файлі azuresettings.json 

builder.Services.AddDbContext<RBContext>(options =>
    options.UseMySql(connection,
                     ServerVersion.AutoDetect(connection),
                     serverOptions => serverOptions
                        .MaxBatchSize(50) // Устанавливаем максимальное количество соединений
                        .MigrationsHistoryTable(tableName: HistoryRepository.DefaultTableName, schema: RBContext.SchemaName)
                        .SchemaBehavior(MySqlSchemaBehavior.Ignore, (schema, table) => $"{schema}_{table}")));



builder.Services.AddCors(); // добавляем сервисы CORS

builder.Services.AddScoped<IJwtToken, JwtTokenService>();
builder.Services.AddCustomServices();


builder.Configuration.AddJsonFile("appsettings.json", false);
var secretKey = builder.Configuration.GetSection("Jwt:Secret").Value;
var issuer = builder.Configuration.GetSection("Jwt:Issuer").Value;
var audience = builder.Configuration.GetSection("Jwt:Audience").Value;
var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

builder.Services.AddAuthentication(opt => {
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidIssuer = issuer,
        ValidateAudience = false,
        ValidAudience = audience,
        ValidateLifetime = true,
        IssuerSigningKey = signingKey,
        ValidateIssuerSigningKey = true,
        ClockSkew = TimeSpan.Zero


    };
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

 

 
 
builder.Services.AddSwaggerGen();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

//app.UseCors(builder => builder
//.WithOrigins("http://localhost:3000", "https://room-bi.vercel.app")
//.AllowAnyHeader()
//.AllowAnyMethod()
//.AllowCredentials());
app.UseCors(builder => builder.WithOrigins("http://localhost:3000", "https://room-bi.vercel.app")
                            .AllowAnyHeader()
                            .AllowAnyMethod());

//app.UseCors();
//app.UseCors(MyAllowSpecificOrigins);
app.MapControllers();

app.Run();