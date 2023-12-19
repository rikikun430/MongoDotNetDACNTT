using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace mongodb_dotnet_example.Models
{
    public class Products
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        
        public int total_size { get; set; }
        public int type_id { get; set; }
        public int offset { get; set; }

		[BsonElement("product")]
		public List<product> product { get; set; }

    }
}