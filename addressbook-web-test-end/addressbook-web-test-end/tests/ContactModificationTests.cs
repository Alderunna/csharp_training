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

            ContactData newData = new ContactData("Alex123");
            newData.Lastname = "Kov123";

            app.Contacts.Modify(3, newData);
        }
    }
}
