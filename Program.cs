using Books.Application.Services;   

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers(); //identiifca el controlador 
builder.Services.AddSingleton<BooksService>();



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    
}

app.UseHttpsRedirection();

app.MapControllers(); //las rutas 

app.Run();

