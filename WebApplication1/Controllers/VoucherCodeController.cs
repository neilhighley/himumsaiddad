using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace WebApplication1.Controllers
{
    public class VoucherCodeController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<VoucherCode> Get()
        {
            List<VoucherCode> vcs = null;
            using (var dbc = new HMSDDataModel())
            {
                vcs = dbc.VoucherCodes.ToList();
            }
            return vcs;
        }

        // GET api/<controller>/5
        public VoucherCode Get(int id)
        {
            VoucherCode vc = null;
            using (var dbc = new HMSDDataModel())
            {
                var vcc = dbc.VoucherCodes.First(v => v.Id == id);
                if (vcc != null)
                {
                    vc = vcc;
                }
            }
            return vc;
        }

        // POST api/<controller>
        public void Post([FromBody]VoucherCode value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]VoucherCode value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            var dbc = new HMSDDataModel();
            dbc.VoucherCodes.Remove(dbc.VoucherCodes.First(v => v.Id == id));
        }
    }
}
