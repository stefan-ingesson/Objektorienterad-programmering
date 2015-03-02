using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Kontakter.Models.Repository
{
    public class XmlRepository : IRepository
    {
        private static readonly string PhysicalPath;
        private XDocument _document;

        private XDocument Document
        {
            get
            {
                return _document ?? (_document = XDocument.Load(PhysicalPath)); // Är den lika med null kommer värdet returneras, är det skilt från null så...
            }
        }

        static XmlRepository()
        {
            PhysicalPath = Path.Combine(
                AppDomain.CurrentDomain.GetData("DataDirectory").ToString(),
                "contacts.xml");
        }

        public List<Contact> GetContact()
        {
           
            var contact = Document.Descendants("contact").Select(element => new Contact      // Måste vara exakt samma namn som min XML fil
            {
                Id = Guid.Parse(element.Attribute("Id").Value),                         
                FirstName = element.Element("FirstName").Value,
                LastName = element.Element("LastName").Value,
                Email = element.Element("Email").Value,
                
            })
            .OrderBy(x => x.FirstName).ToList();
            return contact;
        }
        public void AddContact(Contact contact)
        {
                var element = new XElement("contact",                                                // Lägger till i min XML-fil
                new XAttribute("Id", contact.Id.ToString()),
                new XElement("FirstName", contact.FirstName),
                new XElement("LastName", contact.LastName),
                new XElement("Email", contact.Email)
                
                );
            Document.Root.Add(element);
        }

        public void UpdateContact(Contact contact)
        {
            if (contact == null)
            {
                throw new ArgumentNullException("contact");
            }
            var elements = Document.Descendants("contact").Where(element => Guid.Parse(element.Attribute("Id").Value) == contact.Id)           
            .FirstOrDefault();

            if (elements != null)
            {
                elements.Element("FirstName").Value = contact.FirstName;
                elements.Element("LastName").Value = contact.LastName;
                elements.Element("Email").Value = contact.Email;
                
            }
        }

        public Contact GetContact(Guid id)
        {
            var contact = Document.Descendants("contact").Where(element => Guid.Parse(element.Attribute("Id").Value) == id)
                .Select(element => new Contact                                                
            {
                Id = Guid.Parse(element.Attribute("Id").Value),                         
                FirstName = element.Element("FirstName").Value,
               LastName = element.Element("LastName").Value,
                Email = element.Element("Email").Value,
                
            })
                //.OrderBy(x => x.Name).ToList();
            .FirstOrDefault();
            return contact;
        }

        public void Save()
        {
            Document.Save(PhysicalPath);
        }     

        public void DeleteContact(Contact contact)
        {
            var elementToDelete = Document.Descendants("contact")
                .Where(element => Guid.Parse(element.Attribute("Id").Value) == contact.Id)
                .FirstOrDefault();

            if (elementToDelete !=null)
            {
                elementToDelete.Remove();
            }
    }
}}
