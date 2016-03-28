using MeuCarroCerto.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeuCarroCerto.Controllers
{
    public class CarroceriasController : BaseController
    {
        //
        // GET: /Carrocerias/
        private EntidadesMeuCarroCertoDB db = new EntidadesMeuCarroCertoDB();

        public ActionResult Index()
        {
            var carroceria = db.t_carrocerias;
            return View(carroceria);

        }
        public ActionResult Adicionar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Adicionar(t_carrocerias carrocerias)
        {
            if (ModelState.IsValid)
            {
                db.t_carrocerias.Add(carrocerias);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(carrocerias);
        }


        public ActionResult Editar(int id)
        {
            t_carrocerias carroceria = db.t_carrocerias.Find(id);
            return View(carroceria);
        }

        [HttpPost]
        public ActionResult Editar(t_carrocerias carroceria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carroceria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(carroceria);
        }
        public ActionResult Excluir(int id)
        {
            try
            {
                t_carrocerias carrocerias = db.t_carrocerias.Find(id);
                db.t_carrocerias.Remove(carrocerias);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }


    }
}
