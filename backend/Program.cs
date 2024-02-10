
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddCors(policyBuilder =>
    policyBuilder.AddPolicy("AllowAnyOrigin", policy =>
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod())
);

var app = builder.Build();

app.UseCors("AllowAnyOrigin");

// app.UseHttpsRedirection();

// app.UseRouting();

// app.UseAuthentication();
// app.UseAuthorization();

app.MapControllers();

app.Run();
