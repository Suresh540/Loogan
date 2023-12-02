using Loogan.API.BusinessService.Interfaces;
using Loogan.API.BusinessService.Mapper;
using Loogan.API.BusinessService.Services;
using Loogan.API.Database.Interfaces;
using Loogan.API.Database.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(Program), typeof(InitializeMapper));
builder.Services.AddSingleton<ILooganStoredProcedures>((opt) =>
{
    return new LooganStoredProcedures(builder?.Configuration["ConnectionStrings:looganConnectionString"]);
});

builder.Services.AddTransient<IUserService, UserService>();
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
app.UseAuthorization();
app.MapControllers();
app.Run();
