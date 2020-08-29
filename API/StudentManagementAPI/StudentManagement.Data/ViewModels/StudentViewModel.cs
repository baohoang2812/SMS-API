﻿using Newtonsoft.Json;
using System;

namespace StudentManagement.Data.ViewModels
{
    public class StudentViewModel
    {

    }
    public class StudentCreateViewModel : BaseViewModel<Student>
    {
        [JsonProperty("image_path")]
        public string ImagePath { get; set; }
        [JsonProperty("first_name")]
        public string FirstName { get; set; }
        [JsonProperty("last_name")]
        public string LastName { get; set; }
        [JsonProperty("address")]
        public string Address { get; set; }
        [JsonProperty("dob")]
        public DateTime? DoB { get; set; }
        [JsonProperty("phone")]
        public string Phone { get; set; }
        [JsonProperty("class_id")]
        public int? ClassId { get; set; }
    }
    public class StudentUpdateViewModel : BaseViewModel<Student>
    {
        [JsonProperty("image_path")]
        public string ImagePath { get; set; }
        [JsonProperty("first_name")]
        public string FirstName { get; set; }
        [JsonProperty("last_name")]
        public string LastName { get; set; }
        [JsonProperty("address")]
        public string Address { get; set; }
        [JsonProperty("dob")]
        public DateTime? DoB { get; set; }
        [JsonProperty("phone")]
        public string Phone { get; set; }
        [JsonProperty("class_id")]
        public int? ClassId { get; set; }
    }
}
