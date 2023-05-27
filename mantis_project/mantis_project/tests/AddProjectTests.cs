using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_project
{
    [TestFixture]
    public class AddProjectTests : AuthTestBase
    {

        public static IEnumerable<ProjectData> RandomProjectDataProvider()
        {
            List<ProjectData> projects = new List<ProjectData>();
            for (int i = 0; i < 1; i++)
            {
                projects.Add(new ProjectData(GenerateRandomString(30)));

            }
            return projects;
        }

        [Test, TestCaseSource("RandomProjectDataProvider")]
        public void AddProjectTest(ProjectData project)
        {

            
            List<ProjectData> oldProjects = app.Projects.GetProjectList();

            app.Projects.Create(project);

            List<ProjectData> newProjects = app.Projects.GetProjectList();


            Assert.AreEqual(oldProjects.Count + 1, newProjects.Count);
        }
    }
}
