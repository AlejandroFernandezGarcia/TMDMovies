using System.Reflection;
using TMDMovies.API;
using TMDMovies.Commons;
using TMDMovies.Commons.Helpers;
using TMDMovies.ExternalServices.GetExternalMovies;
using TMDMovies.ExternalServices.GetExternalRelatedMovies;
using TMDMovies.Services.GetMovies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddRouting(options => options.LowercaseUrls = true);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Configuration
builder.Services.AddOptions();
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

//DI
builder.Services.AddScoped<IService<GetMoviesByNameQuery, GetMoviesByNameResult>, GetMoviesByNameService>();
builder.Services.AddScoped<IService<GetExternalMoviesByNameQuery, GetExternalMoviesByNameResult>, GetExternalMoviesByNameService>();
builder.Services.AddScoped<IService<GetExternalRelatedMoviesQuery, GetExternalRelatedMoviesResult>, GetExternalRelatedMoviesService>();
builder.Services.AddScoped<IHttpClientHelper, HttpClientHelper>();   

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddExceptionHandler<GlobalExceptionHandler> ();

var app = builder.Build();

app.UseExceptionHandler(opt => { });

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
