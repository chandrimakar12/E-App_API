using HCOUserInfo.Controllers;
using HCOUserInfo.Models;
using HCOUserInfo.Repository;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using NUnit.Framework;
using Moq;

namespace HCOUserInfoTest
{
    public class Tests
    {
        HCOInfoRepo hCOinfoRepo;
        private readonly IHCOInfoRepo _hCOInfoRepo;

        private MockRepository mockRepository;
        private Mock<IHCOInfoRepo> mockHCOInfoRepo;

        [SetUp]
        public void Setup()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
            this.mockHCOInfoRepo= this.mockRepository.Create<IHCOInfoRepo>();
        }

        private HCOUserInfoController Create()
        {
            return new HCOUserInfoController(this.mockHCOInfoRepo.Object);
        }

        [Test]
        public void GetAll_ExpectedBehaviour()
        {
            var hCOUserInfoController = Create();
            InsertInformation info = new InsertInformation(){ id=1, organizationName ="Organization", address ="Tollyguange", country="India", state="West Bengal", city="Kolkata", zipCode=700082, email="www.org.com", webSite="https://www.org.com", primaryContact="PC", primaryContactPhone=9331092359, secondaryContact="SC", secondaryContactPhone=9331092359,programs="programs", Status="submitted", submittedBy="hcouser_1" };
            mockHCOInfoRepo.Setup(i => i.GetAllRecord());
            var result = hCOUserInfoController.GetAllRecord();
            var final = result;
            Assert.True(true);
            this.mockHCOInfoRepo.Verify(i=> i.GetAllRecord(), Times.Once());
            this.mockRepository.VerifyAll();
            
        }

        [Test]
        public void GetAllRecord_Works()
        {
            // Assert.Pass();
            HCOUserInfoController hco = new HCOUserInfoController(_hCOInfoRepo);
            var info = hco.GetAllRecord();
            Assert.IsNotNull(info);
        }


        [Test]
        public void GetRecordsbyName_Works()
        {
            // Assert.Pass();
            HCOUserInfoController hco2 = new HCOUserInfoController(_hCOInfoRepo);
            var info = hco2.GetRecordsbyName("hcouser_1");
            Assert.IsNotNull(info);
        }

        [Test]
        public void GetRecordsbyID_Works()
        {
            // Assert.Pass();
            HCOUserInfoController hco3 = new HCOUserInfoController(_hCOInfoRepo);
            var info = hco3.GetRecordsbyID("1000000001");
            Assert.IsNotNull(info);
        }

        [Test]
        public void InsertInfo_Test_ExpectedBehaviour()
        {
            var hCOUserInfoController = Create();
            InsertInformation info = new InsertInformation() { id = 1, organizationName = "Organization", address = "Tollyguange", country = "India", state = "West Bengal", city = "Kolkata", zipCode = 700082, email = "www.org.com", webSite = "https://www.org.com", primaryContact = "PC", primaryContactPhone = 9331092359, secondaryContact = "SC", secondaryContactPhone = 9331092359, programs = "programs", Status = "submitted", submittedBy = "hcouser_1" };
            mockHCOInfoRepo.Setup(i => i.InsertInfo(info));

            var result = hCOUserInfoController.InsertInfo(info);
            var final = result;

            Assert.True(final != null);
            mockHCOInfoRepo.Verify(i => i.InsertInfo(info), Times.Once());
            this.mockRepository.VerifyAll();
        }

        [Test]
        public void UpdateInfo_Test_ExpectedBehaviour()
        {
            var hCOUserInfoController = Create();
            InsertInformation info = new InsertInformation() { id = 1, organizationName = "Organization", address = "Tollyguange", country = "India", state = "West Bengal", city = "Kolkata", zipCode = 700082, email = "www.org.com", webSite = "https://www.org.com", primaryContact = "PC", primaryContactPhone = 9331092359, secondaryContact = "SC", secondaryContactPhone = 9331092359, programs = "programs", Status = "submitted", submittedBy = "hcouser_1" };
            mockHCOInfoRepo.Setup(i=> i.UpdateInfo(info));

            var result = hCOUserInfoController.UpdateInfo(info);
            var final = result;

            Assert.True(final != null);
            mockHCOInfoRepo.Verify(i => i.UpdateInfo(info), Times.Once());
            mockRepository.VerifyAll();
        }
    }
}