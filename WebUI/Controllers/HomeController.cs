using Aplicacao;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProdutoAplicacao appProduto;

        public HomeController()
        {
            appProduto = ProdutoAplicacaoConstrutor.ProdutoAplicacaoADO();
        }

        public ActionResult Index()
        {
            var listaDeProdutos = appProduto.ListarTodos();
            return View(listaDeProdutos);
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(Produto produto)
        {
            if (ModelState.IsValid)
            {
                appProduto.Salvar(produto);
                return RedirectToAction("Index");
            }
            return View(produto);
        }

        public ActionResult Editar(string id)
        {
            var produto = appProduto.ListarPorId(id);
            if(produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Produto produto)
        {
            if (ModelState.IsValid)
            {
                appProduto.Salvar(produto);
                return RedirectToAction("Index");
            }
            return View(produto);
        }

        public ActionResult Detalhes(string id)
        {
            var produto = appProduto.ListarPorId(id);

            if(produto == null)
            {
                return HttpNotFound();
            }

            return View(produto);
        }

        public ActionResult Excluir(string id)
        {
            var produto = appProduto.ListarPorId(id);
            if (produto == null)
            {
                return HttpNotFound();
            }

            return View(produto);
        }

        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public ActionResult ExcluirConfirmado(string id)
        {
            var produto = appProduto.ListarPorId(id);
            appProduto.Excluir(produto);
            return RedirectToAction("Index");
        }

        
    }
}