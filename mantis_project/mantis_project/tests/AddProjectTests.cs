using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_project
{
    
        [TestFixture]
        public class AddProjectTests : TestBase
        {

        public static IEnumerable<ProjectData> RandomGroupDataProvider()
        {
            List<ProjectData> projects = new List<ProjectData>();
            for (int i = 0; i < 5; i++)
            {
                projects.Add(new ProjectData(GenerateRandomString(30)));
                
            }
            return projects;
        }

        [Test]
            public void AddProjectTest()
            {
                List<ProjectData> oldGroups = app.Projects.GetGroupList();

            ProjectData newGroup = new ProjectData()
                {
                    Name = "test"
                };

                app.Groups.Add(newGroup);

                List<ProjectData> newGroups = app.Groups.GetGroupList();
                oldGroups.Add(newGroup);
                oldGroups.Sort();
                newGroups.Sort();


                Assert.AreEqual(oldGroups, newGroups);
            }
        }
    
}
