using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls.WebParts;
using BussUsuario;
using EntityUsuario;
using System.Data;
using System.Web.Management;
using System.Data.SqlClient;

namespace PracticandoPersonas.Controllers
{
    
    public class HomeController : Controller
    {
        BUsuario buss = new BUsuario();
        
        public ActionResult Index()
        {
            try
            {
                List<EUsuario> ls = buss.Obtener();
                return View(ls);
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return View(new List<EUsuario>());
            }
        }


        public ActionResult Buscar(string valor)
        {
            try
            {
                List<EUsuario> ls = buss.Buscar(valor);
                return View("Index",ls);
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return View("Index",new List<EUsuario>());
            }
        }

        [HttpGet]
        public ActionResult Agregar()
        {
            return View();
        }

        public ActionResult Agregar(EUsuario us)
        {
            try
            {
                buss.Agregar(us);
                TempData["mensaje"] = "Se Agrego Correctamente";
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return View();
            }
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            try
            {
                EUsuario us = buss.ObtenerId(id);
                return View(us);
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                throw;
            }
        }

        public ActionResult Editar(EUsuario us)
        {
            try
            {
                buss.Editar(us);
                TempData["mensaje"] = "Se edito correctamente";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return View();
            }
        }

        public ActionResult Eliminar(int id)
        {
            try
            {
                EUsuario us = buss.ObtenerId(id);
                buss.Eliminar(us);
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                throw;
            }
        }





    }

}
