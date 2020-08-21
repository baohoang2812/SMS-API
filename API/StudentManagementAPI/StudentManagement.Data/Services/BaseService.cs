using StudentManagement.Data.Repository;
using StudentManagement.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentManagement.Data.Services
{
    public interface IBaseService<E, K>
    {
        IQueryable<E> Get();
        E Update(IBaseViewModel<E> viewModel, K key);
        E Remove(K key);
        E Remove(E entity);
        E Create(IBaseViewModel<E> viewModel);
        E FindByKey(K key);
        int GetCount();
    }
    public abstract class BaseService<E, K> : IBaseService<E, K>
    {
        protected readonly IUnitOfWork unitOfWork;
        protected readonly IBaseRepository<E, K> baseRepository;

        public BaseService(IUnitOfWork unitOfWork, IBaseRepository<E, K> baseRepository)
        {
            this.unitOfWork = unitOfWork;
            this.baseRepository = baseRepository;
        }

        public E Create(IBaseViewModel<E> viewModel)
        {
            return baseRepository.Create(viewModel.ToEntity());
        }

        public E FindByKey(K key)
        {
            return baseRepository.FindByKey(key);
        }

        public IQueryable<E> Get()
        {
            return baseRepository.Get();
        }

        public int GetCount()
        {
            return baseRepository.Count();
        }

        public E Remove(K key)
        {
            var entity = baseRepository.FindByKey(key);
            return baseRepository.Remove(entity);
        }

        public E Remove(E entity)
        {
            return baseRepository.Remove(entity);
        }

        public E Update(IBaseViewModel<E> viewModel, K key)
        {
            var foundEntity = FindByKey(key);
            return viewModel.CopyToEntity(viewModel, foundEntity);
        }
    }
}
