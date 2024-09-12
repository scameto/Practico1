﻿namespace Shared
{
    public class Persona
    {
        public long Id { get; set; }
        public string Nombre { get; set; } = "-- Sin Nombre --";

        private string documento = "";
        public string Documento
        {
            get
            {
                return documento;
            }
            set
            {
                if (value.Length < 7)
                    throw new Exception("Formato de documento incorrecto.");
                else
                    documento = value.ToUpper();
            }
        }

        public string Direccion { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public DateOnly FechaNacimiento { get; set; } 
        public string GetString()
        {
            return $"Id: {Id}, Documento: {documento}, Nombre: {Nombre}, Apellido: {Apellido}";
        }
    }
}
