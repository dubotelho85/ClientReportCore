using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ClientReport.DAL.Entites
{
    
    public class ClientEntity
    {
        //[BsonId]
        //public string Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("value")]
        public decimal Value { get; set; }
    }
}
