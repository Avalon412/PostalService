using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PostalService.DAL.Models
{
    public class UserModel
    {
        public int? Id { get; set; }
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Name should be withing 3 and 50 symols")]
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Address should be withing 3 and 50 symols")]
        public string Address { get; set; }

        public virtual List<PackageModel> Packages { get; set; }
    }
}
