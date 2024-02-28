namespace Proyecto_01.Services
{
    public interface ICommonService <T,TI,TU>
    {

        Task<T> GetById(uint id);

        Task<IEnumerable<T>> GetAll(int pageNumber,int pageSize);

        Task<T> Add(TI productoInsertDto); 
        Task<T> Update(uint id,TU productoUpdateDto);

        Task<T> Delete(uint id);

    }
}
