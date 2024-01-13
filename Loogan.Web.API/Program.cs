using Loogan.API.BusinessService.Interfaces;
using Loogan.API.BusinessService.Mapper;
using Loogan.API.BusinessService.Services;
using Loogan.API.Database.Interfaces;
using Loogan.API.Database.Models;
using Loogan.API.Database.Services;
using Loogan.Common.Utilities;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAutoMapper(typeof(Program), typeof(InitializeMapper));

builder.Services.AddSingleton<ILooganStoredProcedures>((opt) =>
{
    return new LooganStoredProcedures(builder.Configuration);
});

builder.Services.AddSingleton<ILooganCommon>((opt) =>
{
    return new LooganCommonService(builder.Configuration);
});

builder.Services.AddSingleton<ILooganStudentCourse>((opt) =>
{
    return new LooganStudentCourse(builder.Configuration);
});

builder.Services.AddSingleton<ILooganAdmin>((opt) =>
{
    return new LooganAdmin(builder.Configuration);
});

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<ICommonService, CommonService>();
builder.Services.AddTransient<IStudentCourseService, StudentCourseService>();
builder.Services.AddTransient<IAdminService, AdminService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseSerilogRequestLogging();
app.Run();
