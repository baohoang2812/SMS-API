using System;
using NUnit.Framework;
using StudentManagement.Data;
using StudentManagement.Data.Services;
using StudentManagement.Data.ViewModels;

namespace StudentManagement.Tests.IntegrationTests
{
    [SetUpFixture]
    public class StudentServiceTests
    {
        private readonly IStudentService _service;
        private Student _student;

        public StudentServiceTests()
        {
            
        }
        public StudentServiceTests(IStudentService service)
        {
            _service = service;
        }

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            var studentViewModel = new StudentCreateViewModel()
            {
                FirstName = "John",
                LastName = "Wick",
                Address = "California",
                DoB = new DateTime(1999, 09, 20),
                Phone = "0123456789",
            };
            _student = _service.Create(studentViewModel);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            _service.Remove(_student.Id);
        }

        [Test]
        public void CreateStudent_OK_Success()
        {
            // Prepare
            var studentCreateViewModel = new StudentCreateViewModel()
            {
                FirstName = "John",
                LastName = "Wick",
                Address = "California",
                DoB = new DateTime(1999, 09, 20),
                Phone = "0123456789",
            };

            // Run
            var result = _service.Create(studentCreateViewModel);


            Assert.AreEqual(result.FirstName, studentCreateViewModel.FirstName);
            Assert.AreEqual(result.LastName, studentCreateViewModel.LastName);
            Assert.AreEqual(result.DoB, studentCreateViewModel.DoB);
            Assert.AreEqual(result.Address, studentCreateViewModel.Address);

            _service.Remove(result.Id);
        }

        [Test]
        public void CreateStudent_EmptyFirstNameAndLastName_Error()
        {
            // Prepare
            var studentCreateViewModel = new StudentCreateViewModel()
            {
                FirstName = "",
                LastName = "",
                Address = "California",
                DoB = new DateTime(1999, 09, 20),
                Phone = "0123456789",
            };

            // Run
            var result = _service.Create(studentCreateViewModel);


            Assert.IsEmpty(result.FirstName);
            Assert.IsEmpty(result.LastName);

            _service.Remove(result.Id);
        }
    }
}