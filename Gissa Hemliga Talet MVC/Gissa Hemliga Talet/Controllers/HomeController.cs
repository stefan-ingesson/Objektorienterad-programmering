using Gissa_Hemliga_Talet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gissa_Hemliga_Talet.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = GetList();
            return View(model);
        }
        // GET: SessionTimedOut
        public ActionResult SessionTimedOut()
        {
            return View();
        }
        // GET: NewPage
        public ActionResult GetNewPage()
        {
            GetList().Initialize();
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(int? number)                                  // Kontrollerar värdena
        {
            if (Session.IsNewSession)
            {
                return View("SessionTimedOut");
            }

            var model = GetList();

            if (!number.HasValue)
            {
                ModelState.AddModelError("number", "Fel! Du måste ange ett heltal");
            }
            else if (number < 1 || number > 100)
            {
                ModelState.AddModelError("number", "Talet måste vara mellan 1 och 100");
            }
        
            else
            {
                model.MakeGuess(number.Value);
            }
            return View(model);
        }

        private SecretNumber GetList()                                      // Lagrar gissningar 
        {
            var guessList = Session["storedGuesses"] as SecretNumber;

            if (guessList == null)
            {
                guessList = new SecretNumber();
                Session["storedGuesses"] = guessList;
            }
            return guessList;
        }
    }
}
// Göra imorgon.... Byta plats på saker och ting