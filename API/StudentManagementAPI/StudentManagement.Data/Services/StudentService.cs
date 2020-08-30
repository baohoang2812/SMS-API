using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Storage.Blob;
using StudentManagement.Data.Extension;
using StudentManagement.Data.Repository;
using StudentManagement.Data.ViewModels;
using System;
using System.Collections.Generic;

namespace StudentManagement.Data.Services
{
    public interface IStudentService : IBaseService<Student, int>
    {
        List<Student> GetStudentList(int[] ids, string name, int capacity, int index, string className);
        Student Create(StudentCreateViewModel model);
        Student Update(StudentUpdateViewModel model, int id);
        Student UpdateWithoutImg(StudentUpdateViewModel model, int id);
    }
    public class StudentService : BaseService<Student, int>, IStudentService
    {
        private IStudentRepository _studentRepository;
        private IUnitOfWork _unitOfWork;
        public StudentService(IUnitOfWork unitOfWork, IStudentRepository studentRepository) : base(unitOfWork, studentRepository)
        {
            this._studentRepository = studentRepository;
            _unitOfWork = unitOfWork;
        }

        public Student UpdateWithoutImg(StudentUpdateViewModel model, int id)
        {
            return _studentRepository.UpdateWithoutImg(model, id);
        }

        public List<Student> GetStudentList(int[] ids, string name, int capacity, int index, string className)
        {
            return _studentRepository.GetStudentList(ids, name, capacity, index, className);
        }
        public Student Create(StudentCreateViewModel model)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                var student = base.Create(model);
                var image = model.Image;
                student.ImagePath = GetImageUri(image);
                _unitOfWork.SaveChanges();
                _unitOfWork.CommitTransaction();
                return student;
            }
            catch (Exception e)
            {
                _unitOfWork.RollbackTransaction();
                throw;
            }
        }

        public Student Update(StudentUpdateViewModel model, int id)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                var image = model.Image;
                var student = base.Update(model, id);
                student.ImagePath = GetImageUri(image);
                _unitOfWork.SaveChanges();
                _unitOfWork.CommitTransaction();
                return student;
            }
            catch (Exception e)
            {
                _unitOfWork.RollbackTransaction();
                throw;
            }
        }

        private string GetImageUri(IFormFile image)
        {
            if (image != null && image.IsImage())
            {
                CloudBlobContainer blobContainer = BlobStorageService.GetCloudBlobContainer();
                CloudBlockBlob blob = blobContainer.GetBlockBlobReference(image.FileName);
                blob.UploadFromStream(image.OpenReadStream());
                return blobContainer.GetBlockBlobReference(image.FileName).Uri.ToString();
            }
            return null;
        }
    }
}
