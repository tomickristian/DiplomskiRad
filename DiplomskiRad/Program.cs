using AutoMapper;
using DiplomskiRad.DapperRepository;
using DiplomskiRad.EFCRepository;
using DiplomskiRad.Validation;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);
builder.Services.AddSingleton(provider => provider.GetRequiredService<IMapper>().ConfigurationProvider);
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped(typeof(IDapperRepository<>), typeof(DapperRepository<>));
builder.Services.AddScoped(typeof(IEFCRepository<>), typeof(EFCRepository<>));
builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
builder.Services.AddDbContext<TvProgramContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("TVPROGRAM"));
});

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
