using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebAPIFornecedor.Model;
using WebAPIFornecedor.Model.Context;

namespace WebAPIFornecedor.Repository.Implementations
{
    public class FornecedorRepository : IFornecedorRepository
    {
        protected MySQLContext _context;

        private DbSet<Fornecedor> _dabaSet;

        public FornecedorRepository(MySQLContext context)
        {
            _context = context;
            _dabaSet = _context.Set<Fornecedor>();
        }

        public Fornecedor Create(Fornecedor item)
        {
            try
            {
                _dabaSet.Add(item);
                _context.SaveChanges();

                return item;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(long id)
        {
            Fornecedor result = _dabaSet.SingleOrDefault(p => p.Id.Equals(id));
            if (result != null)
            {
                try
                {
                    _dabaSet.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public bool Exists(long id)
        {
            return _dabaSet.Any(p => p.Id.Equals(id));
        }

        public List<Fornecedor> FindAll()
        {
            return _dabaSet.ToList();
        }

        public Fornecedor FindById(long id)
        {
            return _dabaSet.SingleOrDefault(p => p.Id.Equals(id));
        }

        public Fornecedor Update(Fornecedor item)
        {
            if (!Exists(item.Id))
                return null;

            Fornecedor result = _dabaSet.SingleOrDefault(p => p.Id.Equals(item.Id));
            if (result == null)
                return null;

            try
            {
                _context.Entry(result).CurrentValues.SetValues(item);
                _context.SaveChanges();

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
