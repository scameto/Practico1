using DAL.DALs;
using DAL.IDALs;
using DAL.Models;
using Microsoft.VisualBasic.FileIO;
using Shared;
using AutoMapper;
using DAL.Mappings;

//IDAL_Personas dal = new DAL_Personas_Mock();
//IDAL_Personas dal = new DAL_Personas_ADONET();
IDAL_Personas dal = new DAL_Personas_EF();
IDAL_Vehiculos dalVehiculos = new DAL_Vehiculos_EF();

// Inicializando AutoMapper
var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
var mapper = config.CreateMapper();

string comando = "NUEVA";

Console.WriteLine("Bienvenido a mi primera app .NET!!!");

do
{
    Console.WriteLine("Ingrese comando (NUEVA/IMPRIMIR/BUSCAR/UPDATE/DELETE/EXIT): ");
    Console.WriteLine("Ingrese comando Vehiculos \n" +
        "              1 - NUEVA \n" +
        "              2 - IMPRIMIR \n" +
        "              3 - BUSCAR \n" +
        "              4 - UPDATE \n" +
        "              5 - DELETE \n" +
        "              6 - EXIT \n");

    try
    {
        comando = Console.ReadLine().ToUpper();

        switch (comando)
        {
            case "NUEVA":

                Persona persona = new Persona();
                Console.WriteLine("Ingrese el nombre de la persona: ");
                persona.Nombre = Console.ReadLine();
                Console.WriteLine("Ingrese el documento de la persona: ");
                persona.Documento = Console.ReadLine();
                dal.AddPersona(persona);
                break;
           


            case "IMPRIMIR":

                Console.WriteLine("Ingrese Nombre o Documento:");
                string filtro = Console.ReadLine();

                List<Persona> filtradas = 
                    dal.GetPersonas().Where(p => p.Nombre.Contains(filtro) || p.Documento.Contains(filtro))
                            .OrderBy(p => p.Nombre)
                            .ToList();

                foreach (Persona p in filtradas)
                    Console.WriteLine(p.GetString());
                break;

            case "UPDATE":

                Console.WriteLine("Ingrese el ID de la persona a actualizar: ");
                long id = Convert.ToInt64(Console.ReadLine());  

                Persona actualizar = dal.GetPersona(id);

                if (actualizar != null)
                {
                    Console.WriteLine($"Persona encontrada: {actualizar.GetString()}");

                    Console.WriteLine("Ingrese nuevo nombre o presione enter para seguir");
                    string nuevoNombre = Console.ReadLine();
                    if (!string.IsNullOrEmpty(nuevoNombre))
                    {
                        actualizar.Nombre = nuevoNombre;
                    }
                    Console.WriteLine("Ingrese nuevo documento o enter para seguir");
                    string nuevoDocumento = Console.ReadLine();
                    if (!string.IsNullOrEmpty(nuevoDocumento))
                    {
                        actualizar.Documento = nuevoDocumento;
                    }
                    dal.UpdatePersona(actualizar);
                    Console.WriteLine("actualizada exitosamente");
                }
                else
                {
                    Console.WriteLine("Persona no encontrada");
                }
                break; 
                
            case "BUSCAR":
                Console.WriteLine("Ingrese el ID de la persona a buscar: ");
                long id3 = Convert.ToInt64(Console.ReadLine());

                Persona buscar = dal.GetPersona(id3);

                if (buscar != null)
                {
                    Console.WriteLine($"Persona encontrada: \n {buscar.GetString()}");
                }
                else
                {
                    Console.WriteLine("Persona no encontrada");
                }
                break;

            case "DELETE":

                Console.WriteLine("Ingrese Id para Deletear: ");
                long id2 = Convert.ToInt64(Console.ReadLine()) ;

                Persona aEliminar = dal.GetPersona(id2);

                if(aEliminar != null)
                {
                    dal.DeletePersona(id2);
                }

                else
                {
                    Console.WriteLine("Persona no encontrada");
                }
                break ;

            case "EXIT":
                break;

            case "1":
                try
                {
                    Vehiculos vehiculo = new Vehiculos();

                    Console.WriteLine("Ingrese la marca del vehiculo: ");
                    vehiculo.Marca = Console.ReadLine();

                    Console.WriteLine("Ingrese el modelo del vehiculo: ");
                    vehiculo.Modelo = Console.ReadLine();

                    Console.WriteLine("Ingrese la matricula del vehiculo: ");
                    vehiculo.Matricula = Console.ReadLine();

                    Console.WriteLine("Ingrese el id de la persona: ");
                    long idPersona = Convert.ToInt64(Console.ReadLine());

                    // Aquí estás buscando la persona en la base de datos antes de asignarla
                    Persona persona1 = dal.GetPersona(idPersona);

                    if (persona1 != null)
                    {
                        // Mapea la clase Persona (de Shared) a Personas (de DAL.Models)
                        var personasEntity = mapper.Map<Personas>(persona1);

                        //vehiculo.persona = null;
                        vehiculo.PersonaId = personasEntity.Id;

                        dalVehiculos.AddVehiculo(vehiculo);
                        Console.WriteLine("Vehículo agregado exitosamente.");
                    }
                    else
                    {
                        Console.WriteLine("Persona no encontrada. No se pudo agregar el vehículo.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    if (ex.InnerException != null)
                    {
                        Console.WriteLine("Inner Exception: " + ex.InnerException.Message);
                    }
                }
                break;

            case "2":
                Console.WriteLine("\n");

                List<Vehiculos> vehiculos = dalVehiculos.GetVehiculos();
                Console.WriteLine("Id".PadRight(5) + "Marca".PadRight(15) + "Modelo".PadRight(15) + "Matrícula".PadRight(15) + "Propietario");

                foreach (Vehiculos v in vehiculos)
                {
                    Persona p = dal.GetPersona(v.PersonaId);
                    Console.WriteLine(v.Id.ToString().PadRight(5) + v.Marca.PadRight(15) + v.Modelo.PadRight(15) + v.Matricula.PadRight(15) + p.Nombre);
                }
                Console.WriteLine("\n");
                break;

            case "3":
                Console.WriteLine("\n");

                Console.WriteLine("Ingrese el ID del vehículo a buscar: ");
                long idVehiculo = Convert.ToInt64(Console.ReadLine());

                Vehiculos vehiculoEncontrado = dalVehiculos.GetVehiculo(idVehiculo);

                if (vehiculoEncontrado != null)
                {
                    Persona p = dal.GetPersona(vehiculoEncontrado.PersonaId);
                    Console.WriteLine("Id".PadRight(5) + "Marca".PadRight(15) + "Modelo".PadRight(15) + "Matrícula".PadRight(15) + "Propietario");
                    Console.WriteLine(vehiculoEncontrado.Id.ToString().PadRight(5) + vehiculoEncontrado.Marca.PadRight(15) + vehiculoEncontrado.Modelo.PadRight(15) + vehiculoEncontrado.Matricula.PadRight(15) + p.Nombre);
                }
                else
                {
                    Console.WriteLine("Vehículo no encontrado.");
                }

                Console.WriteLine("\n");
                break;

            case "4":
                Console.WriteLine("\n");

                Console.WriteLine("Ingrese el ID del vehículo a actualizar: ");
                long idVehiculoActualizar = Convert.ToInt64(Console.ReadLine());

                Vehiculos vehiculoActualizar = dalVehiculos.GetVehiculo(idVehiculoActualizar);

                if (vehiculoActualizar != null)
                {
                    Console.WriteLine($"Vehículo encontrado: \n Id: {vehiculoActualizar.Id} \n Marca: {vehiculoActualizar.Marca} \n Modelo: {vehiculoActualizar.Modelo} \n Matrícula: {vehiculoActualizar.Matricula}");

                    Console.WriteLine("Ingrese nueva marca o presione enter para seguir");
                    string nuevaMarca = Console.ReadLine();
                    if (!string.IsNullOrEmpty(nuevaMarca))
                    {
                        vehiculoActualizar.Marca = nuevaMarca;
                    }

                    Console.WriteLine("Ingrese nuevo modelo o presione enter para seguir");
                    string nuevoModelo = Console.ReadLine();
                    if (!string.IsNullOrEmpty(nuevoModelo))
                    {
                        vehiculoActualizar.Modelo = nuevoModelo;
                    }

                    Console.WriteLine("Ingrese nueva matrícula o presione enter para seguir");
                    string nuevaMatricula = Console.ReadLine();
                    if (!string.IsNullOrEmpty(nuevaMatricula))
                    {
                        vehiculoActualizar.Matricula = nuevaMatricula;
                    }

                    Console.WriteLine("Ingrese el id de la persona o presione enter para seguir");
                    string idPersonaString = Console.ReadLine();
                    if (!string.IsNullOrEmpty(idPersonaString))
                    {
                        int idPersonaActualizar = Convert.ToInt32(idPersonaString);
                        vehiculoActualizar.PersonaId = idPersonaActualizar;
                    }

                    dalVehiculos.UpdateVehiculo(vehiculoActualizar);
                    Console.WriteLine("Vehículo actualizado exitosamente.");
                }
                else
                {
                    Console.WriteLine("Vehículo no encontrado.");
                }

                Console.WriteLine("\n");
                break;

            case "5":
                Console.WriteLine("\n");

                Console.WriteLine("Ingrese el ID del vehículo a eliminar: ");
                long idVehiculoEliminar = Convert.ToInt64(Console.ReadLine());

                Vehiculos vehiculoEliminar = dalVehiculos.GetVehiculo(idVehiculoEliminar);

                if (vehiculoEliminar != null)
                {
                    dalVehiculos.RemoveVehiculo(idVehiculoEliminar);
                    Console.WriteLine("Vehículo eliminado exitosamente.");
                }
                else
                {
                    Console.WriteLine("Vehículo no encontrado.");
                }

                Console.WriteLine("\n");
                break;

           case "6":
                break;

            default:
                Console.WriteLine("Comando no reconocido.");
                break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}
while (comando != "EXIT" );

Console.WriteLine("Hasta luego!!!");
Console.ReadLine();
