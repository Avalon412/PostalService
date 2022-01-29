using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace PostalService.DAL.Models
{
    public class PackageModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.Int32)]
        public int? Id { get; set; }
        [BsonElement("_userId")]
        public int UserId { get; set; }
        [BsonElement("weight")]
        public int Weight { get; set; }
        [BsonElement("dateOfDeparture")]
        public DateTime DateOfDeparture { get; set; }
        [BsonElement("sender")]
        public string Sender { get; set; }
        [BsonElement("cityOfDeparture")]
        public string cityOfDeparture { get; set; }
        [BsonElement("isReceived")]
        public bool IsReceived { get; set; }
    }
}
