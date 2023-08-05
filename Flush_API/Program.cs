using AutoMapper;
using Flush_API.Data;
using Flush_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection")));

builder.Services.AddScoped<IIngredientRepo,  IngredientRepo>();
builder.Services.AddScoped<IIbsCountRepo, IbsCountRepo>();
builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddHttpClient();


//app.UseHttpsRedirection();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))

        };
    });
{ 
}
builder.Services.AddAuthorization();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();



//GET
app.MapGet("api/ibs_count", async (AppDbContext context) =>
{

    return Results.Ok(await context.IbsCount.Where(b => b.Count >= 1).ToListAsync());
});

//POST
app.MapPost("api/ibs_count", async (AppDbContext context, IbsCount ibsCount) =>
{
    await context.IbsCount.AddAsync(ibsCount);
    await context.SaveChangesAsync();

    return Results.Created($"api/ibs_count/{ibsCount.Id}", ibsCount);
});

//UPDATE
app.MapPut("api/ibs_count/{id}", async (AppDbContext context, int id, IbsCount ibsCount) =>
{
    var ibsModel = await context.IbsCount.FirstOrDefaultAsync(x => x.Id == id);

    if (ibsModel == null)
    {
        return Results.NotFound();
    }

    ibsModel.Count = ibsCount.Count;
    await context.SaveChangesAsync();

    return Results.NoContent();

});

//DELETE
app.MapDelete("api/ibs_count/{id}", async (AppDbContext context, int id) =>
{
    var ibsModel = await context.IbsCount.FirstOrDefaultAsync(x => x.Id == id);

    if (ibsModel == null)
    {
        return Results.NotFound();
    }

    context.IbsCount.Remove(ibsModel);

    await context.SaveChangesAsync();

    return Results.NoContent();
});

app.Run();
