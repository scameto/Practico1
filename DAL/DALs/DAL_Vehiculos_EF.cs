using System;
using DAL.IDALs;
using DAL.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace DAL.DALs
{
    public class DAL_Vehiculos_EF : IDAL_Vehiculos
    { 
        public void AddVehiculo(Vehiculos vehiculo)
        {
            if (vehiculo == null)
            {
                throw new ArgumentNullException(nameof(vehiculo), "El objeto Vehiculo no puede ser nulo.");
            }
            try
            {
                using (var context = new DBContextCore())
            {
                Vehiculos vehiculos = new Vehiculos
                {
                    Marca = vehiculo.Marca?.Trim(),
                    Modelo = vehiculo.Modelo?.Trim(),
                    Matricula = vehiculo.Matricula?.Trim(),
                    PersonaId = vehiculo.PersonaId 
                };

                context.Vehiculos.Add(vehiculos);
                context.SaveChanges();

                vehiculo.Id = vehiculos.Id;
            }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el vehículo", ex);
            }
        }
        
       
        public Vehiculos GetVehiculo(long id) {
            if (id <= 0)
            {
                throw new ArgumentException("El ID debe ser mayor que 0.", nameof(id));
            }

            try
            {
                using (var context = new DBContextCore())
                {
                    var vehiculo = context.Vehiculos.Find(id);
                    if (vehiculo == null)
                    {
                        return null;
                    }

                    return vehiculo;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el vehículo", ex);
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

        public List<Vehiculos> GetVehiculosPorPropietario(long propietarioId) {
            if (propietarioId <= 0)
            {
                throw new ArgumentException("El ID del propietario debe ser mayor que 0.", nameof(propietarioId));
            }

            try
            {
                using (var context = new DBContextCore())
                {
                    var vehiculos = context.Vehiculos
                                           .Where(v => v.PersonaId == propietarioId)
                                           .ToList();

                    if (vehiculos == null || vehiculos.Count == 0)
                    {
                        return new List<Vehiculos>(); // Retornar una lista vacía si no hay vehículos
                    }

                    return vehiculos;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los vehículos por propietario", ex);
            }
        }
    }
}
