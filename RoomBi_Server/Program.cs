using RoomBi.BLL.Infrastructure;
using RoomBi.DAL.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using MySqlConnector;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;


var builder = WebApplication.CreateBuilder(args);

MySqlConnection connection = new(builder.Configuration.GetConnectionString("DefaultConnection"));//DefaultConnection- назва рядка підключення в файлі azuresettings.json 

builder.Services.AddDbContext<RBContext>(options => options.UseMySql(connection, ServerVersion.AutoDetect(connection),
serverOptions => serverOptions
.MigrationsHistoryTable(tableName: HistoryRepository.DefaultTableName, schema: RBContext.SchemaName)
.SchemaBehavior(MySqlSchemaBehavior.Ignore, (schema, table) => $"{schema}_{table}")));


builder.Services.AddCors(); // добавляем сервисы CORS


builder.Services.AddCustomServices();
builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//app.UseCors(builder => builder
//.WithOrigins("http://localhost:3000", "https://room-bi.vercel.app")
//.AllowAnyHeader()
//.AllowAnyMethod()
//.AllowCredentials());
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();