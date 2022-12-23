using HCOUserInfo.Models;

namespace HCOUserInfo.Repository
{
    public interface IAuthorizationService
    {
       // object Authorization { get; set; }

        Authorization GetDetails(string UserName);
    }
}
