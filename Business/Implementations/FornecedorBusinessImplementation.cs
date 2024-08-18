using Google.Protobuf.Compiler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using WebAPIFornecedor.Model;
using WebAPIFornecedor.Repository;

namespace WebAPIFornecedor.Business.Implementations
{
    public class FornecedorBusinessImplementation : IFornecedorBusiness
    {
        private readonly IFornecedorRepository _repository;

        public FornecedorBusinessImplementation(IFornecedorRepository repository)
        {
            _repository = repository;
        }

        public Fornecedor Create(Fornecedor fornecedor)
        {
            return _repository.Create(fornecedor);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<Fornecedor> FindAll()
        {
            return _repository.FindAll();
        }

        public Fornecedor FindById(long id)
        {
            return _repository.FindById(id);
        }

        public Fornecedor Update(Fornecedor fornecedor)
        {
            return _repository.Update(fornecedor);
        }
    }
}
