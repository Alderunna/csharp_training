using NUnit.Framework;
using OpenQA.Selenium.DevTools.V113.FedCm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_project

{
    [TestFixture]
    public class RemoveProjectTests : AuthTestBase
    {

       
        [Test]
        public void RemoveProjectTest()
        {
            app.Projects.CheckExistProjectsMantis();

            List<ProjectData> oldProjects = app.Projects.GetProjectList();
          
            app.Projects.Remove(0);

            List<ProjectData> newProjects = app.Projects.GetProjectList();


            Assert.AreEqual(oldProjects.Count - 1, newProjects.Count);
        }

        [Test]
        public void RemoveProjectTestMantis()
        {
            app.Projects.CheckExistProjectsMantis();

            AccountData account = new AccountData()
            {
                Username = "administrator",
                Password = "root"
            };

            List<ProjectData> oldProjects = app.API.GetListProjects(account);

            app.Projects.Remove(0);

            List<ProjectData> newProjects = app.API.GetListProjects(account);


            Assert.AreEqual(oldProjects.Count - 1, newProjects.Count);
        }
    }
}
