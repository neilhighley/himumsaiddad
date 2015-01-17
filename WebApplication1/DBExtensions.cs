using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using HMSDDataModel.Models;

namespace WebApplication1
{
    public static class DBExtensions
    {
        public static VoucherCodeDTO ToVoucherCodeDTO(this VoucherCode vc)
        {
            var vcdto = new VoucherCodeDTO()
            {
                Claimed = vc.Claimed,
                Identifier = vc.Identifier.ToString(),
                Id = vc.Id
            };
            return vcdto;
        }
        public static IQueryable<VoucherCodeDTO> ToVoucherCodeDTOs(this IQueryable<VoucherCode> vcs)
        {
            IQueryable<VoucherCodeDTO> vcdto = vcs.Select(vc => new VoucherCodeDTO()
            {
                Claimed = vc.Claimed,
                Identifier = vc.Identifier.ToString(),
                Id = vc.Id
            });
            return vcdto;
        }
        
        public static VoucherCode ToVoucherCode(this VoucherCodeDTO vcdto)
        {
            var vc= new VoucherCode()
            {
                Claimed = vcdto.Claimed,
                Identifier = Guid.Parse(vcdto.Identifier.ToString()),
                Id = vcdto.Id
            };
            return vc;
        }
    }
}