﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Data.Extensions;
using StudentManagement.Data.Repository;
using StudentManagement.Data.Services;
using StudentManagement.Data.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentManagementAPI.Controllers
{
    [Route("api/classes")]
    [ApiController]
    public class ClassController : BaseController
    {
        private IClassService _classService;
        public ClassController(IUnitOfWork unitOfWork, IClassService classService) : base(unitOfWork)
        {
            _classService = classService;
        }

        // GET: api/<ClassController>
        [HttpGet]
        public IActionResult Get()
        {
            return BadRequest();
        }

        // POST api/<ClassController>
        [HttpPost]
        public IActionResult Post(ClassCreateViewModel model)
        {
            try
            {
                var result = _classService.Create(model);
                unitOfWork.SaveChanges();
                return Created($"/api/classes?ids={result.Id}", new ApiResult()
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

        // PUT api/<ClassController>/5
        [HttpPut("{id}")]
        public IActionResult Put(ClassUpdateViewModel model, int id)
        {
            try
            {
                var result = _classService.Update(model, id);
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

        // DELETE api/<ClassController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var result = _classService.FindByKey(id);
                if (result == null)
                {
                    return NotFound(new ApiResult
                    {
                        Code = ResultCode.NotFound,
                        Message = ResultCode.NotFound.DisplayName(),
                    });
                }
                result = _classService.Remove(id);
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