using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PostalService.DAL.Models
{
    public class UserModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.Int32)]
        [Required]
        public int? Id { get; set; }

        [BsonElement("name")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Name should be withing 3 and 50 symols")]
        public string Name { get; set; }

        [BsonElement("age")]
        public int Age { get; set; }

        [BsonElement("gender")]
        public string Gender { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("phone")]
        public string Phone { get; set; }

        [BsonElement("address")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Address should be withing 3 and 50 symols")]
        public string Address { get; set; }

        [BsonIgnore]
        public List<PackageModel> Packages { get; set; }
    }
}
