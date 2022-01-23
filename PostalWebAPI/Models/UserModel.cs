using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PostalWebAPI.Models
{
    public class UserModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.Int32)]
        public int? Id { get; set; }

        [BsonElement("name")]
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
        public string Address { get; set; }
    }
}
