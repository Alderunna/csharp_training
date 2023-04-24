using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests

{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) : base(manager)
        {       
            
        }
        public ContactHelper Create(ContactData contact)
        {
            InitNewContact();
            FillContactForm(contact);
            SubmitContactCreation();
            ReturnToContactPage();
            return this;
        }
        public ContactHelper Modify(int v, ContactData newData)
        {
            manager.Navigator.GoToContactsPage();
            InitContactModification(v);
            FillContactForm(newData);
            SubmitGroupModification();
            ReturnToContactPage();
            return this;
        }
        public ContactHelper Remove(int v)
        {
            manager.Navigator.GoToContactsPage();
            SelectContact(v);
            RemoveContact();
            return this;
        }

        public ContactHelper CheckExistContacts()
        {
            ContactData contact = new ContactData("Аля", "Улю");

            manager.Navigator.GoToContactsPage();

            if (IsElementPresent(By.Name("selected[]")))
            {
                return this;
            }
            Create(contact);
            return this;
        }

        private ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            driver.FindElement(By.CssSelector("div.msgbox"));
            return this;
        }
        private ContactHelper SelectContact(int v)
        {
            driver.FindElement(By.Name("selected[]")).Click();
            return this;
        }
        public ContactHelper InitNewContact()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }
        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("lastname"), contact.Lastname);
            return this;
        }
        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[21]")).Click();
            return this;
        }
        public ContactHelper ReturnToContactPage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
            driver.Navigate().GoToUrl("http://localhost/addressbook/index.php");
            return this;
        }
        public ContactHelper InitContactModification(int index)
        {
            driver.FindElement(By.XPath("//img[@alt='Edit']")).Click();
            return this;
        }
        public ContactHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public List<ContactData> GetContactList()
        {
            List<ContactData> contacts = new List<ContactData>();
            manager.Navigator.GoToContactsPage();
            ICollection<IWebElement> elements = driver.FindElements(By.Name("entry"));
            foreach (IWebElement element in elements)
            {
                IList<IWebElement> cells = element.FindElements(By.TagName("td"));
                contacts.Add(new ContactData(cells[2].Text, cells[1].Text));
            }
            return contacts;
        }
    }
}
