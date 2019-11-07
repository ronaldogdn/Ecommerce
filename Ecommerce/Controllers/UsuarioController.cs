using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Repository;

namespace Ecommerce.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly UsuarioDAO _usuarioDAO;
        public UsuarioController(UsuarioDAO usuarioDAO)
        {
            _usuarioDAO = usuarioDAO;
        }
        public IActionResult Index()
        {
            ViewBag.DataHora = DateTime.Now;
            return View(_usuarioDAO.ListarTodos());
        }
        public IActionResult Cadastrar()
        {
            Usuario u = new Usuario();
            if(TempData["Endereco"] != null)
            {
                //pega o resultado da var temporária; é perdido depois de usar
                string resultado = TempData["Endereco"].ToString();
                //deserializa o endereço
                Endereco endereco = JsonConvert.DeserializeObject<Endereco>(resultado);
                u.Endereco = endereco;
            }
            if(TempData["Erro"] != null)
            {
                ModelState.AddModelError("", "Informe um CEP válido!");
            }
            return View(u);
        }
        [HttpPost]
        public IActionResult BuscarCep(Usuario u)
        {
            
            try
            {
                //url do cep
                string url = "https://viacep.com.br/ws/" + u.Endereco.Cep + "/json/";
                //
                WebClient client = new WebClient();

                //armazena temporariamente; recupera uma única vez
                //armazena o json do CEP
                TempData["Endereco"] = client.DownloadString(url);
                //redireciona para a action; nameof garante que o nome está certo
                return RedirectToAction(nameof(Cadastrar));
                //return RedirectToAction("Cadastrar");
            }
            catch(WebException e)
            {
                TempData["Erro"] = e.Message;                
            }
            return RedirectToAction("Cadastrar");
        }
        [HttpPost]
        public IActionResult Cadastrar(Usuario u)
        {
            //valida as anotations
            if (ModelState.IsValid)
            {
                if (_usuarioDAO.Cadastrar(u))
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", "Este e-mail já está cadastrado!");
            }
            else
            {
                //se existe algum campo vazio
                ModelState.AddModelError("", "Preencha todos os campos!");
            }
            return View(u);
        }
    }
}