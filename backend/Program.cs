var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// enable https if the env is production
if (builder.Environment.IsProduction())
{
    // load the environment variables from the .env file
    Env.Load(".env.prod");

    builder
        .WebHost
        .UseKestrel(options =>
        {
            options.ListenAnyIP(
                443,
                listenOptions =>
                {
                    listenOptions.UseHttps(
                        "cert.pfx",
                        Environment.GetEnvironmentVariable("SSL_PASSWORD")
                    );
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
