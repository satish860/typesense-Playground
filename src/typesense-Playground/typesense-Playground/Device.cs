using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using typesense.domain.Attributes;

namespace typesense_Playground
{
    [Document]
    public class Device
    {
        public int? Id { get; set; }

        public string DisplayModel { get; set; }

        public string FriendlyName { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string SerialNumber { get; set; }

        [NonIndexable]
        public string HardwareIdentifier { get; set; }

        public int? LocationGroupID { get; set; }

        public string AssetNumber { get; set; }

        public string UserName { get; set; }

        public string Domain { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string FullName { get; set; }

        public string EmailAddress { get; set; }

        public string EmployeeIdentifier { get; set; }

        public string CostCenter { get; set; }

        public string LocationGroupName { get; set; }

        public string MACAddress { get; set; }

        public string CurrentIPAddress { get; set; }

        [NonIndexable]
        public int? CorpLiable { get; set; }

        [NonIndexable]
        public string OSVersion { get; set; }

        [NonIndexable]
        public int? DeviceType { get; set; }

    }
}
