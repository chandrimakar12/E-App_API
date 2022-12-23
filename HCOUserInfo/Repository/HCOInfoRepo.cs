using HCOUserInfo.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace HCOUserInfo.Repository
{
    public class HCOInfoRepo : IHCOInfoRepo
    {
        private readonly IConfiguration _configuration;

        private readonly MongoClient _mongoClient;
        private readonly IMongoCollection<InsertInformation> _mongoCollection;

        public HCOInfoRepo(IConfiguration configuration)
        {
            _configuration = configuration;
            _mongoClient = new MongoClient(_configuration["DatabaseSettings:ConnectionString"]);
            var _MongoDatabase = _mongoClient.GetDatabase(_configuration["DatabaseSettings:DatabaseName"]);
            _mongoCollection = _MongoDatabase.GetCollection<InsertInformation>(_configuration["DatabaseSettings:CollectionName"]);
        }


        // HCO User inserts records
        public async Task<InsertInfoResponse> InsertInfo(InsertInformation info)
        {
            InsertInfoResponse response = new InsertInfoResponse();
            response.IsSuccess = true;
            response.Message = "Information Saved Successfully";
           // int id = 1022345609;
            
            try
            {
                var obj = _mongoCollection.Find(x => true).ToList();
                int count = obj.Count();
                info.id = (count + 1000000000) + 1;
                

                await _mongoCollection.InsertOneAsync(info);

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Occured : " + ex.Message;

            }
            //id=id2;
            return response;
        }



        public async Task<GetAllRecordResponse> GetAllRecord()
        {
            GetAllRecordResponse response = new GetAllRecordResponse();
            response.IsSuccess = true;
            response.Message = "Data Feched Successfully";

            try
            {
                response.data = new List<InsertInformation>();
                response.data = await _mongoCollection.Find(x => true).ToListAsync();
                if (response.data.Count == 0)
                {
                    response.Message = "No Record Found";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Error occured : " + ex.Message;
            }

            return response;
        }

        public async Task<GetRecordsbyIdResponse> GetRecordsbyID(string id)
        {
            GetRecordsbyIdResponse response = new GetRecordsbyIdResponse();
            response.IsSuccess = true;
            response.Message = "Record Fetched Successfully";
            try
            {
                response.data = new InsertInformation();
                response.data = await _mongoCollection.Find(x => x.id.ToString() == id).FirstOrDefaultAsync();
                if (response.data == null)
                {
                    response.Message = "Invalid Id.\nPlease Enter Valid Id";
                }

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }



        public async Task<GetRecordsbyNameResponse> GetRecordsbyName(string userName)
        {
            GetRecordsbyNameResponse response = new GetRecordsbyNameResponse();
            response.IsSuccess = true;
            response.Message = "Record Fetched Successfully";
            try
            {
                response.data = new List<InsertInformation>();
                response.data = await _mongoCollection.Find(x => x.submittedBy == userName).ToListAsync();
                if (response.data == null)
                {
                    response.Message = "Invalid Id.\nPlease Enter Valid Id";
                }

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }



        public async Task<UpdateInfoResponse> UpdateInfo(InsertInformation request)
        {
            UpdateInfoResponse response = new UpdateInfoResponse();
            response.IsSuccess = true;
            response.Message = "Updated Successfully";

            try
            {
                GetRecordsbyIdResponse response1 = await GetRecordsbyID(request.id.ToString());
                //request.RegDate = response1.data.RegDate;
                //request.Status = response1.data.Status;
                //request.UpdateDate = DateTime.Now.ToString();

                var Res = await _mongoCollection.ReplaceOneAsync(x => x.id == request.id, request);

                if (!Res.IsAcknowledged)
                {
                    response.Message = "Id Not Found";
                }

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Occured : " + ex.Message;

            }

            return response;

        }
    }
}
