using Aplicacao;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ClienteAplicacao appCliente;

        public ClienteController()
        {
            appCliente = ClienteAplicacaoConstrutor.ClienteAplicacaoADO();
        }

        public ActionResult Index()
        {
            var listaDeClientes = appCliente.ListarTodos();
            return View(listaDeClientes);
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                appCliente.Salvar(cliente);
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        public ActionResult Editar(string id)
        {
            var cliente = appCliente.ListaPorId(id);
            if(cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                appCliente.Salvar(cliente);
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        public ActionResult Detalhes(string id)
        {
            var cliente = appCliente.ListaPorId(id);
            if(cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        public ActionResult Excluir(string id)
        {
            var cliente = appCliente.ListaPorId(id);
            if(cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public ActionResult ExcluirConfirmado(string id)
        {
            var cliente = appCliente.ListaPorId(id);
            appCliente.Excluir(cliente);
            return RedirectToAction("Index");
        }

        public JsonResult verificaCpfUnico(string cpf)
        {
            //Constrói uma collection de CPFs já cadastrados
            //Encontrar melhor jeito de encontrar CPF já cadastrado
            //Pensar na performance
            var cpfs = appCliente.ListarTodos().ToList();
            var existeCpf = false;
            foreach(var cliente in cpfs)
            {
                if(cliente.cpf == cpf)
                {
                    existeCpf = true;
                }
            }

            return Json(existeCpf, JsonRequestBehavior.AllowGet);
        }
    }
}