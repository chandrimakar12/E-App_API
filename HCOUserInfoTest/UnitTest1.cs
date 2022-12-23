using HCOUserInfo.Controllers;
using HCOUserInfo.Models;
using HCOUserInfo.Repository;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using NUnit.Framework;

namespace HCOUserInfoTest
{
    public class Tests
    {
        HCOInfoRepo hCOinfoRepo;
        private readonly IHCOInfoRepo _hCOInfoRepo;

        [SetUp]
        public void Setup()
        {
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
        public void GetRecordsbyId_Works()
        {
            // Assert.Pass();
            HCOUserInfoController hco2 = new HCOUserInfoController(_hCOInfoRepo);
            var info = hco2.GetRecordsbyName("hcouser_1");
            Assert.IsNotNull(info);
        }

        

    }
}