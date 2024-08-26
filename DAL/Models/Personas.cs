using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Personas
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [MaxLength(50), MinLength(3), Required]
        public string Nombre { get; set; } = "";

        [MaxLength(8), MinLength(7), Required]
        public string Documento { get; set; } = "";

        [MaxLength(50), MinLength(3), Required]
        public string Apellido { get; set; } = "";
        public string Telefono { get; set; } = "";
        public string Direccion { get; set; } = "";
        public string FechaNacimiento { get; set; } = "";

     
    }

    // autoMapper de paguqete nuget

} 

