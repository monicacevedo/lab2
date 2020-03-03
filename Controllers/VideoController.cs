﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using MVCLaboratorio.Utilerias;
using System.Data;

namespace MVCLaboratorio.Controllers
{
    public class VideoController : Controller
    {
        //
        // GET: /Video/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Edit()
        {
            return View();
        }
        public ActionResult Delete()
        {
            return View();
        }
        //POST Procesa los datos ingresados al formulario
        [HttpPost]
        public ActionResult Create(int idVideo,
            string titulo,
            int repro,
            string url)
        {
            List<SqlParameter> Parametros = new List<SqlParameter>();
            Parametros.Add(new SqlParameter("@idVideo", idVideo));
            Parametros.Add(new SqlParameter("@titulo", titulo));
            Parametros.Add(new SqlParameter("@repro", repro));
            Parametros.Add(new SqlParameter("@url", url));
            BaseHelper.ejecutarSentencia("sp_agregar_video", CommandType.StoredProcedure, parametros);

            return RedirectToAction("Index", "Home");


        }


        [HttpPost]
        public ActionResult Edite(int idVideo,
            string titulo,
            int repro,
            string url)
        {
            List<SqlParameter> Parametros = new List<SqlParameter>();
            Parametros.Add(new SqlParameter("@idVideo", idVideo));
            Parametros.Add(new SqlParameter("@titulo", titulo));
            Parametros.Add(new SqlParameter("@repro", repro));
            Parametros.Add(new SqlParameter("@url", url));
            BaseHelper.ejecutarSentencia("sp_video_actualizar", CommandType.StoredProcedure, parametros);

            return RedirectToAction("Index", "Home");

        }
        [HttpPost]
        public ActionResult Delete(int idVideo)
        {
            List<SqlParameter> Parametros = new List<SqlParameter>();
            Parametros.Add(new SqlParameter("@idVideo", idVideo));

            BaseHelper.ejecutarSentencia("sp_video_eliminar", CommandType.StoredProcedure, parametros);

            return RedirectToAction("Index", "Home");
        }

        public List<SqlParameter> parametros { get; set; }
    }
}
