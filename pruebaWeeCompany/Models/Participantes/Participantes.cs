using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace pruebaWeeCompany.Models
{
    //Se pueden agregar validaciones a como se requiera 
    public class Participantes
    {
        [Required(ErrorMessage = "El campo compañia es requerido.")]
        [StringLength(80, ErrorMessage = "El campo compañia debe tener como máximo 80 caracteres.")]
        public string InputNombreCompania { get; set; }

        [Required(ErrorMessage = "El campo cedula es requerido.")]
        [StringLength(10, ErrorMessage = "El campo cedula debe tener como máximo 10 caracteres.")]
        public string InputCedula { get; set; }

        [Required(ErrorMessage = "El campo nombre de contacto es requerido.")]
        [StringLength(80, ErrorMessage = "El campo nombre de contacto debe tener como máximo 80 caracteres.")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Solo se permiten caracteres alfabéticos para el nombre de contacto.")]
        public string InputNombreContacto { get; set; }

        [Required(ErrorMessage = "El campo titulo es requerido.")]
        [StringLength(80, ErrorMessage = "El campo titulo debe tener como máximo 80 caracteres.")]
        public string InputTitutlo { get; set; }

        [Required(ErrorMessage = "El campo correo electrónico es requerido.")]
        [EmailAddress(ErrorMessage = "El campo correo electrónico no es válido.")]
        [StringLength(30, ErrorMessage = "El campo correo electrónico debe tener como máximo 30 caracteres.")]
        public string InputEmail { get; set; }

        [Required(ErrorMessage = "El campo teléfono es requerido.")]
        [StringLength(12, ErrorMessage = "El campo teléfono debe tener como máximo 12 caracteres.")]
        public string InputTelefono { get; set; }

    }
}