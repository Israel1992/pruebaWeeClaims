using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace pruebaWeeCompany.Controllers
{
    public class CedulaProfecionalAPIController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public async Task<string> GetAsync(int id)
        {
            string responseBody = "";
            using (HttpClient client = new HttpClient())
            {
                string url = "https://cedulaprofesional.sep.gob.mx/cedula/buscaCedulaJson.action?json=%7B%27maxResult%27:%27100%27,%27nombre%27:%27%27,%27paterno%27:%27%27,%27materno%27:%27%27,%27idCedula%27:%27"+ id + "%27%7D";
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    responseBody = await response.Content.ReadAsStringAsync();
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("Error en la solicitud HTTP: " + e.Message);
                }
            }

            return responseBody;
        }

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
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