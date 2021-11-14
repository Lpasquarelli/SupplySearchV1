using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SupplySearchV1.Models;
using SupplySearchV1.Services;
using SupplySearchV1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupplySearchV1.Controllers
{
    public class DoadorController : Controller
    {
        private readonly IService _service;
        private readonly ILogger<DoadorController> _logger;
        public DoadorController(ILogger<DoadorController> logger, IService service)
        {
            _service = service;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Logar(Doador doador)
        {
            var usuario = _service.GetDoador();

            var verifica = usuario.Where(x => x.email == doador.email && x.Senha == doador.Senha).FirstOrDefault();

            if (verifica == null)
            {
                return View();
            }

            return RedirectToAction("AreaDoador", verifica);
        }

        public ActionResult AreaDoador(Doador doador)
        {
            var retorno = _service.GetDoacoesByID(doador.ID);

            foreach(var item in retorno)
            {
                item.LocalEntrega = _service.GetLocalByID(item.IDLocal);
            }

            doador.Doacoes = retorno.ToList();

            return View(doador);
        }

        public ActionResult RealizarDoacao(int id)
        {

            var doacaoViewModel = new CadastrarDoacaoViewModel();
            var doador = _service.GetDoadorByID(id);
            var locais = _service.GetLocal();

            doacaoViewModel.Local = locais.ToList();
            doacaoViewModel.Doador = doador;
            return View(doacaoViewModel);
        }
        public ActionResult CadastrarDoacao(Doacoes doacoes)
        {
            _service.CreateDoacoes(doacoes);

            var usuario = _service.GetDoadorByID(doacoes.IDDoador);



            return RedirectToAction("AreaDoador", usuario);
        }



        public ActionResult Cadastro()
        {
            return View();
        }
        public ActionResult Cadastrar(Doador doador)
        {
            if((doador.nome == null)|| (doador.email == null) || (doador.telefone == null) || (doador.Senha == null))
            {
                ViewBag.Erro = "Erro ao criar o doador";
                return View("Cadastro");
            }

            var retorno = _service.CreateDoador(doador);

            return View("Index");
        }




    }
}
