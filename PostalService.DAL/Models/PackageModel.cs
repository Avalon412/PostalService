using System;
using System.ComponentModel.DataAnnotations;

namespace PostalService.DAL.Models
{
    public class PackageModel
    {
        public int? Id { get; set; }
        [Required]
        public int UserId { get; set; }
        public int Weight { get; set; }
        public string DateOfDeparture { get; set; }
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Sender should be withing 3 and 50 symols")]
        public string Sender { get; set; }
        [StringLength(100, MinimumLength = 3, ErrorMessage = "City should be withing 3 and 50 symols")]
        public string CityOfDeparture { get; set; }
        public bool IsReceived { get; set; }

        public virtual UserModel User { get; set; }
    }
}
