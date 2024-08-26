using System;
using DAL.IDALs;
using DAL.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL.DALs
{
    public class DAL_Vehiculos_EF : IDAL_Vehiculos
    {
        public void AddVehiculo(Vehiculos vehiculo)
        {
            using (var context = new DBContextCore())
            {
                Vehiculos vehiculos = new Vehiculos
                {
                    Marca = vehiculo.Marca,
                    Modelo = vehiculo.Modelo,
                    Matricula = vehiculo.Matricula,
                    PersonaId = vehiculo.PersonaId 
                };

                context.Vehiculos.Add(vehiculos);
                context.SaveChanges();

                vehiculo.Id = vehiculos.Id;
            }
        }

        public Vehiculos GetVehiculo(long id)
        {
            using (var context = new DBContextCore())
            {
                Vehiculos vehiculos = context.Vehiculos.Find(id);
                if(vehiculos == null)
                {
                    Console.WriteLine("No se ha encontrado el vehiculo");
                }
                Vehiculos vehiculo = new Vehiculos();
                vehiculo.Id = vehiculos.Id;
                vehiculo.Marca = vehiculos.Marca;
                vehiculo.Modelo = vehiculos.Modelo;
                vehiculo.Matricula = vehiculos.Matricula;
                vehiculo.PersonaId = vehiculos.PersonaId;

                return vehiculo;
            }
        }

        public List<Vehiculos> GetVehiculos()
        {
            using (var context = new DBContextCore())
            {
                List<Vehiculos> vehiculos = new List<Vehiculos>();
                foreach (var item in context.Vehiculos)
                {
                    Vehiculos vehiculo = new Vehiculos();
                    vehiculo.Id = item.Id;
                    vehiculo.Marca = item.Marca;
                    vehiculo.Modelo = item.Modelo;
                    vehiculo.Matricula = item.Matricula;
                    vehiculo.PersonaId = item.PersonaId;

                    vehiculos.Add(vehiculo);
                }
                return vehiculos;
            }

        }

        public void RemoveVehiculo(long id)
        {
            using (var context = new DBContextCore())
            {
                Vehiculos vehiculos = context.Vehiculos.Find(id);
                context.Vehiculos.Remove(vehiculos);
                context.SaveChanges();
            }
        }

        public void UpdateVehiculo(Vehiculos vehiculo)
        {
            using (var context = new DBContextCore())
            {
                Vehiculos vehiculos = context.Vehiculos.Find(vehiculo.Id);
                vehiculos.Marca = vehiculo.Marca;
                vehiculos.Modelo = vehiculo.Modelo;
                vehiculos.Matricula = vehiculo.Matricula;
                vehiculos.PersonaId = vehiculo.PersonaId;

                context.SaveChanges();
            }
        }
    }
}
