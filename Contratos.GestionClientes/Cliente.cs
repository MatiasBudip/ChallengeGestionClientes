using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contratos.GestionClientes
{
    public class Cliente
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "El campo Nombres es obligatorio")]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "El campo Apellidos es obligatorio")]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "El campo CUIT es obligatorio")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "El formato del CUIT no es válido")]
        public string CUIT { get; set; }

        public string Domicilio { get; set; }

        [Required(ErrorMessage = "El campo Teléfono Celular es obligatorio")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "El formato del Teléfono Celular no es válido")]
        public string TelefonoCelular { get; set; }

        [Required(ErrorMessage = "El campo Email es obligatorio")]
        [EmailAddress(ErrorMessage = "El formato del Email no es válido")]
        public string Email { get; set; }

        [DataType(DataType.Date, ErrorMessage = "El formato de la Fecha de Nacimiento no es válido")]
        public DateTime? FechaNacimiento { get; set; }
    }

    public class RespuestaApiClientes
    {
        public string Mensaje { get; set; }
        public List<Cliente> Response { get; set; }
    }
    public class RespuestaApiBusquedaClientes
    {
        public string Mensaje { get; set; }
        public Cliente Response { get; set; }
    }
}
