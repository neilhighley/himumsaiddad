using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using HMSDDataModel.Models;

namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IVoucherService" in both code and config file together.
    [ServiceContract]
    public interface IVoucherService
    {

        [OperationContract]
        VoucherCodeDTO GetVoucher(int value);

        [OperationContract]
         VoucherResponse GetVouchers();

        // TODO: Add your service operations here
    }


    //Data Contract with vouchers separated into two lists
    [DataContract]
    public class VoucherResponse
    {
        private List<VoucherCodeDTO> _vcAvailable;
        [DataMember]
        public List<VoucherCodeDTO> Available
        {
            get { return _vcAvailable; }
            set { _vcAvailable = value; }
        }

        private List<VoucherCodeDTO> _vcNotAvailable;
        [DataMember]
        public List<VoucherCodeDTO> NotAvailable
        {
            get { return _vcNotAvailable; }
            set { _vcNotAvailable = value; }
        }
    }
}
