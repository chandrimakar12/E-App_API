using HCOUserInfo.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace HCOUserInfo.Repository
{
    public class AuthorizationModel: IAuthorizationModel
    {
        public string UserDetailsCollectionName { get; set; } = string.Empty;
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
    }
}
