using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Ecommerce.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Cadastrar()
        {
            Usuario u = new Usuario();
            if(TempData["Endereco"] != null)
            {
                string resultado = TempData["Endereco"].ToString();
                Endereco endereco = JsonConvert.DeserializeObject<Endereco>(resultado);
                u.Endereco = endereco;
            }            
            //transforma no objeto
            
            //string resultado = client.DownloadString(url);
            return View();
        }
        [HttpPost]
        public IActionResult BuscarCep(Usuario u)
        {
            //url do cep
            string url = "https://viacep.com.br/ws/" + u.Endereco.Cep + "/json/";
            //
            WebClient client = new WebClient();
            //armazena temporariamente recupera uma única vez
            TempData["Endereco"] = client.DownloadString(url); ;
            //redireciona para a action; nameof garante que o nome está certo
            return RedirectToAction(nameof(Cadastrar));
            //return RedirectToAction("Cadastrar");
        }
    }
}