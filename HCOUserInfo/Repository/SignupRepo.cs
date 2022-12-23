using HCOUserInfo.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;


namespace HCOUserInfo.Repository
{
    public class SignupRepo: ISignupRepo
    {
        private readonly IConfiguration _configuration;

        private readonly MongoClient _mongoClient;
        private readonly IMongoCollection<SignUpInfo> _mongoCollection;

        public SignupRepo(IConfiguration configuration)
        {
            _configuration = configuration;
            _mongoClient = new MongoClient(_configuration["UserModel:ConnectionString"]);
            var _MongoDatabase = _mongoClient.GetDatabase(_configuration["UserModel:DatabaseName"]);
            _mongoCollection = _MongoDatabase.GetCollection<SignUpInfo>(_configuration["UserModel:UserDetailsCollectionName"]);
        }


        public async Task<SignUpResponse> SignUp(SignUpInfo info)
        {
            SignUpResponse res = new SignUpResponse();
      
            res.IsSuccess = true;
            res.Message = "User Added Successfully";
            // int id = 1022345609;

            try
            {
                var obj = _mongoCollection.Find(x => true).ToList();
                int count = obj.Count();
                info.UserId = (count + 1200) + 1;


                await _mongoCollection.InsertOneAsync(info);

            }
            catch (Exception ex)
            {
                res.IsSuccess= false;
                res.Message= ex.Message;
            }

            return res;
        }


    }
}
