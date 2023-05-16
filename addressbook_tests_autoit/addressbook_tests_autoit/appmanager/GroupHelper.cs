using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;


namespace addressbook_tests_autoit
{
    public class GroupHelper : HelperBase
    {
        public GroupHelper(ApplicationManager manager) : base(manager) { }

        public void Add(GroupData newGroup)
        {
            throw new NotImplementedException();
        }

        public List<GroupData> GetGroupList()
        {
            throw new NotImplementedException();
        }
    }
}