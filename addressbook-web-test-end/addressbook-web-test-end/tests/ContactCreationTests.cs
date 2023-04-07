using System;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {

        [Test]
        public void ContactCreationTest()
        {         
            ContactData contact = new ContactData("Alex");
            contact.Lastname = "Kov";

            app.Contacts.Create(contact);
            //driver.FindElement(By.LinkText("Logout")).Click();
        } 
    }
}
