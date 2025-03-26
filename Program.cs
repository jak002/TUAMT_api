using TUAMT_api.Backend;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IMeasureRepo>(new MeasureDB());

builder.Services.AddCors(opt => opt.AddPolicy("AllowGet",
    builder => builder.AllowAnyOrigin().AllowAnyHeader().WithMethods("GET")));

var app = builder.Build();

// Configure the HTTP request pipeline.
    app.UseSwagger();
    app.UseSwaggerUI();

//app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors("AllowGet");

app.MapControllers();

app.Run();
