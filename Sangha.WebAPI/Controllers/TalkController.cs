using Sangha.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Sangha.WebAPI.Controllers
{
    public class TalkController : ApiController
    {
        // GET: api/Talk
        public IEnumerable<Talk> Get()
        {
            return TalkRepository.GetTalkList();
        }

        //// GET: api/Talk/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/Talk
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/Talk/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Talk/5
        //public void Delete(int id)
        //{
        //}
    }
}
