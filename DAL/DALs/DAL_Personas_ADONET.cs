using DAL.IDALs;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;



namespace DAL.DALs
{
    public class DAL_Personas_ADONET : IDAL_Personas
    {
        private readonly string _connectionString;

        public DAL_Personas_ADONET()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            _connectionString = config.GetConnectionString("DatabaseConnection");
        }
        public void AddPersona(Persona persona)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO Personas (Nombre, Documento) VALUES (@Nombre, @Documento); SELECT SCOPE_IDENTITY();";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Nombre", persona.Nombre);
                cmd.Parameters.AddWithValue("@Documento", persona.Documento);

                con.Open();
                persona.Id = Convert.ToInt32(cmd.ExecuteScalar());
                Console.WriteLine("persona agregada correctamente");
            }
        }

        public void DeletePersona(long id)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM Personas where Id= @Id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", id);

                con.Open();
                cmd.ExecuteNonQuery();

                Console.WriteLine("Persona Eliminada Correctamente");
            }                
        }

        public Persona GetPersona(long id)
        {
            Persona persona = null;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {

                string query = "Select * FROM Personas WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(@query, conn);
                cmd.Parameters.AddWithValue(@"id", id);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                         persona = new Persona()
                        {
                            Id = reader.GetInt64(0),
                            Nombre = reader.GetString(1),
                            Documento = reader.GetString(2)
                        };
                    }
                }
            }
            return persona;
        }

        public List<Persona> GetPersonas()
        {
            List<Persona> personaList = new List<Persona>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {

                string query = "Select * FROM Personas";
                SqlCommand cmd = new SqlCommand(@query, conn);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Persona persona = new Persona()
                        {
                            Id = reader.GetInt64(0),
                            Nombre = reader.GetString(1),
                            Documento = reader.GetString(2)
                        };
                        personaList.Add(persona);
                    }
                }
            }
            return personaList;
        }

        public void UpdatePersona(Persona persona)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {

                string query = "UPDATE Personas SET Nombre = @Nombre, Documento = @Documento  WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", persona.Id);
                cmd.Parameters.AddWithValue("@Nombre", persona.Nombre);
                cmd.Parameters.AddWithValue("@Documento", persona.Documento);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
