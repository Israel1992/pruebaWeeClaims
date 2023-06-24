using pruebaWeeCompany.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace pruebaWeeCompany.Controllers
{
    public class ParticipantesAPIController : ApiController
    {
        // GET api/<controller>
        public List<WCParticipantes> Get(){
            ParticipantesService ps = new ParticipantesService();
            return ps.listarParticipaciones();
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public ResponseGeneral Post([FromBody] Participantes data){

            //Se podria crear un metodo general para validar los parametros de entrada, dejo el procedmiento en este metodo para fines de prueba
            var resultadosValidacion = new List<ValidationResult>();
            var contextoValidacion = new ValidationContext(data);
            ResponseGeneral response = new ResponseGeneral();

            bool esValido = Validator.TryValidateObject(data, contextoValidacion, resultadosValidacion, true);

            if (esValido)
            {
                ParticipantesService ps = new ParticipantesService();
                response = ps.insertarParticipacion(data);
                return response;
            }
            else
            {
                // Devolver los errores de validación como respuesta de la API
                var mensajesErrores = resultadosValidacion.Select(r => r.ErrorMessage);
                var erroresComoString = string.Join(Environment.NewLine, mensajesErrores);
                response.estatus = false;
                response.msg = erroresComoString;
                return response;
            }
           
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}