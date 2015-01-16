using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DbModels
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class HMSDData : DbContext
    {
        public HMSDData()
            : base("name=HMSDData")
        {
        }

        public virtual DbSet<VoucherCode> voucherCodes { get; set; }
        public virtual DbSet<ClaimedVoucher> claimedVouchers { get; set; }

    }

    public class HMSInitialiser : CreateDatabaseIfNotExists<HMSDData>
    {
        protected override void Seed(HMSDData context)
        {
            var voucherCodes = new List<VoucherCode>
            {
                new VoucherCode()
                {
                    AvailableCount = 2,
                    ClientName = "Neil Highley International",
                    CurrentCount = 0,
                    Description = "Have some stuff",
                    LiveDate = DateTime.Now.AddDays(-1),
                    Name = "NH Free",
                    VoucherId = 1
                },
                new VoucherCode()
                {
                    AvailableCount = 2,
                    ClientName = "Neil Highley Inc",
                    CurrentCount = 0,
                    Description = "Have some stuff later",
                    LiveDate = DateTime.Now.AddDays(4),
                    Name = "NH Later",
                    VoucherId = 2
                },
                new VoucherCode()
                {
                    AvailableCount = 2,
                    ClientName = "Neil Highley Inc",
                    CurrentCount = 2,
                    Description = "Can't Have some stuff ",
                    LiveDate = DateTime.Now.AddDays(-1),
                    Name = "NH Sold out",
                    VoucherId = 3
                }
            };
            voucherCodes.ForEach(v=>context.voucherCodes.Add(v));


        }
    }

}