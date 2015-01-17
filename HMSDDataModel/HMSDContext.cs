using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMSDDataModel.Models;

namespace HMSDDataModel
{
    public class HMSDContext : DbContext
    {
        // Your context has been configured to use a 'HMSDContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'WebApplication1.HMSDContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'HMSDContext' 
        // connection string in the application configuration file.
        public HMSDContext()
            : base("name=HMSDData")
        {
            Database.SetInitializer<HMSDContext>(new HMSDContextInitialiser());
            Configuration.ProxyCreationEnabled = false;
        }


        public virtual DbSet<VoucherCode> VoucherCodes { get; set; }
    }
   
    /// <summary>
    /// Create a subset to initially populate the database
    /// </summary>
    public class HMSDContextInitialiser : CreateDatabaseIfNotExists<HMSDContext>
    {
        /// <summary>
        /// Initialise the Database with some content
        /// </summary>
        /// <param name="context"></param>
        protected override void Seed(HMSDContext context)
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
            vcs.ForEach(vc => context.VoucherCodes.Add(vc));
        }
    }
}
