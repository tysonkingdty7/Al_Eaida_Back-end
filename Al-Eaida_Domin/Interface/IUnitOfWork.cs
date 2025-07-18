using System;
using System.Threading.Tasks;

namespace Al_Eaida_Domin.Interface

{
    public interface IUnitOfWork : IDisposable
    {
        IGenaricRepositery<T> Repository<T>() where T : class;
        Task<int> CompleteAsync();
    }
}
