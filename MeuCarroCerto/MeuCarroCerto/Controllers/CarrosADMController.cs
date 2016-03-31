using MeuCarroCerto.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeuCarroCerto.Controllers
{
    public class CarrosADMController : Controller
    {
        private EntidadesMeuCarroCertoDB db = new EntidadesMeuCarroCertoDB();
        public ActionResult Index()
        {
            var carros = db.t_carros;
            return View(carros);
        }
        public ActionResult Adicionar()
        {
            ViewBag.marca = new SelectList(db.t_marcas, "codigo", "nome");
            ViewBag.carrocerias = new SelectList(db.t_carrocerias, "codigo", "nome");
            ViewBag.cor = new SelectList(db.t_cores, "codigo", "nome");
            return View();
        }
        [HttpPost]
        public ActionResult Adicionar(t_carros carros)
        {
            if (ModelState.IsValid)
            {
                db.t_carros.Add(carros);
                db.SaveChanges();
                return RedirectToAction("Index", "Administrar");
            }
            return RedirectToAction("Index", "Administrar");
        }

        public ActionResult Editar(int id)
        {
            ViewBag.marca = new SelectList(db.t_marcas, "codigo", "nome");
            ViewBag.carrocerias = new SelectList(db.t_carrocerias, "codigo", "nome");
            ViewBag.cor = new SelectList(db.t_cores, "codigo", "nome");
            t_carros carros = db.t_carros.Find(id);
            return View(carros);
        }

        [HttpPost]
        public ActionResult Editar(t_carros carros)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carros).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Administrar");
            }
            return RedirectToAction("Index", "Administrar");
        }
        public ActionResult Excluir(int id)
        {
            try
            {
                t_carros carros = db.t_carros.Find(id);
                db.t_carros.Remove(carros);
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
