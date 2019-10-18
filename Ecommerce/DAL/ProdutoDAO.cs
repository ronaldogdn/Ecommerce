using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.DAL
{
    public class ProdutoDAO
    {
        private readonly Context _context;
        public ProdutoDAO(Context context)
        {
            //depende do contexto para funcionar
            _context = context;            
        }
        public void CadastrarProduto(Produto p)
        {
            _context.Produtos.Add(p);
            _context.SaveChanges();
        }

        public List<Produto> Listar()
        {
            return _context.Produtos.ToList();
        }

        public Produto ListarProdutoPorId(int? id)
        {
            return _context.Produtos.Find(id);            
        }
        public bool RemoverProdutoPorId(int? id)
        {
            try
            {
                _context.Produtos.Remove(ListarProdutoPorId(id));
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }            
        }
        public void Alterar(Produto p)
        {
            _context.Produtos.Update(p);
            _context.SaveChanges();
        }
    }
}
