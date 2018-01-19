using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebAppRestaurante.DAL;
using WebAppRestaurante.Models;

namespace WebAppRestaurante.Controllers
{
    public class PratosController : Controller
    {
        private RestauranteContext db = new RestauranteContext();

        // GET: Pratos
        public ActionResult Index()
        {
            var pratos = db.Pratos.Include(p => p.Restaurante);
            return View(pratos.ToList());
        }

        // GET: Pratos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prato prato = db.Pratos.Find(id);
            if (prato == null)
            {
                return HttpNotFound();
            }
            return View(prato);
        }

        // GET: Pratos/Create
        public ActionResult Create()
        {
            ViewBag.RestauranteID = new SelectList(db.Restaurantes, "RestauranteID", "Descricao");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PratoID,Descricao,RestauranteID,Preco")] Prato prato)
        {
            if (ModelState.IsValid)
            {
                db.Pratos.Add(prato);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RestauranteID = new SelectList(db.Restaurantes, "RestauranteID", "Descricao", prato.RestauranteID);
            return View(prato);
        }

        // GET: Pratos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prato prato = db.Pratos.Find(id);
            if (prato == null)
            {
                return HttpNotFound();
            }
            ViewBag.RestauranteID = new SelectList(db.Restaurantes, "RestauranteID", "Descricao", prato.RestauranteID);
            return View(prato);
        }

        // POST: Pratos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PratoID,Descricao,RestauranteID,Preco")] Prato prato)
        {
            if (ModelState.IsValid)
            {
                //prato.Preco.ToString().f

                db.Entry(prato).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RestauranteID = new SelectList(db.Restaurantes, "RestauranteID", "Descricao", prato.RestauranteID);
            return View(prato);
        }

        // GET: Pratos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prato prato = db.Pratos.Find(id);
            if (prato == null)
            {
                return HttpNotFound();
            }
            return View(prato);
        }

        // POST: Pratos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Prato prato = db.Pratos.Find(id);
            db.Pratos.Remove(prato);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
