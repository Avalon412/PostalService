using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace PostalService.DAL.Models
{
    public class PackageModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.Int32)]
        [Required]
        public int? Id { get; set; }
        [BsonElement("_userId")]
        [Required]
        public int UserId { get; set; }
        [BsonElement("weight")]
        public int Weight { get; set; }
        [BsonElement("dateOfDeparture")]
        public string DateOfDeparture { get; set; }
        [BsonElement("sender")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Sender should be withing 3 and 50 symols")]
        public string Sender { get; set; }
        [BsonElement("cityOfDeparture")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "City should be withing 3 and 50 symols")]
        public string cityOfDeparture { get; set; }
        [BsonElement("isReceived")]
        public bool IsReceived { get; set; }
    }
}
