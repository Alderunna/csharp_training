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
            GoToHomePage();
            Login(new AccountData("admin", "secret"));
            InitNewContact();
            ContactData contact = new ContactData("Alex");
            contact.Lastname = "Kov";
            FillContactForm(contact);
            SubmitContactCreation();
            ReturnToContactPage();
            //driver.FindElement(By.LinkText("Logout")).Click();
        } 
    }
}
