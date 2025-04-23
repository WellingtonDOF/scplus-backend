using backend_sc.Configurations;
using backend_sc.DataContext;
using backend_sc.Security;
using backend_sc.Services.AlunoService;
using backend_sc.Services.InstrutorService;
using backend_sc.Services.PessoaService;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    //Configurando rotas para minusculas 
    options.Conventions.Add(new RouteTokenTransformerConvention(new LowercaseControllerRoute()));
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Interfaces/Services
builder.Services.AddScoped<IPessoaInterface, PessoaService>();
builder.Services.AddScoped<IAlunoInterface, AlunoService>();
builder.Services.AddScoped<IInstrutorInterface, InstrutorService>();

//Security
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();


//parte do banco de dados
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection")));
});

//AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

//CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors();

app.MapControllers();


app.Run();
