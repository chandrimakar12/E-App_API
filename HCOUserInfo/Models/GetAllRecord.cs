namespace HCOUserInfo.Models
{
    public class GetAllRecordResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public List<InsertInformation> data { get; set; }
    }
}
