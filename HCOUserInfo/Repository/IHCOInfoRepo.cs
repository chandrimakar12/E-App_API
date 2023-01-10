using HCOUserInfo.Models;

namespace HCOUserInfo.Repository
{
    public interface IHCOInfoRepo
    {
        public Task<InsertInfoResponse> InsertInfo(InsertInformation info);

        public Task<GetAllRecordResponse> GetAllRecord();

        public Task<GetRecordsbyIdResponse> GetRecordsbyID(string id);

        public Task<GetRecordsbyNameResponse> GetRecordsbyName(string userName);

        public Task<GetRecordsbyStatusResponse> GetRecordsbyStatus(string status);

        public Task<UpdateInfoResponse> UpdateInfo(InsertInformation request);
    }
}
