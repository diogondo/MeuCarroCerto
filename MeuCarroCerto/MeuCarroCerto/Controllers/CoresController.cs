using MeuCarroCerto.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeuCarroCerto.Controllers
{
    public class CoresController : Controller
    {
        //
        // GET: /Cores/
        private EntidadesMeuCarroCertoDB db = new EntidadesMeuCarroCertoDB();
        public ActionResult Index()
        {
            var cores = db.t_cores;
            return View(cores);
        }
        public ActionResult Adicionar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Adicionar(t_cores cores)
        {
            if (ModelState.IsValid)
            {
                db.t_cores.Add(cores);
                db.SaveChanges();
                return RedirectToAction("Index", "Administrar");
            }
            return RedirectToAction("Index", "Administrar");
        }

        public ActionResult Editar(int id)
        {
            t_cores cores = db.t_cores.Find(id);
            return View(cores);
        }

        [HttpPost]
        public ActionResult Editar(t_cores cores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Administrar");
            }
            return RedirectToAction("Index", "Administrar");
        }
        public ActionResult Excluir(int id)
        {
            try
            {
                t_cores cores = db.t_cores.Find(id);
                db.t_cores.Remove(cores);
                db.SaveChanges();
                return RedirectToAction("Index", "Administrar");
            }
            catch
            {
                return RedirectToAction("Index", "Administrar");
            }
        }


    }
}
