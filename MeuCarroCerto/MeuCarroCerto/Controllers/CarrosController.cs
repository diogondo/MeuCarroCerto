using MeuCarroCerto.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeuCarroCerto.Controllers
{
    public class CarrosController : Controller
    {
        //
        // GET: /Carros/
        private EntidadesMeuCarroCertoDB db = new EntidadesMeuCarroCertoDB();
        
        public ActionResult Index()
        {
            ViewBag.marcas = new SelectList(db.t_marcas, "codigo", "nome");
            ViewBag.carrocerias = new SelectList(db.t_carrocerias, "codigo", "nome");
            ViewBag.cores = new SelectList(db.t_cores, "codigo", "nome");
            var carros = db.t_carros;
            return View(carros);
        }

        //
        // GET: /Carros/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Carros/Create

        public ActionResult Adicionar()
        {
            ViewBag.marca = new SelectList(db.t_marcas, "codigo", "nome");
            ViewBag.carrocerias = new SelectList(db.t_carrocerias, "codigo", "nome");
            ViewBag.cores = new SelectList(db.t_cores, "codigo", "nome");
            return View();
        }

        //
        // POST: /Carros/Create

        [HttpPost]
        public ActionResult Adicionar(t_carros carro)
        {
            if (ModelState.IsValid)
            {
                db.t_carros.Add(carro);
                db.SaveChanges();
                return RedirectToAction("Index", "Administrar");
            }
            return View(carro);
            }
        }
    }

