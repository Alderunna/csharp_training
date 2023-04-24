using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{

    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            app.Contacts.CheckExistContacts();

            ContactData newData = new ContactData("Аме", "Ли");

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Modify(0, newData);

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts[0].Firstname = newData.Firstname;
            oldContacts[0].Lastname = newData.Lastname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
