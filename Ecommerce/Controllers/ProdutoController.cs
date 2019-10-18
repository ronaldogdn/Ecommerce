using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.DAL;
using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    public class ProdutoController : Controller
    {
        //var usada para acessar dentre todas as views
        //readonly só recebe no construtor ou na declaração; não pode dar new()
        private readonly ProdutoDAO _produtoDAO;
        public ProdutoController(ProdutoDAO produtoDAO)
        {
            _produtoDAO = produtoDAO;       
        }
        //actions -> no controller os métodos se chamam actions
        //1 ° action faz a abertura da view
        public IActionResult Index()
        {
            //sacola que aceitar qualquer coisa
            ViewBag.Produtos = _produtoDAO.Listar();
            ViewBag.DataHora = DateTime.Now;
            //abre a view
            return View();
        }
        //actiona para cadastrar
        public IActionResult Cadastrar()
        {
            return View();
        }
        //só é acessado via post
        [HttpPost]
        public IActionResult Cadastrar(string txtNome, string txtDescricao, string txtPreco, string txtQuantidade)
        {
            Produto p = new Produto
            {
                Nome = txtNome,
                Descricao = txtDescricao,
                Preco = Convert.ToDouble(txtPreco),
                Quantidade = Convert.ToInt32(txtQuantidade)
            };

            _produtoDAO.CadastrarProduto(p);
            //return View();
            //redirecionamento
            return RedirectToAction("Index");
        }
        //o ? pode receber parâmetro nulo
        public IActionResult Remover(int? id)
        {
            if (id != null)
            {
                //remover o produto
                if (_produtoDAO.RemoverProdutoPorId(id))
                {
                    return RedirectToAction("Index");
                }                
            }
            //redirecionar para uma pág de erro
            return RedirectToAction("Cadastrar");
        }

        public IActionResult Alterar(int? id)
        {
            if(id != null)
            {
                ViewBag.Produto = _produtoDAO.ListarProdutoPorId(id);
                return View();
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Alterar(string txtNome,string txtDescricao,string txtPreco,string txtQuantidade,
                                     string txtID, string hdnID)
        {
            Produto p = _produtoDAO.ListarProdutoPorId(Convert.ToInt32(hdnID));

            p.Nome = txtNome;
            p.Descricao = txtDescricao;
            p.Preco = Convert.ToDouble(txtPreco);
            p.Quantidade = Convert.ToInt32(txtQuantidade);

            _produtoDAO.Alterar(p);
            return RedirectToAction("Index");
        }
    }
}