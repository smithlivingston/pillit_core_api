using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Pillit.api.Models
{
    public class CollectionProperties
    {
        [BsonIgnore]
        public string _objRefId { get; set; }
        [BsonElement]
        public DateTime CreatedTimeStamp { get; set; }
        [BsonElement]
        public DateTime UpdatedTimeStamp { get; set; }
        [BsonElement]
        public bool IsDelete { get; set; }
    }
}
