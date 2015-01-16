using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DbModels;

namespace demoCode
{
    public class VoucherController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<VoucherCode> Get()
        {
            var dbc = new HMSDData();
            return dbc.voucherCodes.ToList();
        }

        // GET api/<controller>/5
        public VoucherCode Get(int id)
        {
            var dbc = new HMSDData();
            VoucherCode vc=null;
            var vcc= dbc.voucherCodes.First(v => v.VoucherId == id);
            if (vcc != null)
            {
                vc = vcc;
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
            var dbc = new HMSDData();
            dbc.voucherCodes.Remove(dbc.voucherCodes.First(v => v.VoucherId == id));
        }
    }
}