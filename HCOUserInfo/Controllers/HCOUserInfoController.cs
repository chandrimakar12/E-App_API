using HCOUserInfo.Models;
using HCOUserInfo.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HCOUserInfo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HCOUserInfoController : ControllerBase
    {
        private readonly IHCOInfoRepo _hCOInfoRepo;

        public HCOUserInfoController(IHCOInfoRepo hCOInfoRepo)
        {
            _hCOInfoRepo = hCOInfoRepo;
        }

        //HCO User enters their details

        //static int id = 1;
        [HttpPost]
        [Route("InsertInformation")]
        public async Task<IActionResult> InsertInfo(InsertInformation info)
        {
            InsertInfoResponse response = new InsertInfoResponse();
            try
            {
                response = await _hCOInfoRepo.InsertInfo(info);
                //int id = int.Parse(info.id);

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Occured : " + ex.Message;
            }

            return Ok(response);

        }


        [HttpGet]
        [Route("GetAllRecord")]
        public async Task<IActionResult> GetAllRecord()
        {
            GetAllRecordResponse response = new GetAllRecordResponse();
            try
            {
                response = await _hCOInfoRepo.GetAllRecord();

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Occured : " + ex.Message;
            }

            return Ok(response);

        }

        [HttpGet]
        [Route("GetRecordsbyID")]
        public async Task<IActionResult> GetRecordsbyID([FromQuery] string id)
        {
            GetRecordsbyIdResponse response = new GetRecordsbyIdResponse();
            try
            {
                response = await _hCOInfoRepo.GetRecordsbyID(id);

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Occured : " + ex.Message;
            }

            return Ok(response);

        }
        [HttpGet]
        [Route("GetRecordsbyName")]
        public async Task<IActionResult> GetRecordsbyName([FromQuery] string userName)
        {
            GetRecordsbyNameResponse response = new GetRecordsbyNameResponse();
            try
            {
                response = await _hCOInfoRepo.GetRecordsbyName(userName);

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Occured : " + ex.Message;
            }

            return Ok(response);

        }

        //HCO User Updates Info 
        [HttpPut]
        [Route("UpdateInformation")]
        public async Task<IActionResult> UpdateInfo(InsertInformation request)
        {
            UpdateInfoResponse response = new UpdateInfoResponse();
            try
            {
                response = await _hCOInfoRepo.UpdateInfo(request);

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Occured : " + ex.Message;
            }

            return Ok(response);

        }
    }
}
