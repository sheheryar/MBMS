using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace MBMS.Models
{
    public class User
    {
        [BsonId]
        public ObjectId ID { get; set; }
        [BsonElement("UserName")]
        public string UserName { get; set; }
    }
}
