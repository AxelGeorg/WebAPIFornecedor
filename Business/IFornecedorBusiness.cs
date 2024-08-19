using System.Collections.Generic;
using WebAPIFornecedor.Data.VO;
using WebAPIFornecedor.Model;

namespace WebAPIFornecedor.Business
{
    public interface IFornecedorBusiness
    {
        Fornecedor Create(FornecedorVO fornecedor);
        Fornecedor FindById(long id);
        List<Fornecedor> FindAll();
        Fornecedor Update(long id, FornecedorVO person);
        void Delete(long id);
    }
}
