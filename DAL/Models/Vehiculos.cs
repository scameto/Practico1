using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Vehiculos
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long Id { get; set; }

        [MaxLength(50), MinLength(3), Required]
        public string Marca { get; set; }
        
        [MaxLength(50), MinLength(3), Required]
        public string Modelo { get; set; }

        [MaxLength(10), MinLength(3), Required]
        public string Matricula { get; set; }

        [ForeignKey("PersonaId")]
        public int PersonaId { get; set; }
       
    }
}
