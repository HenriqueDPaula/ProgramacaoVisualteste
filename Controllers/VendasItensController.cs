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
    public class VendasItensController : Controller
    {
        private EFContext context = new EFContext();

        // GET: Categorias
        public ActionResult Index()
        {
            return View(context.VendasItens);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VendaItem vendaItem)
        {
            context.VendasItens.Add(vendaItem);
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
            VendaItem vendaItem = context.VendasItens.Find(id);
            if (vendaItem == null)
            {
                return HttpNotFound();
            }
            return View(vendaItem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VendaItem vendaItem)
        {
            if (ModelState.IsValid)
            {
                context.Entry(vendaItem).State =
                                            EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vendaItem);
        }

        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                                HttpStatusCode.BadRequest);
            }
            VendaItem
   vendaItem = context.VendasItens.Where(c => c.VendaId == id).Include("Produtos.Venda").First();
            if (vendaItem == null)
            {
                return HttpNotFound();
            }
            return View(vendaItem);
        }

        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                                HttpStatusCode.BadRequest);
            }
            VendaItem vendaItem = context.VendasItens.
                    Find(id);
            if (vendaItem == null)
            {
                return HttpNotFound();
            }
            return View(vendaItem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            VendaItem vendaItem = context.VendasItens.
                            Find(id);
            context.VendasItens.Remove(vendaItem);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }

}
