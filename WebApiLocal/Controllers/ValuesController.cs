using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiLocal.Controllers
{
    //[Authorize]
    public class ValuesController : ApiController
    {
        private DataAccess.Artista Artista;

        public ValuesController()
        {
            this.Artista = new DataAccess.Artista();
        }

        // GET api/values
        public List<DTO.Artista> Get()
        {
            return ( this.Artista.RetornaArtistas());
        }

        // GET api/values/5
        public DTO.Artista Get(int id)
        {
            return this.Artista.RetornaArtista(id);
        }

        // POST api/values
        public void Post(DTO.Artista artista)
        {
            var x = this.Artista.IngresaArtista(artista); 
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
