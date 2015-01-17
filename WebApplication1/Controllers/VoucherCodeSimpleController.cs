using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HMSDDataModel;
using HMSDDataModel.Models;


namespace WebApplication1.Controllers
{
    public class VoucherCodeSimpleController: ApiController
    {
        // GET api/<controller>
        public IEnumerable<VoucherCodeDTO> Get()
        {
            List<VoucherCode> vcs = null;
            using (var dbc = new HMSDContext())
            {
                vcs = dbc.VoucherCodes.ToList();
            }
            return vcs.Select(c=>c.ToVoucherCodeDTO());
        }

        // GET api/<controller>/5
        public VoucherCodeDTO Get(int id)
        {
            VoucherCode vc = null;
            using (var dbc = new HMSDContext())
            {
                var vcc = dbc.VoucherCodes.First(v => v.Id == id);
                if (vcc != null)
                {
                    vc = vcc;
                }
            }
            return vc.ToVoucherCodeDTO();
        }

        // POST api/<controller>
        public void Post([FromBody]VoucherCodeDTO value)
        {
            using (var dbc = new HMSDContext())
            {
                dbc.VoucherCodes.Add(value.ToVoucherCode());
            }
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]VoucherCodeDTO value)
        {
            //update the data
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            var dbc = new HMSDContext();
            dbc.VoucherCodes.Remove(dbc.VoucherCodes.First(v => v.Id == id));
        }
    }
}
