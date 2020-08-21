namespace StudentManagement.Data.ViewModels
{
    public interface IBaseViewModel<E>
    {
        E ToEntity();
        E CopyToEntity(IBaseViewModel<E> model, E entity);
    }
    public class BaseViewModel<E> : IBaseViewModel<E> where E : class
    {
        public E CopyToEntity(IBaseViewModel<E> model, E entity)
        {
            return Global.Global.Mapper.Map(model, entity);
        }

        public E ToEntity()
        {
            return Global.Global.Mapper.Map<E>(this);
        }
    }
}
