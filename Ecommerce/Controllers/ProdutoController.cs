using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repository;

namespace Ecommerce.Controllers
{
    public class ProdutoController : Controller
    {
        //var usada para acessar dentre todas as views
        //readonly só recebe no construtor ou na declaração; não pode dar new()
        private readonly ProdutoDAO _produtoDAO;
        private readonly CategoriaDAO _categoriaDAO;
        private readonly IHostingEnvironment _hosting;
        public ProdutoController(ProdutoDAO produtoDAO,CategoriaDAO categoriaDAO, IHostingEnvironment hosting)
        {
            _produtoDAO = produtoDAO;
            _categoriaDAO = categoriaDAO;
            _hosting = hosting;
        }
        //actions -> no controller os métodos se chamam actions
        //1 ° action faz a abertura da view
        public IActionResult Index()
        {
            //sacola que aceitar qualquer coisa
            //ViewBag.Produtos = _produtoDAO.Listar(); @model foi colocado
            ViewBag.DataHora = DateTime.Now;
            //abre a view
            return View(_produtoDAO.ListarTodos());
        }
        //actiona para cadastrar
        public IActionResult Cadastrar()
        {
            ViewBag.Categorias = new SelectList(_categoriaDAO.ListarTodos(), "CategoriaId","Nome");
            return View();
        }
        //só é acessado via post
        [HttpPost]
        public IActionResult Cadastrar(Produto p,int drpCategorias,IFormFile fupImagem)
        {
            ViewBag.Categorias = new SelectList(_categoriaDAO.ListarTodos(), "CategoriaId","Nome");
            if (ModelState.IsValid)
            {
                //verifica se a imagem existe
                if (fupImagem != null)
                {
                    //pega o caminho da imagem; GUID é um identificador universal que não se repete
                    string arquivo = Guid.NewGuid().ToString() + Path.GetExtension(fupImagem.FileName);
                    //combina o camimho da imagem com a pasta da imagem
                    string caminho = Path.Combine(_hosting.WebRootPath, "ecommerceImagens",arquivo);
                    fupImagem.CopyTo(new FileStream(caminho, FileMode.Create));
                    //pega a imagem e coloca no produto Imagem
                    p.Imagem = arquivo;
                }
                else
                {
                    p.Imagem = "semImagem.png";
                }
                //seleciona o ID da categoria
                p.Categoria = _categoriaDAO.BuscarPorId(drpCategorias);
                //o objeto p chega preenchido do @model
                if (_produtoDAO.Cadastrar(p))
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
                Produto p = _produtoDAO.BuscarPorId(id);
                string caminho = Path.Combine(_hosting.WebRootPath, "ecommerceImagens", p.Imagem);
                //remover o produto
                if (_produtoDAO.Remover(id))
                {
                    //verifica se a imagem existe
                    if (System.IO.File.Exists(caminho))
                    {
                        //apaga a imagem
                        System.IO.File.Delete(caminho);
                    }
                    return RedirectToAction("Index");
                }                
            }
            //redirecionar para uma pág de erro
            return RedirectToAction("Index");
        }

        public IActionResult Alterar(int? id)
        {
            //preenche o produto ao carregar a pag
            if(id != null)
            {
                return View(_produtoDAO.BuscarPorId(id));
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Alterar(Produto p, IFormFile fupImagem)
        {
            if (fupImagem != null)
            {
                //pega o caminho da imagem; GUID é um identificador universal que não se repete
                string arquivo = Guid.NewGuid().ToString() + Path.GetExtension(fupImagem.FileName);
                //combina o camimho da imagem com a pasta da imagem
                string caminho = Path.Combine(_hosting.WebRootPath, "ecommerceImagens", arquivo);
                fupImagem.CopyTo(new FileStream(caminho, FileMode.Create));
                //pega a imagem e coloca no produto Imagem
                p.Imagem = arquivo;
            }
            else
            {
                p.Imagem = "semImagem.png";
            }
            _produtoDAO.Alterar(p);
            return RedirectToAction("Index");
        }
    }
}