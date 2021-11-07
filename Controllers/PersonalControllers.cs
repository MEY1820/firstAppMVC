using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using firstApp.Models;

namespace firstApp.Controllers
{
    public class PersonalController : Controller
    {
        public IActionResult Index()
        {
            Personal personal = new Personal();
            personal.Nombres = " Meylin Nohely ";
            personal.Apellidos = " Reyes Medina ";
            personal.Edad = 18;
            personal.CorreoElectronico = " meylinreyess20@gmail.com ";
            personal.Telefono = 60129605;
            personal.Direccion = " Col.Buena Vista - Corinto,Morazán ";
            
            return View(personal);
        }
    }
}