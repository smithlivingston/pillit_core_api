using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Pillit.api.Models
{

    public class User : CollectionProperties
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement]
        public Guid UserId { get; set; }
        [BsonElement]
        public string Password { get; set; }
        [BsonElement]
        public byte[] PasswordSalt { get; set; }
        [BsonElement]
        public string Email { get; set; }
        [BsonElement]
        public int UserType { get; set; }
        public UserDetails Details { get; set; }
    }
}
