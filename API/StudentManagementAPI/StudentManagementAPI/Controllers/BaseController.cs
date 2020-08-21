using Microsoft.AspNetCore.Mvc;
using StudentManagement.Data.Extensions;
using StudentManagement.Data.Repository;
using StudentManagement.Data.ViewModels;
using System;
using System.Net;

namespace StudentManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected readonly IUnitOfWork unitOfWork;

        public BaseController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Error<T>(T obj)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, obj);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Error(Exception exception)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, new ApiResult()
            {
                Code = ResultCode.InternalServerError,
                Message = ResultCode.InternalServerError.DisplayName(),
                Data = exception
            });
        }
    }
}
