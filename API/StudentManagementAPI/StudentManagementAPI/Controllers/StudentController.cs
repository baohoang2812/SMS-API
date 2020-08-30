using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Azure.Storage.Blob;
using StudentManagement.Data.Extensions;
using StudentManagement.Data.Repository;
using StudentManagement.Data.Services;
using StudentManagement.Data.ViewModels;
using System;
using StudentManagement.Data.Extension;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentManagementAPI.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/students")]
    [ApiController]
    public class StudentController : BaseController
    {
        private readonly IStudentService _studentService;

        public StudentController(IUnitOfWork unitOfWork, IStudentService studentService) : base(unitOfWork)
        {
            _studentService = studentService;
        }

        // GET: api/<StudentController>
        [HttpGet]
        public IActionResult Get([FromQuery] int[] ids, string name, string className, int capacity = 50, int pageIndex = 1)
        {
            if (capacity == 0 || pageIndex == 0) return BadRequest("capacity and pageIndex must greater than 0");
            if (className == null) className = "";
            try
            {
                var result = _studentService.GetStudentList(ids, name, capacity, pageIndex, className);
                return Ok(new ApiResult
                {
                    Code = ResultCode.Ok,
                    Message = ResultCode.Ok.DisplayName(),
                    Data = result
                });
            }
            catch (Exception e)
            {
                return Error(e);
            }
        }

        // GET: api/<StudentController>/count
        [HttpGet("count")]
        public IActionResult GetCount()
        {
            try
            {
                var result = _studentService.GetCount();
                return Ok(new ApiResult
                {
                    Code = ResultCode.Ok,
                    Message = ResultCode.Ok.DisplayName(),
                    Data = result
                });
            }
            catch (Exception e)
            {
                return Error(e);
            }
        }

        // POST api/<StudentController>
        [HttpPost]
        public IActionResult Post([FromForm] StudentCreateViewModel model)
        {
            try
            {
                var result = _studentService.Create(model);
                return Created($"/api/students?ids={result.Id}", new ApiResult()
                {
                    Code = ResultCode.Created,
                    Message = ResultCode.Created.DisplayName(),
                    Data = result
                });
            }
            catch (Exception e)
            {
                return Error(e);
            }
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromForm] StudentUpdateViewModel model, int id)
        {
            try
            {
                var result = _studentService.Update(model, id);
                return Ok(new ApiResult()
                {
                    Code = ResultCode.Ok,
                    Message = ResultCode.Ok.DisplayName(),
                    Data = result
                });
            }
            catch (Exception e)
            {
                return Error(e);
            }
        }

        [HttpPost("upload")]
        public IActionResult UploadImage(IFormFile file)
        {
            try
            {
                if (file == null || !file.IsImage())
                {
                    return BadRequest(new ApiResult
                    {
                        Code = ResultCode.BadRequest,
                        Message = $"{ResultCode.BadRequest.DisplayName()}: invalid file, must be an image",
                    });
                }
                CloudBlobContainer blobContainer = BlobStorageService.GetCloudBlobContainer();
                CloudBlockBlob blob = blobContainer.GetBlockBlobReference(file.FileName);
                blob.UploadFromStream(file.OpenReadStream());
                var imagePath = blobContainer.GetBlockBlobReference(file.FileName).Uri;
                return Ok(new ApiResult
                {
                    Message = ResultCode.Ok.DisplayName(),
                    Code = ResultCode.Ok,
                    Data = imagePath
                });
            }
            catch (Exception e)
            {
                return Error(e);
            }
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var result = _studentService.FindByKey(id);
                if (result == null)
                {
                    return NotFound(new ApiResult
                    {
                        Code = ResultCode.NotFound,
                        Message = ResultCode.NotFound.DisplayName(),
                    });
                }
                result = _studentService.Remove(id);
                unitOfWork.SaveChanges();
                return Ok(new ApiResult()
                {
                    Code = ResultCode.Ok,
                    Message = ResultCode.Ok.DisplayName(),
                    Data = result
                });
            }
            catch (Exception e)
            {
                return Error(e);
            }
        }
    }
}
