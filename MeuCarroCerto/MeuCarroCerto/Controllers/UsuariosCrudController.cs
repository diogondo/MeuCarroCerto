using MeuCarroCerto.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeuCarroCerto.Controllers
{
    public class UsuariosCrudController : BaseController
    {
        //
        // GET: /UsuariosCrud/

        private EntidadesMeuCarroCertoDB db = new EntidadesMeuCarroCertoDB();


        public ActionResult Index()
        {
            var usuario = db.t_usuarios;
            return View(usuario);


        }

           public ActionResult Adicionar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Adicionar(t_usuarios usuarios)
        {
            if (ModelState.IsValid)
            {
                db.t_usuarios.Add(usuarios);
                db.SaveChanges();
                return RedirectToAction("Index", "Administrar");
            }
            return RedirectToAction("Index", "Administrar");
        }
        public ActionResult Editar(int id)
        {
            t_usuarios usuarios = db.t_usuarios.Find(id);
            return View(usuarios);
        }

        [HttpPost]
        public ActionResult Editar(t_usuarios usuarios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuarios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Administrar");
            }
            return RedirectToAction("Index", "Administrar");
        }

//        [HttpPost]
        public ActionResult Excluir(int id)
        {
            try
            {
                t_usuarios usuarios = db.t_usuarios.Find(id);
                db.t_usuarios.Remove(usuarios);
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
