using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SHKEntity;
using StrongholdTiming.Models;

namespace StrongholdTiming.Controllers
{
    public class EdgesController : ApiController
    {
        readonly int DEFAULT_KINGDOM = 1;
        // GET api/edges
        public IEnumerable<EdgeModel> Get()
        {
            throw new NotImplementedException();
        }

        // GET api/edges/5
        public EdgeModel Get(int id)
        {
            throw new NotImplementedException();
        }

        // POST api/edges
        public void Post([FromBody]EdgeModel v)
        {
            Kingdom k = Universe.GetKingdom(DEFAULT_KINGDOM);
            k.AddEdge(v.GetEntity());
        }

        // PUT api/edges/5
        public void Put(int id, [FromBody]EdgeModel v)
        {
            throw new NotImplementedException();
        }

        // DELETE api/edges/5
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
