using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace ClientReport.DAL.Entites
{
    public class MonthEntity
    {
        [BsonId] 
        [BsonElement("month_id")]
        public string MonthId { get; set; }

        [BsonElement("month")]
        public string Month { get; set; }

        [BsonElement("clients")]
        public IEnumerable<ClientEntity> Clients { get; set; }
    }
}
