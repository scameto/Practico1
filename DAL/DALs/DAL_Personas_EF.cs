using DAL.IDALs;
using DAL.Models;
using Microsoft.IdentityModel.Tokens;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL.DALs
{
    public class DAL_Personas_EF : IDAL_Personas
    {
        internal static Personas? FromEntity(Persona p) {
            throw new NotImplementedException();
        }

        public void AddPersona(Persona persona)
        {
            using (var context = new DBContextCore())
            {
                Personas personas = new Personas();
                personas.Nombre = persona.Nombre;
                personas.Documento = persona.Documento;
                personas.Apellido = persona.Apellido;
                personas.Telefono = persona.Telefono;
                personas.Direccion = persona.Direccion;
                personas.FechaNacimiento = persona.FechaNacimiento;
                context.Personas.Add(personas);
                context.SaveChanges();

                persona.Id = personas.Id;
            }
        }

        public void DeletePersona(long id)
        {
            using (var context = new DBContextCore())
            {
                Personas personas = context.Personas.Find((int)id);
                context.Personas.Remove(personas);
                context.SaveChanges();
            }
        }

        public Persona GetPersona(long id)
        {
            using (var context = new DBContextCore())
            {
                Personas personas = context.Personas.Find((int)id);
                Persona persona = new Persona();
                persona.Id = personas.Id;
                persona.Nombre = personas.Nombre;
                persona.Documento = personas.Documento;
                persona.Apellido = personas.Apellido;
                persona.FechaNacimiento = personas.FechaNacimiento;
                persona.Telefono = personas.Telefono;
                persona.Direccion = personas.Direccion;

                return persona;
            }
        }

        public List<Persona> GetPersonas()
        {
            using (var context = new DBContextCore())
            {
                List<Persona> personas = new List<Persona>();
                foreach (var item in context.Personas)
                {
                    Persona persona = new Persona();
                    persona.Id = item.Id;
                    persona.Nombre = item.Nombre;
                    persona.Documento = item.Documento;
                    persona.Apellido = item.Apellido;
                    persona.Telefono = item.Telefono;
                    persona.Direccion = item.Direccion;
                   
                   persona.FechaNacimiento = item.FechaNacimiento;
                 



                    personas.Add(persona);
                }
                return personas;
            }
        }

        public void UpdatePersona(Persona persona)
        {
            using (var context = new DBContextCore())
            {
                Personas personas = context.Personas.Find((int)persona.Id);
                personas.Nombre = persona.Nombre;
                personas.Documento = persona.Documento;
                personas.Apellido = persona.Apellido;
                personas.Telefono = persona.Telefono;
                personas.Direccion = persona.Direccion;
                personas.FechaNacimiento = persona.FechaNacimiento;


                context.SaveChanges();
            }
        }
    }
}
