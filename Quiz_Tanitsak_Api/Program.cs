using log4net.Config;
using log4net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quiz_Tanitsak_Api;
using Quiz_Tanitsak_Api.Business;
using Quiz_Tanitsak_Api.Helper;
using Quiz_Tanitsak_Api.Interface;
using Quiz_Tanitsak_Api.Models.Entity;
using System.Reflection;
using Quiz_Tanit_API.Models.Database;

var builder = WebApplication.CreateBuilder(args);

var configurationBuilder = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddXmlFile("appsettings.xml", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables()
            .AddCommandLine(args);
// Add services to the container.
IConfiguration configuration = configurationBuilder.Build();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.IncludeXmlComments(XmlCommentsFilePath.XmlCommentsFilePathx);
});


builder.Services.AddRazorPages();
builder.Services.AddCors();
builder.Services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);
builder.Services.AddDbContext<DBQuizTanitsakContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString(Const.CONNECTION_STRING_DB)));

builder.Services.AddScoped<IHelper, Helper>();
builder.Services.AddScoped<IImformationUser, ImformationUserBC>();
builder.Services.AddScoped<ILoggerInfo, LoggerInfo>();


var app = builder.Build();

var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Quiz Tanitsak API v1");
    });
}
else
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("./v1/swagger.json", "Quiz Tanitsak API v1"));
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapDefaultControllerRoute();
});
app.MapControllers();
app.UseCookiePolicy();

app.Run();