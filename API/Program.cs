using System.Text;
using API.Data;
using API.Extensions;
using API.Interface;
using API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    //builder.Services.AddEndpointsApiExplorer();
    //builder.Services.AddSwaggerGen();
    builder.Services.AddApplicationService(builder.Configuration);
    builder.Services.AddIdentityServices(builder.Configuration);
    var app = builder.Build();



      // Configure the HTTP request pipeline.
      app.UseCors(builder=>builder.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200"));
      //if (app.Environment.IsDevelopment())
      //{
        //  app.UseSwagger();
        // app.UseSwaggerUI();
      //}

      //app.UseHttpsRedirection();

      //app.UseAuthorization();

      app.UseAuthentication();
      app.UseAuthorization();

      app.MapControllers();

      app.Run();
