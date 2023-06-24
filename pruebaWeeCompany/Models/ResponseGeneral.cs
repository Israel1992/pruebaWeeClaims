using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pruebaWeeCompany.Models
{
    public class ResponseGeneral
    {

        public string msg { get; set; }
        public Boolean estatus { get; set; }
        public List<Object> datas { get; set; }
        public Object data { get; set; }
    }
}