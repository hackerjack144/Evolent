using AutoMapper;
using EvolentAssignment.DataAccess;
using EvolentAssignment.WebAPI.Mappper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace EvolentAssignment.WebAPI.Controllers
{
    public class ContactController : ApiController
    {
        [HttpGet]
        public JsonResult<List<Models.ContactModel>> GetAllContacts()
        {
            EntityMapper<Contact, Models.ContactModel> mapObj = new EntityMapper<Contact, Models.ContactModel>();
            List<Contact> contactList = DataAccessLayer.GetAllContacts();
            List<Models.ContactModel> contacts = new List<Models.ContactModel>();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Contact, Models.ContactModel>());
            var mapper = new Mapper(config);
            foreach (var item in contactList)
            {
                contacts.Add(mapper.Map<Models.ContactModel>(item));
            }
            return Json<List<Models.ContactModel>>(contacts);
        }

        [HttpGet]
        public JsonResult<Models.ContactModel> GetContact(int id)
        {
            EntityMapper<Contact, Models.ContactModel> mapObj = new EntityMapper<Contact, Models.ContactModel>();
            Contact dalContact = DataAccessLayer.GetContact(id);
            Models.ContactModel contacts = new Models.ContactModel();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Contact, Models.ContactModel>());
            var mapper = new Mapper(config);
            contacts = mapper.Map<Models.ContactModel>(dalContact);
            return Json<Models.ContactModel>(contacts);
        }

        [HttpPost]
        public bool InsertContact(Models.ContactModel contact)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                EntityMapper<Models.ContactModel, DataAccess.Contact> mapObj = new EntityMapper<Models.ContactModel, DataAccess.Contact>();
                DataAccess.Contact contactObj = new DataAccess.Contact();
                var config = new MapperConfiguration(cfg => cfg.CreateMap<Models.ContactModel, Contact>());
                var mapper = new Mapper(config);
                contactObj = mapper.Map<Contact>(contact);
                status = DataAccessLayer.InsertContact(contactObj);
            }
            return status;

        }

        [HttpPut]
        public bool UpdateContact(Models.ContactModel contact)
        {
            EntityMapper<Models.ContactModel, DataAccess.Contact> mapObj = new EntityMapper<Models.ContactModel, DataAccess.Contact>();
            DataAccess.Contact contactObj = new DataAccess.Contact();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Models.ContactModel, Contact>());
            var mapper = new Mapper(config);
            contactObj = mapper.Map<Contact>(contact);
            var status = DataAccessLayer.UpdateContact(contactObj);
            return status;

        }
        [HttpDelete]
        public bool DeleteContact(int id)
        {
            var status = DataAccessLayer.DeleteContact(id);
            return status;
        }
    }
}
