using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    [TestFixture]

    public class ContactInformationTests : AuthTestBase
    {
        [Test]
        public void TestContactInformation() 
        {
            ContactData fromTable = app.Contacts.GetContactInformationFromTable(0);
            ContactData fromForm = app.Contacts.GetContactInformationFromForm(0);

            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
        }
    }

    public class ContactDetailsInformationTests : AuthTestBase
    {
        [Test]
        public void TestContactDetailsInformation()
        {
            string fromDetails = app.Contacts.GetContactInformationFromDetails(0);
            ContactData fromFormForDetails = app.Contacts.GetContactInformationFromFormForDetails(0);

            Assert.AreEqual(fromDetails, fromFormForDetails.Block);
        }
    }
}
