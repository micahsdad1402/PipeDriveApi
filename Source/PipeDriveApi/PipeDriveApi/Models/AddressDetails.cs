using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipeDriveApi
{
    public class AddressDetails : BaseEntity
    {
        public string AddressType { get; set; }
        public string Address { get; set; }
        public string SubPremise { get; set; }
        public string StreetNumber { get; set; }
        public string Route { get; set; }
        public string SubLocality { get; set; }
        public string Locality { get; set; }
        public string AdminAreaLevel1 { get; set; }
        public string AdminAreaLevel2 { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string FormattedAddress { get; set; }
    }
}
