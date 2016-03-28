using MeuCarroCerto.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeuCarroCerto.Controllers
{
    public class CriteriosController : BaseController
    {
        private EntidadesMeuCarroCertoDB db = new EntidadesMeuCarroCertoDB();


        public ActionResult Index()
        {
            var criterios = db.t_criterios;
            return View(criterios);
            
        }

        public ActionResult Adicionar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Adicionar(t_criterios criterios)
        {
            if (ModelState.IsValid)
            {
                db.t_criterios.Add(criterios);
                db.SaveChanges();
                return RedirectToAction("Index", "Administrar");
            }
            return View(criterios);
        }
        public ActionResult Editar(int id)
        {
            t_criterios criterios = db.t_criterios.Find(id);
            return View(criterios);
        }

        [HttpPost]
        public ActionResult Editar(t_criterios criterios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(criterios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Administrar");
               // return RedirectToAction("Index");
            }
            return RedirectToAction("Index","Administrar");
        }

      //  [HttpPost]
        public ActionResult Excluir(int id)
        {
            try
            {
                t_criterios criterios = db.t_criterios.Find(id);
                db.t_criterios.Remove(criterios);
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
