using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MeuCarroCerto.Models;
using System.Data;
using System.Data.Entity;

namespace MeuCarroCerto.Controllers
{
    public class MarcasController : BaseController
    {
        private EntidadesMeuCarroCertoDB db = new EntidadesMeuCarroCertoDB();

        public ActionResult Index()
        {
            var marcas = db.t_marcas;
            return View(marcas);
        }

        public ActionResult Adicionar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Adicionar(t_marcas marcas)
        {
            if (ModelState.IsValid)
            {
                db.t_marcas.Add(marcas);
                db.SaveChanges();
                return RedirectToAction("Index", "Administrar");
            }
            return RedirectToAction("Index", "Administrar");
        }

        public ActionResult Editar(int id)
        {
            t_marcas cidades = db.t_marcas.Find(id);
            return View(cidades);
        }

        [HttpPost]
        public ActionResult Editar(t_marcas marcas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(marcas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Administrar");
            }
            return RedirectToAction("Index", "Administrar");
        }

        public ActionResult Excluir(int id)
        {
            try
            {
                t_marcas marcas = db.t_marcas.Find(id);
                db.t_marcas.Remove(marcas);
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
