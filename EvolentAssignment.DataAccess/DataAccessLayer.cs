using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolentAssignment.DataAccess
{
    public class DataAccessLayer
    {
        static EvolentAssignmentEntities DbContext;

        static DataAccessLayer()
        {
            DbContext = new EvolentAssignmentEntities();
        }

        public static List<Contact> GetAllContacts()
        {
            return DbContext.Contacts.ToList();
        }
        public static Contact GetContact(int contactId)
        {
            return DbContext.Contacts.Where(p => p.ID == contactId).FirstOrDefault();
        }
        public static bool InsertContact(Contact contact)
        {
            bool status;
            try
            {
                DbContext.Contacts.Add(contact);
                DbContext.SaveChanges();
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
        public static bool UpdateContact(Contact contact)
        {
            bool status;
            try
            {
                Contact contacts = DbContext.Contacts.Where(p => p.ID == contact.ID).FirstOrDefault();
                if (contacts != null)
                {
                    contacts.FirstName = contact.FirstName;
                    contacts.LastName = contact.LastName;
                    contacts.Email = contact.Email;
                    contacts.PhoneNumber = contact.PhoneNumber;
                    contacts.Status = contact.Status;
                    DbContext.SaveChanges();
                }
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
        public static bool DeleteContact(int id)
        {
            bool status;
            try
            {
                Contact contacts = DbContext.Contacts.Where(p => p.ID == id).FirstOrDefault();
                if (contacts != null)
                {
                    // this is just to make it inactive
                    contacts.Status = false;
                    DbContext.SaveChanges();

                    // testing for deleting from db
                    //DbContext.Contacts.Remove(contacts);
                    //DbContext.SaveChanges();
                }
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
    }
}
