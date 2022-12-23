namespace HCOUserInfo.Models
{
    public class GetRecordsbyNameResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public List<InsertInformation> data { get; set; }
    }

    public class GetRecordsbyIdResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public InsertInformation data { get; set; }
    }
}
