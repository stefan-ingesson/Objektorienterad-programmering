using Kontakter.Models;
using Kontakter.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Kontakter.Controllers
{
    public class HomeController : Controller
    {
  //private XmlRepository _repository = new XmlRepository();
        private readonly IRepository _repository;

        public HomeController()
            : this(new XmlRepository())
        {

        }
       
        public HomeController(IRepository repository)
        {
            _repository = repository;
        }

        // GET: Contacts
        public ActionResult Index()  // Index vy som visar kontakterna som ska synas på skärmen
        {
            return View(_repository.GetContact());
        }

        //Get: Contact/Create
        public ActionResult Create()
        {
            return View();
        }

        //Post: Contact/Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "firstName, lastName, Email")]Contact contact) // Bind berättar att det bara är vissa specifika fält jag är ute efter
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repository.AddContact(contact);
                    _repository.Save();
                    TempData["success"] = string.Format("Tillägg till kontaktboken lyckades! {0} {1} lades till i din kontaktbok", contact.FirstName, contact.LastName);
                    return RedirectToAction("Index");                       // När dokumentet är sparat, ta tillbaka mig till Indexvyn
                }
            }
            catch (Exception)
            {

                TempData["error"] = "Misslyckades med att spara, försök igen!";
            }
            return View(contact);                                       // Det här returneras ifall modelstate inte är valid
        }

        [HttpGet]
        public ActionResult Edit(Guid? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(418, "Kontakten hittades inte. Den kan ha ändrats eller tagits bort");
            }

            var contact = _repository.GetContact(id.Value);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }


        [HttpPost]                                                                  // Metod för att spara
        [ActionName("Edit")]
        public ActionResult Edit_POST(Guid id)                                      // Post-Redirect-GET (PRG) PATTERN
        {
            var contactToUpdate = _repository.GetContact(id);
            if (contactToUpdate == null)
            {
                return HttpNotFound("Kontakten hittades inte. Den kan ha ändrats eller tagits bort");
            }
            if (TryUpdateModel(contactToUpdate, string.Empty, new string[] { "firstName", "lastName", "Email" })) // Begränsar de fält jag redigerar i en specifik vy/formulär
            {
                try
                {
                    _repository.UpdateContact(contactToUpdate);
                    _repository.Save();
                    TempData["success"] = String.Format("Uppdatering av kontakten {0} lyckades!", contactToUpdate.FirstName);
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    TempData["error"] = "Misslyckades spara ändringarna. Försök igen!";
                }
            } 
            return View(contactToUpdate);
        }

        [HttpGet]
        public ActionResult Delete(Guid? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(418, "Kontakten hittades inte. Den kan nyligen ändrats eller tagits bort");
            }

            var contact = _repository.GetContact(id.Value);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            try
            {
                var contact = new Contact { Id = id };
                _repository.DeleteContact(contact);
                _repository.Save();

                TempData["success"] = "Borttagning av kontakt lyckades!";
            }
            catch (Exception)
            {
                TempData["error"] = "Misslyckades ta bort kontakten";
                RedirectToAction("Delete", new { id = id });                
            }
            return RedirectToAction("Index");
        }
    }
}
