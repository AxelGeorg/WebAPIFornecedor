using System.Collections.Generic;
using WebAPIFornecedor.Model;

namespace WebAPIFornecedor.Business
{
    public interface IFornecedorBusiness
    {
        Fornecedor Create(Fornecedor fornecedor);
        Fornecedor FindById(long id);
        List<Fornecedor> FindAll();
        Fornecedor Update(Fornecedor person);
        void Delete(long id);
    }
}
