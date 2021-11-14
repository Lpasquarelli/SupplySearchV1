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
    public class DonatarioController : Controller
    {
        private readonly IService _service;
        private readonly ILogger<DonatarioController> _logger;
        public DonatarioController(ILogger<DonatarioController> logger, IService service)
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
        public ActionResult Logar(Donatario obj)
        {
            var donatario = _service.GetDonatario();

            var verifica = donatario.Where(x => x.Senha == obj.Senha && x.email == obj.email).FirstOrDefault();

            if (verifica == null)
            {
                return View("Login");
            }

            return RedirectToAction("AreaDonatario", verifica);
        }
        public ActionResult AreaDonatario(Donatario obj)
        {
            var retorno = new AreaDonatarioViewModel();
            retorno.doacoes = _service.GetDoacoes().ToList();

            foreach(var item in retorno.doacoes)
            {
                item.LocalEntrega = _service.GetLocalByID(item.IDLocal);
            }
            retorno.donatario = obj;

            return View(retorno);
        }

        public ActionResult RetirarDoacao(int id, int idDonatario)
        {
            var doacao = _service.GetDoacoesByIDDoacao(id);

            doacao.idDonatario = idDonatario;

            var upd = _service.UpdateDoacao(doacao);

            var retorno = _service.GetDonatarioByID(idDonatario);

            return RedirectToAction("AreaDonatario", retorno);
        }

        public ActionResult Cadastro()
        {
            return View();
        }
        public ActionResult Cadastrar(Donatario obj)
        {
            if ((obj.nome == null) || (obj.email == null) || (obj.telefone == null) || (obj.Senha == null))
            {
                ViewBag.Erro = "Erro ao criar o doador";
                return View("Cadastro");
            }

            var retorno = _service.CreateDonatario(obj);

            return View("Index");
        }

    }
}
