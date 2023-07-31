using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class PacienteController : Controller
    {
        // GET: Paciente
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Result resultPaciente = BL.Paciente.GetAll();

            if (resultPaciente.Correct)
            {
                return View(resultPaciente);
            }
            else
            {
                resultPaciente.Message = "ERROR";
                return View(resultPaciente);
            }
        }

        [HttpGet]
        public ActionResult Form(int? idPaciente)
        {
            ML.Result resultTiposSangre = BL.TipoSangre.GetAll();

            ML.Paciente paciente = new ML.Paciente();

            paciente.TipoSangre = new ML.TipoSangre();

            paciente.TipoSangre.TiposSangre = resultTiposSangre.Objects;

            if (idPaciente == null)
            {
                ViewBag.Titulo = "Agregar";
                return View(paciente);
            }
            else
            {
                ML.Result result = BL.Paciente.GetById(idPaciente.Value);
                if (result.Correct)
                {
                    paciente = (ML.Paciente)result.Object;
                    paciente.TipoSangre.TiposSangre = resultTiposSangre.Objects;

                    ViewBag.Titulo = "Actualizar";
                    paciente.TipoSangre.TiposSangre = resultTiposSangre.Objects;
                    return View(paciente);
                }
                else
                {
                    ViewBag.Titulo = "ERROR";
                    ViewBag.Message = result.Message;
                    return View("Modal");
                }
            }
        }

        [HttpPost]
        public ActionResult Form(ML.Paciente paciente)
        {

            if (paciente.IdPaciente == 0)
            {
                ML.Result result = BL.Paciente.Add(paciente);

                if (result.Correct)
                {
                    ViewBag.Titulo = "Registro Exitoso";
                    ViewBag.Message = "Los datos del paciente se agregaron de manera correcta";
                    return View("Modal");
                }
                else
                {
                    ViewBag.Titulo = "ERROR";
                    ViewBag.Message = "Ocurrio un error al intentar agregar los datos del paciente";
                    return View("Modal");
                }
            }
            else
            {
                ML.Result result = BL.Paciente.Update(paciente);
                if (result.Correct)
                {
                    ViewBag.Titulo = "Modificacion Exitosa";
                    ViewBag.Message = "Los datos del paciente se modificacion de manera correcta";
                    return View("Modal");
                }
                else
                {
                    ViewBag.Titulo = "ERROR";
                    ViewBag.Message = "Ocurrio un error al intentar modificar los datos del paciente";
                    return View("Modal");
                }
            }
        }

        [HttpGet]
        public ActionResult Delete(int idPaciente)
        {
            ML.Result result = BL.Paciente.Delete(idPaciente);

            if (result.Correct)
            {
                ViewBag.Titulo = "Exitoso";
                ViewBag.Message = "El registro del paciente se elimino de manera correcta";
                return View("Modal");
            }
            else
            {
                ViewBag.Titulo = "ERROR";
                ViewBag.Message = "El registro del paciente no se elimino ";
                return View("Modal");
            }
        }
    }
}