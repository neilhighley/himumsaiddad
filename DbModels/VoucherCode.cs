using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DbModels
{
    public class VoucherCode
    {
        public int VoucherId { get; set; }
        public string ClientName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int AvailableCount { get; set; }
        public int CurrentCount { get; set; }
        public DateTime LiveDate { get; set; }
    }

    public class ClaimedVoucher
    {
        public int ReferenceId { get; set; }
        public DataSet ClaimedDate { get; set; }
        public string EmailAddress { get; set; }
        public string IPAddress { get; set; }
        public string Country { get; set; }
    }
}