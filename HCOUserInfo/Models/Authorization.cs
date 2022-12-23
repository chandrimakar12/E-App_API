using MongoDB.Bson.Serialization.Attributes;

namespace HCOUserInfo.Models
{
    public class Authorization
    {
        [BsonId]
        public long? UserId { get; set; }
        public string UserName { get; set; }

        public string Password { get; set; }

        public string Roles { get; set; }

        public string Token { get; set; }
    }
}
