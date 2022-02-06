using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostalWebAPI.DTOs
{
    public class PackageDTO
    {
        public int? Id { get; set; }
        public int UserId { get; set; }
        public int Weight { get; set; }
        public string DateOfDeparture { get; set; }
        public string Sender { get; set; }
        public string cityOfDeparture { get; set; }
        public bool IsReceived { get; set; }
    }
}
