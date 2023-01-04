using HCOUserInfo.Controllers;
using HCOUserInfo.Models;
using HCOUserInfo.Repository;
using Moq;

namespace SignUpTest
{
    public class Tests
    {
        SignupRepo signupRepo;
        private readonly ISignupRepo _signupRepo;

        private MockRepository mockRepository;
        private Mock<ISignupRepo> mockSignupRepo;

        [SetUp]
        public void Setup()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
            this.mockSignupRepo= this.mockRepository.Create<ISignupRepo>();  
        }

        private SignUpController Create()
        {
            return new SignUpController(this.mockSignupRepo.Object);
        }

        [Test]
        public void SignUpPostTest_ExpectedBehavior()
        {
            //Assert.Pass();
            var signUpController = Create();
            SignUpInfo value = new SignUpInfo() { UserId = 1, UserName = "User", Password = "password", Roles = "user", Token = "token" };
            mockSignupRepo.Setup(i => i.SignUp(value));

            var result = signUpController.SignUp(value);
            var final = result;

            // Assert.AreEqual(value, final);
            Assert.True(final != null);
            mockSignupRepo.Verify(i=>i.SignUp(value), Times.Once());
            mockRepository.VerifyAll();
        }
    }
}