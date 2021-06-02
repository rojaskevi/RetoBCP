using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace RetoBCP.Models
{
    public class TipoCambio
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("monedaOrigen")]
        public string MonedaOrigen { get; set; }

        [BsonElement("monedaDestino")]
        public string MonedaDestino { get; set; }

        [BsonElement("cambio")]
        public decimal Cambio { get; set; }


    }
}
