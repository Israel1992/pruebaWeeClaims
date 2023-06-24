using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pruebaWeeCompany.Models
{
    public class ParticipantesService
    {

        WeeCompanyEntities entidad = new WeeCompanyEntities();



        public List<WCParticipantes> listarParticipaciones() {

            return entidad.WCParticipantes.ToList();
        }




        public ResponseGeneral insertarParticipacion(Participantes data)
        {

            ResponseGeneral response = new ResponseGeneral();

            try {

                WCParticipantes participantes = new WCParticipantes();
                DateTime fechaActual = DateTime.Now;

                participantes.nombreCompania = data.InputNombreCompania;
                participantes.cedula = data.InputCedula;
                participantes.nombreContacto = data.InputNombreContacto;
                participantes.titulo = data.InputTitutlo;
                participantes.correoElectronico = data.InputEmail;
                participantes.telefono = data.InputTelefono;
                participantes.fecha = fechaActual;
                participantes.estatus = "1";

                entidad.WCParticipantes.Add(participantes);
                int registrosAfectados =  entidad.SaveChanges();

                if (registrosAfectados > 0)
                {
                    response.estatus = true;
                    response.msg = "Se guardo correctamente";
                    response.data = participantes;

                }
                else
                {
                    response.estatus = false;
                    response.msg = "error al guardar";
                }

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException exc) {
                response.estatus = false;
                response.msg = exc.Message;

                foreach (var error in exc.EntityValidationErrors)
                {
                    foreach (var validationError in error.ValidationErrors)
                    {

                        response.msg = $"Error de validación en la propiedad '{validationError.PropertyName}': {validationError.ErrorMessage}";
                    }
                }
            }

            return response;

        }

    }
}