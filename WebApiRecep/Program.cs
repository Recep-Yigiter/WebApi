using WebApiRecep.Data;
using WebApiRecep.GenericRepositories.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();





builder.Services.AddDbContext<MaliyetDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});





var MyAllowSpecificOrigins = "AllowOrigin";

builder.Services.AddCors(x =>
{
    x.AddPolicy(name: MyAllowSpecificOrigins, options => options.WithOrigins("http://localhost:4200"));
});

builder.Services.AddScoped<EfCoreAlisTipiRepository>();

builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
 
}
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();


app.UseAuthorization();

app.MapControllers();

app.UseCors(bldr => bldr
   .WithOrigins("http://localhost:4200")
   .AllowAnyMethod()
   .AllowAnyHeader()
);

app.Run();
