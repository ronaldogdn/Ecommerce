using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class ItemVendaDAO : IRepository<ItemVenda>
    {
        private readonly Context _context;

        public ItemVendaDAO(Context context)
        {
            _context = context;
        }

        public ItemVenda BuscarPorId(int? id)
        {
            return _context.ItensVendas.Find(id);
        }

        public bool Cadastrar(ItemVenda item)
        {
            ItemVenda itemAux = _context.ItensVendas.FirstOrDefault(x => x.Produto.ProdutoId == item.Produto.ProdutoId
                                && x.CarrinhoId == item.CarrinhoId);
            if(itemAux == null)
            {
                //primeiro produto no carrinho de compras
                _context.ItensVendas.Add(item);
            }
            else
            {
                //adiciona mais um produto da mesma categoria
                itemAux.Quantidade++;
            }
            _context.SaveChanges();
            return true;
        }

        public List<ItemVenda> ListarTodos()
        {
            return _context.ItensVendas.ToList();
        }

        public List<ItemVenda> ListarItensPorCarrinhoId(string carrinhoId)
        {
            return _context.ItensVendas.
                Include(x => x.Produto.Categoria).
                Where(x => x.CarrinhoId == carrinhoId).ToList();
        }

        public double RetornarTotalCarrinho(string carrinhoId)
        {
            return _context.ItensVendas.
                Where(x => x.CarrinhoId == carrinhoId).
                Sum(x => x.Quantidade * x.Preco);
        }

        public void Remover(int id)
        {
            _context.ItensVendas.Remove(BuscarPorId(id));
            _context.SaveChanges();
        }
        public void Alterar(ItemVenda i)
        {
            _context.ItensVendas.Update(i);
            _context.SaveChanges();
        }

        public void AumentarQuantidade(int id)
        {
            ItemVenda i = BuscarPorId(id);
            i.Quantidade++;
            Alterar(i);
        }

        public void DiminuirQuantidade(int id)
        {
            ItemVenda i = BuscarPorId(id);
            if (i.Quantidade > 1)
            {
                i.Quantidade--;
                Alterar(i);
            }
        }
    }
}
