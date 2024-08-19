using Google.Protobuf.Compiler;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using WebAPIFornecedor.Data.Converter.Implementations;
using WebAPIFornecedor.Data.VO;
using WebAPIFornecedor.Model;
using WebAPIFornecedor.Repository;

namespace WebAPIFornecedor.Business.Implementations
{
    public class FornecedorBusinessImplementation : IFornecedorBusiness
    {
        private readonly IFornecedorRepository _repository;
        private readonly FornecedorConverter _converter;

        public FornecedorBusinessImplementation(IFornecedorRepository repository)
        {
            _repository = repository;
            _converter = new FornecedorConverter();
        }

        public Fornecedor Create(FornecedorVO fornecedor)
        {
            Fornecedor fornecedorEntity = _converter.Parse(fornecedor);

            return _repository.Create(fornecedorEntity);
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

        public Fornecedor Update(long id, FornecedorVO fornecedor)
        {
            Fornecedor fornecedorEntity = _converter.Parse(fornecedor);
            fornecedorEntity.Id = id;

            return _repository.Update(fornecedorEntity);
        }
    }
}
