using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace HCOUserInfo.Models
{
    public class SignUpInfo
    {
        [BsonId]
        public long? UserId { get; set;}

        public string UserName { get; set;}
        
        public string Password { get; set;}
        public string Roles { get; set;}
        public string Token { get; set; }
    }

    public class SignUpResponse
    {
        public bool IsSuccess { get; set;}
        public string Message { get; set;}
    }
}
