using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PostalWebAPI.Models
{
    public class UserModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.Int32)]
        public int? Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
