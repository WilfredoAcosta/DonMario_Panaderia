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
    public class FacturasController : Controller
    {
        private PanaderiaEntities db = new PanaderiaEntities();
        Factura_InevtarioModel modelfi = new Factura_InevtarioModel();

        // GET: Facturas
        public ActionResult Index()
        {
            if (Singleton.Instance.id == 0)
            {
                TempData["errorMessage"] = "Debe iniciar sesión antes de continuar";
                return RedirectToAction("Index", "Home", null);
            }
            else
            {
                var factura = db.Factura.Include(f => f.Usuario);
                return View(factura.ToList());
            }
            
        }

        // GET: Facturas/Details/5
        public ActionResult Details(int id)
        {
            if (Singleton.Instance.id == 0)
            {
                TempData["errorMessage"] = "Debe iniciar sesión antes de continuar";
                return RedirectToAction("Index", "Home", null);
            }
            else
            {
                var obtenerDetalles = modelfi.Detalles(id);
                return View(obtenerDetalles);
            }
            
        }

        // GET: Facturas/Create
        public ActionResult Create()
        {
            if (Singleton.Instance.id == 0)
            {
                TempData["errorMessage"] = "Debe iniciar sesión antes de continuar";
                return RedirectToAction("Index", "Home", null);
            }
            else
            {
                ViewBag.ID_User = new SelectList(db.Usuario, "ID_User", "Usuario1");
                return View();
            }
            
        }

        // POST: Facturas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Factura,fecha,Total,Cliente,ID_User")] Factura factura)
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
                    db.Factura.Add(factura);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.ID_User = new SelectList(db.Usuario, "ID_User", "Usuario1", factura.ID_User);
                return View(factura);
            }
            
        }

        // GET: Facturas/Edit/5
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
                Factura factura = db.Factura.Find(id);
                if (factura == null)
                {
                    return HttpNotFound();
                }
                ViewBag.ID_User = new SelectList(db.Usuario, "ID_User", "Usuario1", factura.ID_User);
                return View(factura);
            }
            
        }

        // POST: Facturas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Factura,fecha,Total,Cliente,ID_User")] Factura factura)
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
                    db.Entry(factura).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.ID_User = new SelectList(db.Usuario, "ID_User", "Usuario1", factura.ID_User);
                return View(factura);
            }
            
        }

        // GET: Facturas/Delete/5
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
                Factura factura = db.Factura.Find(id);
                if (factura == null)
                {
                    return HttpNotFound();
                }
                return View(factura);
            }
            
        }

        // POST: Facturas/Delete/5
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
                Factura factura = db.Factura.Find(id);
                db.Factura.Remove(factura);
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
