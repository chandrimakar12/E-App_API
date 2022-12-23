using HCOUserInfo.Models;

namespace HCOUserInfo.Repository
{
    public interface ISignupRepo
    {
        public Task<SignUpResponse> SignUp(SignUpInfo info);
    }
}
