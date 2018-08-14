using System;
using System.Collections.Generic;
using System.Linq;
using School.Core.Generic;

namespace School.Core.Module.Person
{
    public class PersonManager : Manager<Person>, IManager<Person>
    {
        public PersonManager() { }

        public List<Person> GetAll()
        {
            List<Person> LstPerson = db.Person.Include("Address").OrderBy(p => p.Name).ToList();
            
            if (LstPerson.Count > 0)
            {
                List<Contact> Contacts = new List<Contact>();

                for (int i=0; i<= LstPerson.Count-1; i++)
                {
                    var id = LstPerson[i].Id;
                    Contacts = db.Contact.Where(c => c.PersonId == id).ToList();
                    if(Contacts.Count > 0)
                    {
                        LstPerson[i].Contacts = Contacts;
                    }
                }

                return LstPerson;
            }
            else
            {
                return null;
            }
        }

        public Person GetById(int id)
        {
            Person person = new Person();
            List<Contact> Contacts = new List<Contact>();

            person = db.Person.Include("Address").Where(p => p.Id == id).FirstOrDefault();

            if ((person.Id > 0) && (!string.IsNullOrEmpty(person.Name)))
            {
                Contacts = db.Contact.Where(c => c.PersonId == id).ToList();

                if (Contacts.Count > 0)
                {
                    person.Contacts = Contacts;
                }

                return person;
            }
            else
            {
                return null;
            }
        }

        public Person GetByName(string name)
        {
            Person person = new Person();
            List<Contact> Contacts = new List<Contact>();

            person = db.Person.Include("Address").Where(p => p.Name == name).FirstOrDefault();

            if (person != null && person.Id > 0)
            {
                var id = person.Id;
                Contacts = db.Contact.Where(c => c.PersonId == id).ToList();

                if (Contacts.Count > 0)
                {
                    person.Contacts = Contacts;
                }

                return person;
            }
            else
            {
                return null;
            }
        }

        public Address GetAddressByName(string name, string number)
        {
            Address address = new Address();
            address = db.Address.Where(a => a.Name == name).Where(a2 => a2.Number == number).FirstOrDefault();

            if(address.Id.ToString() != null)
            {
                return address;
            }
            else
            {
                return null;
            }

        }

        public List<Person> GetByNameParameter(string paramter)
        {
            if (!string.IsNullOrEmpty(paramter))
            {
                List<Person> LstPerson = db.Person.Include("Address").Where(p => p.Name.Contains(paramter)).OrderBy(p => p.Name).ToList();

                if (LstPerson.Count > 0)
                {
                    return LstPerson;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                throw new Exception("Invalid paramter!");
            }
        }

        public bool Insert(Person person)
        {
            Boolean validate = false;
            string msg = null;

            if (person.Type == 0)
            {
                if((!string.IsNullOrEmpty(person.Name) && person.Name != "") &&
                   (person.Gender == 0 || person.Gender == 1) && (person.Birthdate != null) &&
                   (!string.IsNullOrEmpty(person.Document1) && person.Document1 != "") &&
                   (!string.IsNullOrEmpty(person.Document2) && person.Document2 != "") &&
                   (!string.IsNullOrEmpty(person.Address.Name)&& person.Address.Name != "") &&
                   (person.AddDate != null) && (!string.IsNullOrEmpty(person.AddUser) && person.AddUser != "")
                )
                {
                    if (this.GetByName(person.Name) == null)
                    {
                        validate = true;
                    }
                    else
                    {
                        validate = false;
                        msg = "Warning: existing record!";
                    }
                }
            }
            else if (person.Type == 1)
            {
                if ((!string.IsNullOrEmpty(person.Name) && person.Name != "") &&
                   ((!string.IsNullOrEmpty(person.SocialName) && person.SocialName != "")) &&
                   (!string.IsNullOrEmpty(person.Document1) && person.Document1 != "") &&
                   (person.AddDate != null) && (!string.IsNullOrEmpty(person.AddUser) && person.AddUser != "")
                )
                {
                    if (this.GetByName(person.Name) == null)
                    {
                        validate = true;
                    }
                    else
                    {
                        validate = false;
                        msg = "Warning: existing record!";
                    }
                }
            }
            else
            {
                validate = false;
                msg = "Invalid parameter!";
            }

            if (validate == true)
            {
                this.Create(person);

                //if(person.Contacts.Count > 0)
                //{
                //    Contact contact = null;
                //    for (int i = 0; i <= person.Contacts.Count-1; i++)
                //    {
                //        contact = new Contact();
                //        contact = person.Contacts[i];
                //        this.db.Set<Contact>().Add(contact);
                //        this.db.SaveChanges();
                //    }
                //}
                
                return true;
            }
            else
            {
                throw new Exception(msg);
            }

        }

        public bool Update(Person person)
        {
            if ((person.Id > 0) &&
               (person.Type == 0 || person.Type == 1) &&
               (!string.IsNullOrEmpty(person.Name) && person.Name != "") &&
               (!string.IsNullOrEmpty(person.Document1) && person.Document1 != "") &&
               (person.EditDate != null) && (!string.IsNullOrEmpty(person.EditUser) && person.EditUser != "")
              )
            {
                this.Change(person);
                return true;
            }
            else
            {
                throw new Exception("Warning: a field is required!");
            }
        }

        public bool Delete(Person person)
        {
            if (person.Id > 0)
            {
                if(person.Contacts.Count > 0)
                {
                    for(int i= 0; i <= person.Contacts.Count-1; i++)
                    {
                        this.db.Contact.Remove(person.Contacts[i]);
                    }
                }

                this.Remove(person);
                this.db.Address.Remove(person.Address);

                return true;
            }
            else
            {
                throw new Exception("Warning: An error occurred while trying to delete the record!");
            }
        }

        public bool InsertContact(Contact contact)
        {
            //Todo create method insert data for contact
            return false;
        }

        public bool UpdateContact(Contact contact)
        {
            //Todo create method update data for contact
            return false;
        }

    }
}