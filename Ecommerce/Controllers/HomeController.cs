using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace Ecommerce.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProdutoDAO _produtoDAO;
        private readonly CategoriaDAO _categoriaDAO;
        public HomeController(ProdutoDAO produtoDAO, CategoriaDAO categoriaDAO)
        {
            _produtoDAO = produtoDAO;
            _categoriaDAO = categoriaDAO;
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
                Preco 
            }
        }
    }
}