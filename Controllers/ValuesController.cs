using ClienteRest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ClienteRest.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<Models.Usuarios> Get()
        {
            IEnumerable<Models.Usuarios> lst;

            using (Models.DB_IntComexEntities1 db = new Models.DB_IntComexEntities1())
            {
                lst = db.Usuarios.ToList();
            }

            return lst;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
