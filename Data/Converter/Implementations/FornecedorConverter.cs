using System.Collections.Generic;
using System.Linq;
using WebAPIFornecedor.Data.Converter.Contract;
using WebAPIFornecedor.Data.VO;
using WebAPIFornecedor.Model;

namespace WebAPIFornecedor.Data.Converter.Implementations
{
    public class FornecedorConverter : IParser<FornecedorVO, Fornecedor>, IParser<Fornecedor, FornecedorVO>
    {
        public Fornecedor Parse(FornecedorVO origin)
        {
            if (origin == null)
                return null;

            return new Fornecedor
            {
                Id = origin.Id,
                Nome = origin.Nome,
                Email = origin.Email,
            };
        }

        public FornecedorVO Parse(Fornecedor origin)
        {
            if (origin == null)
                return null;

            return new FornecedorVO
            {
                Id = origin.Id,
                Nome = origin.Nome,
                Email = origin.Email,
            };
        }

        public List<Fornecedor> Parse(List<FornecedorVO> origin)
        {
            if (origin == null)
                return null;

            return origin.Select(item => Parse(item)).ToList();
        }

        public List<FornecedorVO> Parse(List<Fornecedor> origin)
        {
            if (origin == null)
                return null;

            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
