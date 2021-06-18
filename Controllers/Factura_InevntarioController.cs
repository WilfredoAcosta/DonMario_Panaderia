using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PanaderiaDonMario.Models;

namespace PanaderiaDonMario.Controllers
{
    public class Factura_InevntarioController : Controller
    {
        private PanaderiaEntities db = new PanaderiaEntities();

        // GET: Factura_Inevntario
        public ActionResult Index()
        {
            if (Singleton.Instance.id == 0)
            {
                TempData["errorMessage"] = "Debe iniciar sesión antes de continuar";
                return RedirectToAction("Index", "Home", null);
            }
            else
            {
                var factura_Inevntario = db.Factura_Inevntario.Include(f => f.Factura).Include(f => f.Inventario);
                return View(factura_Inevntario.ToList());
            }

        }

        // GET: Factura_Inevntario/Details/5
        public ActionResult Details(int? id)
        {
            if (Singleton.Instance.id == 0)
            {
                TempData["errorMessage"] = "Debe iniciar sesión antes de continuar";
                return RedirectToAction("Index", "Home", null);
            }
            else
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Factura_Inevntario factura_Inevntario = db.Factura_Inevntario.Find(id);
                if (factura_Inevntario == null)
                {
                    return HttpNotFound();
                }
                return View(factura_Inevntario);
            }

        }

        // GET: Factura_Inevntario/Create
        public ActionResult Create()
        {
            if (Singleton.Instance.id == 0)
            {
                TempData["errorMessage"] = "Debe iniciar sesión antes de continuar";
                return RedirectToAction("Index", "Home", null);
            }
            else
            {
                ViewBag.ID_Factura = new SelectList(db.Factura, "ID_Factura", "Cliente");
                ViewBag.ID_Inventario = new SelectList(db.Inventario, "ID_Inventario", "Nombre");
                return View();
            }

        }

        // POST: Factura_Inevntario/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_FACTURAL,ID_Inventario,ID_Factura,Cantidad")] Factura_Inevntario factura_Inevntario)
        {
            if (Singleton.Instance.id == 0)
            {
                TempData["errorMessage"] = "Debe iniciar sesión antes de continuar";
                return RedirectToAction("Index", "Home", null);
            }
            else
            {
                if (ModelState.IsValid)
                {
                    db.Factura_Inevntario.Add(factura_Inevntario);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.ID_Factura = new SelectList(db.Factura, "ID_Factura", "Cliente", factura_Inevntario.ID_Factura);
                ViewBag.ID_Inventario = new SelectList(db.Inventario, "ID_Inventario", "Nombre", factura_Inevntario.ID_Inventario);
                return View(factura_Inevntario);
            }

        }

        // GET: Factura_Inevntario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Singleton.Instance.id == 0)
            {
                TempData["errorMessage"] = "Debe iniciar sesión antes de continuar";
                return RedirectToAction("Index", "Home", null);
            }
            else
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Factura_Inevntario factura_Inevntario = db.Factura_Inevntario.Find(id);
                if (factura_Inevntario == null)
                {
                    return HttpNotFound();
                }
                ViewBag.ID_Factura = new SelectList(db.Factura, "ID_Factura", "Cliente", factura_Inevntario.ID_Factura);
                ViewBag.ID_Inventario = new SelectList(db.Inventario, "ID_Inventario", "Nombre", factura_Inevntario.ID_Inventario);
                return View(factura_Inevntario);
            }

        }

        // POST: Factura_Inevntario/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_FACTURAL,ID_Inventario,ID_Factura,Cantidad")] Factura_Inevntario factura_Inevntario)
        {
            if (Singleton.Instance.id == 0)
            {
                TempData["errorMessage"] = "Debe iniciar sesión antes de continuar";
                return RedirectToAction("Index", "Home", null);
            }
            else
            {
                if (ModelState.IsValid)
                {
                    db.Entry(factura_Inevntario).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.ID_Factura = new SelectList(db.Factura, "ID_Factura", "Cliente", factura_Inevntario.ID_Factura);
                ViewBag.ID_Inventario = new SelectList(db.Inventario, "ID_Inventario", "Nombre", factura_Inevntario.ID_Inventario);
                return View(factura_Inevntario);
            }

        }

        // GET: Factura_Inevntario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Singleton.Instance.id == 0)
            {
                TempData["errorMessage"] = "Debe iniciar sesión antes de continuar";
                return RedirectToAction("Index", "Home", null);
            }
            else
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Factura_Inevntario factura_Inevntario = db.Factura_Inevntario.Find(id);
                if (factura_Inevntario == null)
                {
                    return HttpNotFound();
                }
                return View(factura_Inevntario);
            }

        }

        // POST: Factura_Inevntario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Singleton.Instance.id == 0)
            {
                TempData["errorMessage"] = "Debe iniciar sesión antes de continuar";
                return RedirectToAction("Index", "Home", null);
            }
            else
            {
                Factura_Inevntario factura_Inevntario = db.Factura_Inevntario.Find(id);
                db.Factura_Inevntario.Remove(factura_Inevntario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

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
