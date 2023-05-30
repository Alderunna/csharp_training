using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V113.FedCm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_project
{
    public class ProjectHelper : HelperBase
    {
        public ProjectHelper(ApplicationManager manager) : base(manager)
        {

        }

        public List<ProjectData> GetProjectList()
        {
            List<ProjectData> projects = new List<ProjectData>();
            manager.Navigator.GoToProjectPage();
            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("tr"));
            foreach (IWebElement element in elements)
            {
                projects.Add(new ProjectData(element.Text));
            }
            return projects;
        }

        

        public ProjectHelper Create(ProjectData project)
        {
            manager.Navigator.GoToProjectPage();
            InitNewProjectCreation();
            FillProjectForm(project);
            SubmitProjectCreation();
            ReturnToProjectPage();
            return this;
        }

        public ProjectHelper InitNewProjectCreation()
        {
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
            return this;
        }

        public ProjectHelper FillProjectForm(ProjectData project)
        {
            Type(By.Name("name"), project.Name);
            return this;
        }

        public ProjectHelper SubmitProjectCreation()
        {
            driver.FindElement(By.XPath("//input[@value='Добавить проект']")).Click();
            return this;
        }

        public ProjectHelper ReturnToProjectPage()
        {
            driver.FindElement(By.LinkText("Продолжить")).Click();
            return this;
        }

        public ProjectHelper Remove(int v)
        {
            manager.Navigator.GoToProjectPage();
            SelectProject(v);
            RemoveProject();
            ReturnToProjectsPage();
            return this;
        }

        public ProjectHelper SelectProject(int v)
        {
            driver.FindElement(By.XPath("//td/a")).Click();
            return this;
        }

        public ProjectHelper RemoveProject()
        {
            driver.FindElement(By.XPath("//input[@value='Удалить проект']")).Click();
            return this;
        }

        public ProjectHelper ReturnToProjectsPage()
        {
            driver.FindElement(By.XPath("//input[@value='Удалить проект']")).Click();
            return this;
        }

        public ProjectHelper CheckExistProjects()
        {
            ProjectData project = new ProjectData("fff");

            manager.Navigator.GoToProjectPage();

            if (IsElementPresent(By.XPath("//td/a")))
            {
                return this;
            }
            Create(project);
            return this;
        }

        public ProjectHelper CheckExistProjectsMantis()
        {
            //ProjectData project = new ProjectData("fff");

            manager.Navigator.GoToProjectPage();

            if (IsElementPresent(By.XPath("//td/a")))
            {
                return this;
            }

            AccountData account = new AccountData()
            {
                Username = "administrator",
                Password = "root"
            };
            ProjectData name = new ProjectData()
            {
                Name = "some text"
            };
            manager.API.CreateNewProject(account, name);
            return this;
        }
    }
}