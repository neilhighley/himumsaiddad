using System.Collections.Generic;

namespace WebApplication1
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class HMSDDataModel : DbContext
    {
        // Your context has been configured to use a 'HMSDDataModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'WebApplication1.HMSDDataModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'HMSDDataModel' 
        // connection string in the application configuration file.
        public HMSDDataModel()
            : base("name=HMSDDataModel")
        {
            Database.SetInitializer<HMSDDataModel>(new HMSDDataModelInitialiser());
            Configuration.ProxyCreationEnabled = false;
        }


         public virtual DbSet<VoucherCode> VoucherCodes { get; set; }
    }
    /// <summary>
    /// The vouchercode model for the database entity
    /// </summary>
    public class VoucherCode
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Guid Identifier { get; set; }
        public bool Claimed { get; set; }
    }

    /// <summary>
    /// Create a subset to initially populate the database
    /// </summary>
    public class HMSDDataModelInitialiser : CreateDatabaseIfNotExists<HMSDDataModel>
    {
        protected override void Seed(HMSDDataModel context)
        {
            var vcs = new List<VoucherCode>
            {
                new VoucherCode()
                {
                    Claimed = false,
                    Id = 1,
                    Identifier = Guid.NewGuid(),
                    Name = "Voucher A"
                },
                new VoucherCode()
                {
                    Claimed = false,
                    Id = 2,
                    Identifier = Guid.NewGuid(),
                    Name = "Voucher B"
                },
                new VoucherCode()
                {
                    Claimed = false,
                    Id = 3,
                    Identifier = Guid.NewGuid(),
                    Name = "Voucher C"
                }
            };
            vcs.ForEach(vc=>context.VoucherCodes.Add(vc));
        }
    }
}