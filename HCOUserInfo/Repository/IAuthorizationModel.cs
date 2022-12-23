namespace HCOUserInfo.Repository
{
    public interface IAuthorizationModel
    {
        string UserDetailsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
