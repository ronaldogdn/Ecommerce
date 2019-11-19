using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Ecommerce.Util;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace Ecommerce.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProdutoDAO _produtoDAO;
        private readonly CategoriaDAO _categoriaDAO;
        private readonly ItemVendaDAO _itemVendaDAO;
        private readonly UtilsSession _utilsSession;
        public HomeController(ProdutoDAO produtoDAO, CategoriaDAO categoriaDAO, ItemVendaDAO itemVendaDAO,
            UtilsSession utilsSession)
        {
            _produtoDAO = produtoDAO;
            _categoriaDAO = categoriaDAO;
            _itemVendaDAO = itemVendaDAO;
            _utilsSession = utilsSession;
        }

        public IActionResult Index(int? id)
        {
            ViewBag.Categorias = _categoriaDAO.ListarTodos();
            if (id == null)
            {
                return View(_produtoDAO.ListarTodos());
            }
            return View(_produtoDAO.ListarPorCategoria(id));
        }

        public IActionResult Detalhes(int id)
        {
            return View(_produtoDAO.BuscarPorId(id));
        }
        public IActionResult AdicionarAoCarrinho(int id)
        {
            Produto p = _produtoDAO.BuscarPorId(id);
            ItemVenda i = new ItemVenda
            {
                Produto = p,
                Quantidade = 1,
                Preco = p.Preco.Value,
                CarrinhoId = _utilsSession.RetonarCarrinhoId()
            };
            //Gravar o objeto na tabela
            _itemVendaDAO.Cadastrar(i);
            return RedirectToAction("CarrinhoCompras");
        }
        public IActionResult RemoverDoCarrinho(int id)
        {
            _itemVendaDAO.Remover(id);
            return RedirectToAction("CarrinhoCompras");
        }
        public IActionResult CarrinhoCompras()
        {
            ViewBag.TotalCarrinho = _itemVendaDAO.
                RetornarTotalCarrinho(_utilsSession.RetonarCarrinhoId());

            return View(_itemVendaDAO.ListarItensPorCarrinhoId
                (_utilsSession.RetonarCarrinhoId()));
        }
        public IActionResult AumentarQuantidade(int id)
        {
            _itemVendaDAO.AumentarQuantidade(id);
            return RedirectToAction("CarrinhoCompras");
        }
        public IActionResult DiminuirQuantidade(int id)
        {
            _itemVendaDAO.DiminuirQuantidade(id);
            return RedirectToAction("CarrinhoCompras");
        }
    }
}