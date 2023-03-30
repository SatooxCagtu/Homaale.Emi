using Homaale.Emi.Api.DependencyInjection;
using Homaale.Emi.Api.Emi;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddHomaaleServices();
}

var app = builder.Build();
{
    app.UseSwagger();
    app.UseSwaggerUI(c => {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Homaale Emi API v1");
        c.RoutePrefix= String.Empty;
    });
    app.UseHttpsRedirection();
    app.UseCors(Common.CorsPolicyName);
    app.MapControllers();
    app.Run();
}


