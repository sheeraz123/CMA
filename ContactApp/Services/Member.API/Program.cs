using Member.API.ExtensionMethod;
using Member.API.Middlewares.GolbalExceptionMiddleware;

var builder = WebApplication.CreateBuilder(args);

// AddAsync services to the container.
builder.Services.AddAPIServiceRegistration();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Member API");

    });
}

app.UseHttpsRedirection();
app.UseCors(x => x
		   .AllowAnyOrigin()
		   .AllowAnyMethod()
		   .AllowAnyHeader());
app.UseAuthorization();

app.MapControllers();
app.UseExceptionHandlerMiddleware();
app.Run();
