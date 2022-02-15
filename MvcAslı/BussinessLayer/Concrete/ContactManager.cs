using BussinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Concrete
{
    public class ContactManager : IContactService
    {
        IContactDAL _contactDAL;

        public ContactManager(IContactDAL contactDAL)
        {
            _contactDAL = contactDAL;
        }

        public void ContactAdd(Contact contact)
        {
            _contactDAL.İnsert(contact);
        }

        public void ContactDelete(Contact contact)
        {
            _contactDAL.Delete(contact);
        }

        public void ContactUpdate(Contact contact)
        {
            _contactDAL.Delete(contact);
        }

        public Contact GetById(int id)
        {
         return   _contactDAL.Get(x=>x.ContactID == id);
        }

        public List<Contact> GetList()
        {
           return _contactDAL.list();
        }
    }
}
