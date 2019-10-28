using Ecommerce.Models;
using System.Collections.Generic;
using System.Linq;

namespace Ecommerce.DAL
{
    public class ProdutoDAO
    {
        //var somente leitura
        private readonly Context _context;
        public ProdutoDAO(Context context)
        {
            //depende do contexto para funcionar
            _context = context;            
        }
        public bool CadastrarProduto(Produto p)
        {
            //faz a validação antes de salvar
            if (BuscarProdutoPorNome(p) == null)
            {
                _context.Produtos.Add(p);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        //verifica se existe um produto já cadastrado
        public Produto BuscarProdutoPorNome(Produto p)
        {
            return _context.Produtos.FirstOrDefault(x => x.Nome.Equals(p.Nome));            
        }
        public List<Produto> Listar()
        {
            return _context.Produtos.ToList();
        }

        public Produto ListarProdutoPorId(int? id)
        {
            return _context.Produtos.Find(id);            
        }
        //id pode vir nulo
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
