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

        public virtual E Create(IBaseViewModel<E> viewModel)
        {
            return baseRepository.Create(viewModel.ToEntity());
        }

        public virtual E FindByKey(K key)
        {
            return baseRepository.FindByKey(key);
        }

        public virtual IQueryable<E> Get()
        {
            return baseRepository.Get();
        }

        public virtual int GetCount()
        {
            return baseRepository.Count();
        }

        public virtual E Remove(K key)
        {
            var entity = baseRepository.FindByKey(key);
            return baseRepository.Remove(entity);
        }

        public virtual E Remove(E entity)
        {
            return baseRepository.Remove(entity);
        }

        public virtual E Update(IBaseViewModel<E> viewModel, K key)
        {
            var foundEntity = FindByKey(key);
            return viewModel.CopyToEntity(viewModel, foundEntity);
        }
    }
}
