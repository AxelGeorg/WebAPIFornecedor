using WebAPIFornecedor.Model.Base;
using System.Collections.Generic;
using WebAPIFornecedor.Model;

namespace WebAPIFornecedor.Repository
{
    public interface IFornecedorRepository
    {
        Fornecedor Create(Fornecedor item);
        Fornecedor FindById(long id);
        List<Fornecedor> FindAll();
        Fornecedor Update(Fornecedor item);
        void Delete(long id);
        bool Exists(long id);
    }
}

