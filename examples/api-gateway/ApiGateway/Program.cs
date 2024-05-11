using ApiGateway.Configs;
using ApiGateway.Extensions;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using Yarp.ReverseProxy.Swagger;
using Yarp.ReverseProxy.Swagger.Extensions;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddEndpointsApiExplorer();

    var configuration = builder.Configuration.GetSection("ReverseProxy");
    
    builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
    builder.Services.AddSwaggerGen();

    builder.Services
        .AddReverseProxy()
        .LoadFromConfig(configuration)
        .AddSwagger(configuration);
}

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            var config = app.Services.GetRequiredService<IOptionsMonitor<ReverseProxyDocumentFilterConfig>>().CurrentValue;
            options.ConfigureSwaggerEndpoints(config);
        });
    }
    
    app.UseHttpsRedirection();
    
    app.MapReverseProxy();
    app.Run();
}