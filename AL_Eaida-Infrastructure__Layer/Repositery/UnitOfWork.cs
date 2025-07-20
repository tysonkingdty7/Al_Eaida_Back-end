
using Al_Eaida_Domin.Interface;
using AL_Eaida_Infrastructure__Layer.IRepositery;

namespace AL_Eaida_Infrastructure__Layer.Repositery
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDBcontext _context;
        private readonly Dictionary<Type, object> _repositories = new();

    
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
            if (!_repositories.ContainsKey(typeof(T)))
            {
                var repoInstance = new GenaricRepositery<T>(_context);
                _repositories.Add(typeof(T), repoInstance);
            }

            return (IGenaricRepositery<T>)_repositories[typeof(T)];
        }
    }
}
