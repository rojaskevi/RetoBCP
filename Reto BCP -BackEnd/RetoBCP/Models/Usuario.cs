using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetoBCP.Models
{
    public class Usuario
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("username")]
        public string user { get; set; }
        [BsonElement("password")]
        public string password { get; set; }
        [BsonElement("token")]
        public string token { get; set; }
    }
}
