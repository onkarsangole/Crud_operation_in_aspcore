using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_CRUD_Operation.CommonLayer.Model;
using Task_CRUD_Operation.ServiceLayer;

namespace Task_CRUD_Operation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrudOperationController : ControllerBase
    {
        // Here I use dependency injection for controller to service Layer and service layer to reporsitory layer
        public readonly ICrudOperationSL _crudOperationSL;

        //Here create contructor
        public CrudOperationController(ICrudOperationSL crudOperationSL)
        {
            _crudOperationSL = crudOperationSL;
        }
        [HttpPost]
        [Route("CreateRecord")]
        public async Task<IActionResult> CreateRecord(CreateRecordRequest request)
        {
            CreateRecordResponse response = null;

            try
            {
                response = await _crudOperationSL.CreateRecord(request);
            }catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> ReadInformation()
        {
            ReadInformationResponse response = null;
            try
            {
                response = await _crudOperationSL.ReadInformation();
            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Message : " + ex.Message;
            }
            return Ok(response);
        }

        [HttpPut]
        [Route("UpdateRecord")]
        public async Task<IActionResult> UpdateInformation(UpdateRecordRequest request)
        {
            UpdateRecordResponse response = null;
            try
            {
                response = await _crudOperationSL.UpdateInformation(request);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Message : " + ex.Message;
            }
            return Ok(response);
        }

        [HttpDelete]
        [Route("DeleteRecord")]
        public async Task<IActionResult> DeleteInformation(DeleteRecordRequest request)
        {
            DeleteRecordResponse response = null;
            try
            {
                response = await _crudOperationSL.DeleteInformation(request);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Message : " + ex.Message;
            }
            return Ok(response);
        }
    }
        
}
