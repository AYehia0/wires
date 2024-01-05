var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// enable https if the env is production
if (builder.Environment.IsProduction())
{
    // enable https
    builder
        .WebHost
        .UseKestrel(options =>
        {
            options.ListenAnyIP(
                443,
                listenOptions =>
                {
                    // TODO: use env variables
                    listenOptions.UseHttps("cert.pfx", "password");
                }
            );
        });
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapGet("/hello", Helloworld.func).WithName("hello").WithOpenApi();

app.Run();
