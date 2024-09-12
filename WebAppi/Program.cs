using DAL;
using DAL.DALs;
using DAL.IDALs;
using BL.BLs;
using BL.IBLs;

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    #region Inyeccion de dependencias

    //Dals
    builder.Services.AddTransient<IDAL_Personas, DAL_Personas_EF>();
    builder.Services.AddTransient<IDAL_Vehiculos, DAL_Vehiculos_EF>();

    //Bls
    builder.Services.AddTransient<IBL_Personas, BL_Personas>();
    builder.Services.AddTransient<IBL_Vehiculos, BL_Vehiculos>();

    #endregion

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    DBContextCore.UpdateDatabase();

    app.Run();
}catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}