using School.Core.Module.Person;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

namespace School.Web.Controllers
{
    public class PersonController : Controller
    {
        PersonManager personManager = new PersonManager();
        private String User = "Uadmin";

        // GET: Person
        public ActionResult Index()
        {
            var person = personManager.GetAll();
            return View(person);
        }

        // GET: Person/Details/5
        public ActionResult Details(int id)
        {
            var person = personManager.GetById(id);
            return View(person);
        }

        // GET: Person/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Person/Create
        [HttpPost]
        public ActionResult Create(Person person)
        {
            try
            {
                if (person.Type == 0)
                {
                    person.Address.Type = 2;
                }

                person.AddDate = DateTime.Now;
                person.AddUser = User;

                person.Address.AddDate = person.AddDate;
                person.Address.AddUser = User;

                personManager.Insert(person);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Person/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var person = personManager.GetById(id);

            if (person == null)
            {
                return HttpNotFound();
            }

            return View(person);
        }

        // POST: Person/Edit/5
        [HttpPost]
        public ActionResult Edit(Person person)
        {
            try
            {
                Person paux = new Person();

                if (person.AddUser == null)
                {
                    paux = personManager.GetById(person.Id);
                    person.AddDate = paux.AddDate;
                    person.AddUser = paux.AddUser;
                    person.AddressId = paux.AddressId;
                }

                if (person.Type == 0)
                {
                    person.Address.Type = 2;
                }
                else if (person.Type == 1)
                {
                    person.Address.Type = 0;
                }

                if (person.Address.Id == 0)
                {
                    person.Address = personManager.GetAddressByName(person.Address.Name, person.Address.Number);
                    person.AddressId = person.Address.Id;
                }

                person.EditDate = DateTime.Now;
                person.EditUser = User;

                person.Address.EditDate = person.EditDate;
                person.Address.EditUser = User;

                if (!ModelState.IsValid)
                {
                    return View();
                }
                else
                {
                    personManager.Update(person);
                }

                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }

        // GET: Person/Delete/5
        public ActionResult Delete(int id)
        {
            var person = personManager.GetById(id);
            return View(person);
        }

        // POST: Person/Delete/5
        [HttpPost]
        public ActionResult Delete(Person person)
        {
            try
            {
                person = personManager.GetById(person.Id);
                personManager.Delete(person);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //GET: Person/Find
        public ActionResult Find()
        {
            return View();
        }

        // POST: Person/Find/5
        [HttpPost]
        public ActionResult Find(string name)
        {
            List<Person> LstPeople = new List<Person>();

            if (!string.IsNullOrEmpty(name))
            {
                LstPeople = personManager.GetByNameParameter(name);
            }
            else
            {
                LstPeople = personManager.GetAll();
            }

            return View("List", LstPeople);
        }

        public ActionResult List()
        {
            return View();
        }

        //// GET: Contact/New
        public PartialViewResult ContactNew()
        {
            return PartialView();
        }

        // POST: Contact/New
        [HttpPost]
        [ValidateAntiForgeryToken]
        public PartialViewResult ContactNew(Contact contact)
        {
            contact.AddDate = DateTime.Now;
            contact.AddUser = User;

            if(contact.Type > 0)
            {
                contact.Type = contact.Type - 1;
            }
            
            if (ModelState.IsValid)
            {
                
            }
                       
            return PartialView();
        }

        //// GET: Contact/Edit
        [System.Web.Mvc.Route("/ContactNew/{id?}")]
        public PartialViewResult ContactEdit(int id)
        {
            Contact contact = new Contact();
            contact.Id = id;

            return PartialView(contact);
        }

        // POST: Contact/Edit
        [HttpPost]
        public PartialViewResult ContactEdit(Contact contact)
        {
            if(contact.Type.ToString() != null)
            {
                contact.Type = contact.Type - 1;
            }

            return PartialView();
        }

    }
}