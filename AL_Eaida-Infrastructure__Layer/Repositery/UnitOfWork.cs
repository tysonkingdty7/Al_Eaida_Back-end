
using Al_Eaida_Domin.Interface;
using AL_Eaida_Infrastructure__Layer.IRepositery;

namespace AL_Eaida_Infrastructure__Layer.Repositery
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDBcontext _context;

        public UnitOfWork(AppDBcontext context)
        {
            _context = context;
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IGenaricRepositery<T> Repository<T>() where T : class
        {
            // Assuming a dictionary to store repositories for different types  
            var repositories = new Dictionary<Type, object>();

            if (!repositories.ContainsKey(typeof(T)))
            {
                repositories[typeof(T)] = new GenaricRepositery<T>(_context);
            }

            return (IGenaricRepositery<T>)repositories[typeof(T)];
        }
    }
}
