using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using HMSDDataModel;
using HMSDDataModel.Models;
using WebApplication1;

namespace WebApplication1.Controllers
{
    public class VoucherCodesController : ODataController
    {
        private HMSDContext db = new HMSDContext();

        // GET: odata/VoucherCodes
        [EnableQuery]
        public IQueryable<VoucherCodeDTO> GetVoucherCodes()
        {

            var vcdtos = from VoucherCode vc in db.VoucherCodes
                select new VoucherCodeDTO()
                {
                    Claimed = vc.Claimed,
                    Id = vc.Id,
                    Identifier = vc.Identifier.ToString()
                };
                

            return vcdtos;

        }

        // GET: odata/VoucherCodes(5)
        [EnableQuery]
        public SingleResult<VoucherCodeDTO> GetVoucherCode([FromODataUri] int key)
        {
            var vcodedtos = from VoucherCode vc in db.VoucherCodes.Select(voucherCode => voucherCode.Id == key)
                            select new VoucherCodeDTO()
                            {
                                Claimed = vc.Claimed,
                                Id = vc.Id,
                                Identifier = vc.Identifier.ToString()
                            };

            return SingleResult.Create(vcodedtos);
        }

        // PUT: odata/VoucherCodes(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<VoucherCode> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            VoucherCode voucherCode = await db.VoucherCodes.FindAsync(key);
            if (voucherCode == null)
            {
                return NotFound();
            }

            patch.Put(voucherCode);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VoucherCodeExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(voucherCode.ToVoucherCodeDTO());
        }

        // POST: odata/VoucherCodes
        public async Task<IHttpActionResult> Post(VoucherCode voucherCode)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.VoucherCodes.Add(voucherCode);
            await db.SaveChangesAsync();

            return Created(voucherCode.ToVoucherCodeDTO());
        }

        // PATCH: odata/VoucherCodes(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<VoucherCode> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            VoucherCode voucherCode = await db.VoucherCodes.FindAsync(key);
            if (voucherCode == null)
            {
                return NotFound();
            }

            patch.Patch(voucherCode);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VoucherCodeExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(voucherCode.ToVoucherCodeDTO());
        }

        // DELETE: odata/VoucherCodes(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            VoucherCode voucherCode = await db.VoucherCodes.FindAsync(key);
            if (voucherCode == null)
            {
                return NotFound();
            }

            db.VoucherCodes.Remove(voucherCode);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VoucherCodeExists(int key)
        {
            return db.VoucherCodes.Count(e => e.Id == key) > 0;
        }
    }
}
