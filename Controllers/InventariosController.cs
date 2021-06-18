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
    public class InventariosController : Controller
    {
        private PanaderiaEntities db = new PanaderiaEntities();

        // GET: Inventarios
        public ActionResult Index()
        {
            if (Singleton.Instance.id == 0)
            {
                TempData["errorMessage"] = "Debe iniciar sesión antes de continuar";
                return RedirectToAction("Index", "Home", null);
            }
            else
            {
            return View(db.Inventario.ToList());
            }

        }

        // GET: Inventarios/Details/5
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
                Inventario inventario = db.Inventario.Find(id);
                if (inventario == null)
                {
                    return HttpNotFound();
                }
                return View(inventario);
            }

        }

        // GET: Inventarios/Create
        public ActionResult Create()
        {
            if (Singleton.Instance.id == 0)
            {
                TempData["errorMessage"] = "Debe iniciar sesión antes de continuar";
                return RedirectToAction("Index", "Home", null);
            }
            else
            {
            return View();
            }

        }

        // POST: Inventarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Inventario inventario)
        {
            if (Singleton.Instance.id == 0)
            {
                TempData["errorMessage"] = "Debe iniciar sesión antes de continuar";
                return RedirectToAction("Index", "Home", null);
            }
            else
            {
                /*if (ModelState.IsValid)
                {*/
                    db.Inventario.Add(inventario);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                /*}

                return View(inventario);*/
            }

        }

        // GET: Inventarios/Edit/5
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
                Inventario inventario = db.Inventario.Find(id);
                if (inventario == null)
                {
                    return HttpNotFound();
                }
                return View(inventario);
            }

        }

        // POST: Inventarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Inventario,Nombre,Precio,Cantidad,Descripcion")] Inventario inventario)
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
                    db.Entry(inventario).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(inventario);
            }

        }

        // GET: Inventarios/Delete/5
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
                Inventario inventario = db.Inventario.Find(id);
                if (inventario == null)
                {
                    return HttpNotFound();
                }
                return View(inventario);
            }

        }

        // POST: Inventarios/Delete/5
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
                Inventario inventario = db.Inventario.Find(id);
                db.Inventario.Remove(inventario);
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
