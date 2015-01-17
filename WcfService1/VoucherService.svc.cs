using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using HMSDDataModel;
using HMSDDataModel.Models;

namespace WcfService1
{
    public class VoucherService : IVoucherService
    {
        public VoucherCodeDTO GetVoucher(int id)
        {
            VoucherCodeDTO vcdto;

            using (var dbc = new HMSDContext())
            {
                var vc = dbc.VoucherCodes.First(k => k.Id == id);
                vcdto = vc.ToVoucherCodeDTO();
            }

            return vcdto;
        }

        public VoucherResponse GetVouchers()
        {
           VoucherResponse vr=new VoucherResponse();
            using (var dbc = new HMSDContext())
            {
                vr.Available = dbc.VoucherCodes.Where(v => v.Claimed == false).ToVoucherCodeDTOs().ToList();
                vr.NotAvailable = dbc.VoucherCodes.Where(v => v.Claimed == true).ToVoucherCodeDTOs().ToList();
            }
            return vr;
        }
    }
}
