using Akij_Food_Crud_Operation_Api.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Akij_Food_Crud_Operation_Api.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<ColdDrink> ColdDrinks { get; }
        Task Save();
    }
}
