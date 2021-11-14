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
    public class LocalController : Controller
    {
        private readonly IService _service;
        private readonly ILogger<LocalController> _logger;
        public LocalController(ILogger<LocalController> logger,IService service)
        {
            _service = service;
        }
        // GET: LocalController
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Logar(Local obj)
        {
            var local = _service.GetLocal();

            var verifica = local.Where(x => x.Senha == obj.Senha && x.Cpf == obj.Cpf).FirstOrDefault();

            if (verifica == null)
            {
                return View("Login");
            }

            return RedirectToAction("AreaLocal", verifica);
        }
        public ActionResult Aprovar(int id, int idLocal)
        {
            var local = _service.GetLocalByID(idLocal);

             _service.DeleteDoacao(id);

            return RedirectToAction("AreaLocal", local);
        }
        public ActionResult AreaLocal(Local obj)
        {
            var local = _service.GetLocalByID(obj.ID);
            var doacoes = _service.GetDoacoes().Where(x => x.idDonatario != null).ToList();
            
            foreach (var item in doacoes)
            {
                item.LocalEntrega = _service.GetLocalByID(item.IDLocal);
                item.Donatario = _service.GetDonatarioByID(Convert.ToInt32(item.idDonatario));
            }
            var retorno = new AreaLocalViewModel();
            retorno.Doacoes = doacoes.ToList();
            retorno.Local = local;


            return View(retorno);
        }

        public ActionResult Cadastro()
        {
            return View();
        }
        public ActionResult Cadastrar(Local local)
        {
            if ((local.Cpf == null) || (local.numero == null) || (local.RazaoSocial == null) || (local.Senha == null))
            {
                ViewBag.Erro = "Erro ao criar o doador";
                return View("Cadastro");
            }

            var retorno = _service.CreateLocal(local);

            return View("Index");
        }

    }
}
