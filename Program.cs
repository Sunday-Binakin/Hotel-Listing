using HotelListing.Configurations;
using HotelListing.Data;
using HotelListing.Repository.Implementation;
using HotelListing.Repository.Interface;
using HotelListing.ServiceExtensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("D:\\C#\\Backend\\HotelListing\\logs\\log-.txt", 
       // outputTemplate:$"{{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz}} [{Level:u3}] {Message:lj}{NewLine}{typeof(Exception)}",
        outputTemplate:$"[{{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz}} {{Level:u3}}] {{Message:lj}}{{NewLine}}{{Exception}} ",
        rollingInterval: RollingInterval.Day,
        restrictedToMinimumLevel:LogEventLevel.Information)
    .CreateLogger();
try
{
    Log.Information("Application is Starting..... ");
    builder = WebApplication.CreateBuilder(args);
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application failed to Start");
}
finally
{
    Log.CloseAndFlush();
}
//var builder = WebApplication.CreateBuilder(args);
   // .UseSerilog();

// Add services to the container.
builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("sqlConnection")));
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

builder.Services.AddAuthentication();
builder.Services.ConfigureIdentity();
builder.Services.AddCors(cors =>
{
    
    cors.AddPolicy("AllowAllPolicy",
        corsPolicyBuilder=>corsPolicyBuilder
            .AllowAnyOrigin()
        .AllowAnyMethod().AllowAnyHeader());
});
builder.Services.AddAutoMapper(typeof(MapperInitializer));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


// Configure the HTTP request pipeline.
if ( app.Environment.IsDevelopment())
{
   
}
app.UseSwagger(); 
app.UseSwaggerUI(c=>c.SwaggerEndpoint("/swagger/v1/swagger.json","HotelLisiting v1"));
app.UseHttpsRedirection();
app.UseCors("AllowAllPolicy");
app.UseAuthorization();

app.MapControllers();

app.Run();