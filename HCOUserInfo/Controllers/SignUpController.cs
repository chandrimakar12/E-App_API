using HCOUserInfo.Models;
using HCOUserInfo.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HCOUserInfo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignUpController : ControllerBase
    {
        private readonly ISignupRepo _signupRepo;
        public SignUpController(ISignupRepo signupRepo)
        {
            _signupRepo = signupRepo;
        }

        [HttpPost]
        [Route("Signup")]
        public async Task<IActionResult> SignUp(SignUpInfo info)
        {
           SignUpResponse response = new SignUpResponse();
            
            try
            {
                response = await _signupRepo.SignUp(info);

            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return Ok(response);
        }
    }
}
