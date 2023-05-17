using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_tests_autoit
{
    [TestFixture]

    public class GroupRemovalTests : TestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            app.Groups.CheckExistGroups();


            int oldGroups = app.Groups.GetGroupCount();            

            app.Groups.Remove();

            int newGroups = app.Groups.GetGroupCount();
            oldGroups--;

            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
