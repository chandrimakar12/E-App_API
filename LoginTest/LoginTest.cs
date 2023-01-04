using HCOUserInfo.Controllers;
using HCOUserInfo.Models;
using HCOUserInfo.Repository;
using Moq;

namespace LoginTest
{
    public class Tests
    {

        AuthorizationService _authorizationService;
        private readonly IAuthorizationService _authorizationServiceRepo;

        private MockRepository mockRepository;
        private Mock<IAuthorizationService> mockAuthorizationService;

        [SetUp]
        public void Setup()
        {
           
              this.mockRepository = new MockRepository(MockBehavior.Strict);
              this.mockAuthorizationService = this.mockRepository.Create<IAuthorizationService>();
            
        }

        private LoginController Create()
        {
            return new LoginController(this.mockAuthorizationService.Object);
        }

        [Test]
        public void Post_Test()
        {
            var loginController = Create();
            Authorization value = new Authorization() { UserId = 1, UserName = "User", Password="password", Roles="user", Token="token" };
            mockAuthorizationService.Setup(i => i.GetDetails(value.UserName));

            var result = loginController.Authenticate(value);
            var final = result;

            Assert.True(final != null);

            mockAuthorizationService.Verify(i=> i.GetDetails(value.UserName), Times.Once());
            this.mockRepository.Verify();
        }
    }
}