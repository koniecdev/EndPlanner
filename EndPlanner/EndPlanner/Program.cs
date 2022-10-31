using Application.Common.Interfaces;
using EndPlanner;
using EndPlanner.Service;
using Infrastructure;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.OpenApi.Models;
using Persistance;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddPersistance(builder.Configuration);
builder.Services.AddCors(options =>
{
	options.AddPolicy("MyOrigins", policy =>
	{
		policy.WithOrigins("https://localhost:5001").AllowAnyMethod().AllowAnyHeader();
	});
});
builder.Services.AddAuthentication("Bearer").AddJwtBearer("Bearer", options =>
{
	options.Authority = "https://localhost:5001";
	options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
	{
		ValidateAudience = false
	};
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAuthorization(options =>
{
	options.AddPolicy("ApiScope", policy =>
	{
		policy.RequireAuthenticatedUser();
		policy.RequireClaim("scope", "api1");
	});
});
builder.Services.AddSwaggerGen(c =>
{
	c.AddSecurityDefinition("bearer", new OpenApiSecurityScheme
	{
		Type = SecuritySchemeType.OAuth2,

		Flows = new OpenApiOAuthFlows()
		{

			AuthorizationCode = new OpenApiOAuthFlow
			{
				AuthorizationUrl = new Uri("https://localhost:5001/connect/authorize"),
				TokenUrl = new Uri("https://localhost:5001/connect/token"),
				Scopes = new Dictionary<string, string>
				{
					{"api1", "Demo - full access" }
				}
			}
		}
	});
	c.OperationFilter<AuthorizeCheckOperationFilter>();
	c.SwaggerDoc("v1", new OpenApiInfo { Title = "EndTrip API", Version = "v1" });
});
builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped(typeof(ICurrentUserService), typeof(CurrentUserService));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI(c =>
	{
		c.OAuthClientId("swagger");
		c.OAuth2RedirectUrl("https://localhost:7177/swagger/oauth2-redirect.html");
		c.OAuthUsePkce();
	});
}

app.UseHttpsRedirection();
app.UseCors("MyOrigins");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers().RequireAuthorization("ApiScope");

app.Run();
