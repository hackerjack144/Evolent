using EvolentAssignment.APIConsumer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace EvolentAssignment.APIConsumer.Controllers
{
    public class ContactController : Controller
    {
        public ActionResult GetAllContacts()
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/Contact/GetAllContacts");
                response.EnsureSuccessStatusCode();
                List<Models.Contact> contacts = response.Content.ReadAsAsync<List<Models.Contact>>().Result;
                ViewBag.Title = "All Contacts";
                return View(contacts);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult EditContact(int id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/Contact/GetContact?id=" + id.ToString());
            response.EnsureSuccessStatusCode();
            Models.Contact contacts = response.Content.ReadAsAsync<Models.Contact>().Result;
            ViewBag.Title = "All Contacts";
            return View(contacts);
        }

        public ActionResult Update(Models.Contact contact)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PutResponse("api/Contact/UpdateContact", contact);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("GetAllContacts");
        }

        public ActionResult Details(int id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/Contact/GetContact?id=" + id.ToString());
            response.EnsureSuccessStatusCode();
            Models.Contact contacts = response.Content.ReadAsAsync<Models.Contact>().Result;
            ViewBag.Title = "All Contacts";
            return View(contacts);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Models.Contact contact)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PostResponse("api/Contact/InsertContact", contact);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("GetAllContacts");
        }

        public ActionResult Delete(int id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.DeleteResponse("api/Contact/DeleteContact?id=" + id.ToString());
            response.EnsureSuccessStatusCode();
            return RedirectToAction("GetAllContacts");
        }
    }
}