using HCOUserInfo.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace HCOUserInfo.Repository
{
    public class AuthorizationService : IAuthorizationService
    {
        /*private readonly IMongoCollection<Authorization> _allUserDetails;
        public AuthorizationService(IAuthorizationModel settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _allUserDetails = database.GetCollection<Authorization>(settings.UserDetailsCollectionName);
        }*/
        private readonly IConfiguration _configuration;

        private readonly MongoClient _mongoClient;
        private readonly IMongoCollection<Authorization> _mongoCollection;

        public AuthorizationService(IConfiguration configuration)
        {
            _configuration = configuration;
            _mongoClient = new MongoClient(_configuration["UserModel:ConnectionString"]);
            var _MongoDatabase = _mongoClient.GetDatabase(_configuration["UserModel:DatabaseName"]);
            _mongoCollection = _MongoDatabase.GetCollection<Authorization>(_configuration["UserModel:UserDetailsCollectionName"]);
        }

        public Authorization GetDetails(string UserName)
        {
            return _mongoCollection.Find(user => user.UserName == UserName).FirstOrDefault();
        }
    }
}
