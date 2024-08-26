﻿using DAL.Models;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IDALs
{
    public interface IDAL_Personas
    {
        List<Persona> GetPersonas();
        Persona GetPersona(long id);
        void AddPersona(Persona persona);
        void DeletePersona(long id);
        void UpdatePersona(Persona persona);
    }
}
