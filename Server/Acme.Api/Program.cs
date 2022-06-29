using Acme.Repositories.Extensions;
using TodoWebSite;
using TodoWebSite.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAcmeApiDependencies(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//const string CorsPolicyName = "AllowAll";
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy(CorsPolicyName,
//        builder =>
//        {
//            builder.AllowAnyHeader();
//            builder.AllowAnyMethod();
//            builder.AllowAnyOrigin();
//        });
//});


var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

#if DEBUG
await app.Services.ApplyMigrationsForAcmeDatabaseAsync();
#endif

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseCors(CorsPolicyName);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
