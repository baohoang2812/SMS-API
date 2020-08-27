using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Data.ViewModels
{
    public class ApiResult
    {
        [JsonProperty("code")]
        public ResultCode? Code { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("data")]
        public object Data { get; set; }
    }

    public enum ResultCode
    {
        [Display(Name = StatusCodeName.NotFound)]
        NotFound = 404,
        [Display(Name = StatusCodeName.InternalServerError)]
        InternalServerError = 500,
        [Display(Name = StatusCodeName.Created)]
        Created = 201,
        [Display(Name = StatusCodeName.Ok)]
        Ok = 200,
        [Display(Name = StatusCodeName.BadRequest)]
        BadRequest = 400
    }

    public static class StatusCodeName
    {
        public const string NotFound = "Not Found";
        public const string InternalServerError = "Internal Server Error";
        public const string Created = "Created";
        public const string Ok = "Success";
        public const string BadRequest = "Bad Request";

    }
}
