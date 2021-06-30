using Akij_Food_Crud_Operation_Api.data;
using Akij_Food_Crud_Operation_Api.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Akij_Food_Crud_Operation_Api.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;
        private IGenericRepository<ColdDrink> _coldDrink;

        public UnitOfWork(DatabaseContext context)
        {
            _context = context;
        }
        public IGenericRepository<ColdDrink> ColdDrinks => _coldDrink ??= new GenericRepository<ColdDrink>(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
