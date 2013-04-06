using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StrongholdTiming.Models;
using SHKEntity;


namespace StrongholdTiming.Controllers
{
    public class VillagesController : ApiController
    {
        readonly int DEFAULT_KINGDOM = 1;
        // GET api/villages
        public IEnumerable<VillageModel> Get()
        {
            Kingdom k = Universe.GetKingdom(DEFAULT_KINGDOM);
            return k.Villages.Select(x => new VillageModel(x));
        }

        // GET api/villages/5
        public VillageModel Get(int id)
        {
            Kingdom k = Universe.GetKingdom(DEFAULT_KINGDOM);
            return new VillageModel(k.GetVillage(id));
        }

        // POST api/villages
        public VillageModel Post(VillageModel v)
        {
            Kingdom k = Universe.GetKingdom(DEFAULT_KINGDOM);
            if (v != null)
            {
                v.Id = k.AddVillage(v.GetEntity());
                return v; 
            }
            else
            {
                throw new Exception("failed to parse posted data");
            }
        }

        // PUT api/villages/5
        public void Put(int id, [FromBody]VillageModel v)
        {
            Kingdom k = Universe.GetKingdom(DEFAULT_KINGDOM);
            throw new NotImplementedException();
        }

        // DELETE api/villages/5
        public void Delete(int id)
        {
            Kingdom k = Universe.GetKingdom(DEFAULT_KINGDOM);
            throw new NotImplementedException();
        }
    }
}
