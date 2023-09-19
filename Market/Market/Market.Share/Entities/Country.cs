using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Share.Entities
{
    public class Country
    {
        public int Id { get; set; } // primary key, identity (1,1)

        [Display (Name = "Pais")] // Etiquetas del nombre del campo
        [MaxLength (100, ErrorMessage = "El campo {0} debe contener {1}")] // es la longitud de caracteres del campo o del atributo
        // se puede personalizar el mensaje
        [Required (ErrorMessage = "El campo {0} es obligatorio")]
        public string? Name { get; set; } // ? (indica que hace un salto de nulos)

        
        
    }
}
