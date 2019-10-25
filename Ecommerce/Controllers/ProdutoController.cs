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
            //ViewBag.Produtos = _produtoDAO.Listar(); @model foi colocado
            ViewBag.DataHora = DateTime.Now;
            //abre a view
            return View(_produtoDAO.Listar());
        }
        //actiona para cadastrar
        public IActionResult Cadastrar()
        {
            return View();
        }
        //só é acessado via post
        [HttpPost]
        public IActionResult Cadastrar(Produto p)
        {
            if (ModelState.IsValid)
            {
                //o objeto p chega preenchido do @model
                if (_produtoDAO.CadastrarProduto(p))
                {
                    //redirecionamento
                    return RedirectToAction("Index");
                }
                //mandar mensagens para o usuário
                ModelState.AddModelError("", "Esse produto já existe");
                /*o parâmetro é opcional;
                 * return View para preencher o formulário e não perder os dados
                já cadastrados nesse formulário*/
                return View(p);
            }
            return View(p);
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
            //preenche o produto ao carregar a pag
            if(id != null)
            {
                return View(_produtoDAO.ListarProdutoPorId(id));
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Alterar(Produto p)
        {
            _produtoDAO.Alterar(p);
            return RedirectToAction("Index");
        }
    }
}