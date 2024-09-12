using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IDALs
{
    public interface IDAL_Vehiculos
    {
        List<Vehiculos> GetVehiculos();

        Vehiculos GetVehiculo(long id);

        void AddVehiculo(Vehiculos vehiculo);

        void RemoveVehiculo(long id);

        void UpdateVehiculo(Vehiculos vehiculo);

        List<Vehiculos> GetVehiculosPorPropietario(long id);
    }
}
