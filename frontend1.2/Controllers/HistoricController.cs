using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppMeteo.Models;
using frontend1._2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication7.Models;

namespace frontend1._2.Controllers
{
    public class HistoricController : Controller
    {
        private readonly EstacionsContext _context;

        List<Estacions> llistaHistoric = new List<Estacions>();
        List<Ubicacio> llistaUbicacions = new List<Ubicacio>();

        public HistoricController()
        {
            var optionsBuilder = new DbContextOptionsBuilder<EstacionsContext>();

            optionsBuilder.UseMySql("server=hermes;port=3306;database=estacions;uid=estacio;password=estacio");

            _context = new EstacionsContext(optionsBuilder.Options);
        }

        [HttpGet]
        [Route("Historic")]
        public ActionResult Historic(string idEstacio)
        {
            ViewBag.idEstacio = idEstacio;
            Estacions estacio = _context.Estacio.Where(x => x.idEstacio == idEstacio).FirstOrDefault();
            ViewBag.estacio = estacio;
            return View(estacio);
        }


    }
}
