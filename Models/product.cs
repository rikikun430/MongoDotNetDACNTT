using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace mongodb_dotnet_example.Models
{
    public class product
    {
		[BsonId]

		public object objectId { get; set; }
		public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int price { get; set; }
       
        public int stars { get; set; }

        public string img { get; set; }
        public string location { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public int type_id { get; set; }

    }
}