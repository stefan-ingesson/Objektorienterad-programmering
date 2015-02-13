using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class IndexController : Controller
    {
        // GET: Index
        public ActionResult Index()
        {
            var list = GetList();
            return View(list);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // VIKTIG
        public ActionResult Index(Nullable<int> number) // BINDER MODELLEN // FELHANTERING...MÅSTE MÖJLIGGÖRA ATT DEN KAN FÅ VÄRDET NULL OM INTE SIFRROR SKRIVS IN...
        {

            if (Session.IsNewSession)
            {
                // det här skapar nytt objekt efter en timeout
                return View("SessionError"); // Skapa nytt i Views... SessionError.cs
            }

            var list = GetList();
                                                    // ANtingen via int? eller (Nullable<int>number)
            if (!number.HasValue)                   // Om numret har ett värde...
            {
                //var list = GetList();             // Kallar på metoden Getlist, sedan lägger den till det tillagda numret till listan

                ModelState.AddModelError("", "Ange ett tal");         // 
                // är allt ok, vi kan gå vidare...
                return View();
            }
            else
            {
                list.Add(number.Value);
            }


            return View(list);
        }

        //Meto för att visa gammal lista
        private List<int> GetList()
        {
            var list = Session["list"] as List<int>; //Finns inte det här, blir det null tillbaka... Isof skapas en ny lista via if-satsen. Finns det redan en, så returneras det ändå. EN LISTA SKAPAS ALLTID
            if (list == null)
            {
                list = new List<int>();
                Session["list"] = list;
            }
            return list;
        }
    }
}