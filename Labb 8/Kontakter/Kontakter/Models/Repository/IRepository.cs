using Kontakter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontakter
{
    public interface IRepository
    {
        void AddContact(Contact contact);

        Contact GetContact(Guid id);

        List<Contact> GetContact();

        void UpdateContact(Contact contact);

        void DeleteContact(Contact contact);

        void Save();
    }
}
