using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{

    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            app.Groups.CheckExistGroups();

            GroupData newData = new GroupData("zzz");
            newData.Header = null;
            newData.Footer = null;

            app.Groups.Modify(1, newData);
        }
    }
}
