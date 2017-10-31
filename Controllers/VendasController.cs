using HenriquedePaula.Contexts;
using HenriquedePaula.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace HenriquedePaula.Controllers
{
    public class VendasController : Controller
    {
        private EFContext context = new EFContext();

        // GET: Categorias
        public ActionResult Index()
        {
            return View(context.Vendas.OrderBy(c =>
c.CompradorNome));
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Venda venda)
        {
            context.Vendas.Add(venda);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new
                                HttpStatusCodeResult(
                                HttpStatusCode.BadRequest);
            }
            Venda venda = context.Vendas.Find(id);
            if (venda == null)
            {
                return HttpNotFound();
            }
            return View(venda);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Venda venda)
        {
            if (ModelState.IsValid)
            {
                context.Entry(venda).State =
                                            EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(venda);
        }

        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                                HttpStatusCode.BadRequest);
            }
            Venda
   venda = context.Vendas.Where(c => c.Codigo == id).Include("Produtos.VendaItem").First();
            if (venda == null)
            {
                return HttpNotFound();
            }
            return View(venda);
        }

        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                                HttpStatusCode.BadRequest);
            }
            Venda venda = context.Vendas.
                    Find(id);
            if (venda == null)
            {
                return HttpNotFound();
            }
            return View(venda);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            Venda venda = context.Vendas.
                            Find(id);
            context.Vendas.Remove(venda);
            context.SaveChanges();
            TempData["Message"] = "Venda	" + venda.CompradorNome.ToUpper() + "	foi	removido";
            return RedirectToAction("Index");
        }

    }

}
