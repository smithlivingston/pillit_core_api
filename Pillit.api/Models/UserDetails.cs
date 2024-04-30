using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using pillit.lib.Entities;
using System;

namespace Pillit.api.Models
{
    public class UserDetails
    {
        [BsonIgnore]
        public Guid UserId { get; set; }
        [BsonElement]
        public string FirstName { get; set; }
        [BsonElement] 
        public string LastName { get; set; }
        [BsonElement] 
        public DateTime DOB { get; set; }
    }
}
