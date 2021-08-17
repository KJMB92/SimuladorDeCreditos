using System;
using System.Web.Mvc;
using Credit.Web.Models;

namespace Credit.Web.Controllers
{
    public class CreditsController : Controller
    {
        // GET: Credits
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Simulator()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Simulator(CreditSimulator creditSimulator)
        {

            try
            {
                if (!ModelState.IsValid)
                    return View(creditSimulator);

                if (creditSimulator.ValorPrestamo < 0)
                    throw new Exception("El valor de prestamo debe ser mayor a 0");
                if (creditSimulator.ValorPrestamo > 100000000)
                    throw new Exception("El valor de prestamo NO debe ser mayor a 100 mil millones");
                var valorPrestamo = creditSimulator.ValorPrestamo;

                if (creditSimulator.PlazoMeses < 0)
                    throw new Exception("El plazo de meses debe ser mayor a 12");
                if (creditSimulator.PlazoMeses > 36)
                    throw new Exception("El plazo de meses no debe ser mayor a 36 meses");
                var plazoMeses = creditSimulator.PlazoMeses;

                var tasaMesVencida = creditSimulator.TasaMesVencida;

                if (creditSimulator.ValorSeguro < 10000)
                    throw new Exception("El valor de seguro debe ser mayor a 10 mil");
                if (creditSimulator.ValorSeguro > 1000000)
                    throw new Exception("El valor de seguro NO debe ser mayor a 1 millon");
                var valorSeguro = creditSimulator.ValorSeguro;
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex.Message);
            }

            var nroCuotas = creditSimulator.PlazoMeses;
            var vlrPrestamo = creditSimulator.ValorPrestamo;
            var tasa = creditSimulator.TasaMesVencida / 100;
            var vlrSeguro =  creditSimulator.ValorSeguro;

            var cuotaMensual = vlrPrestamo * ((tasa * (Math.Pow((1 + tasa), nroCuotas))) / ((Math.Pow((1 + tasa), nroCuotas)) - 1));

            var abonoInteres = 0;
            var abonoCapital = 0;
            var nuevoSaldo = 0;

            ViewBag.nroCuotas = nroCuotas;
            ViewBag.valorPrestamo = vlrPrestamo;
            ViewBag.tasa = tasa;
            ViewBag.vlrSeguro = vlrSeguro;
            ViewBag.abonoInteres = abonoInteres;
            ViewBag.cuotaMensual = cuotaMensual;
            ViewBag.abonoCapital = abonoCapital;
            ViewBag.nuevoSaldo = nuevoSaldo;


            return View();
        }
    }
}