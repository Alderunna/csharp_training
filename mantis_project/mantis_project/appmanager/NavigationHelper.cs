using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_project
{
    public class NavigationHelper : HelperBase
    {

        private string baseURL;

        public NavigationHelper(ApplicationManager manager, string baseURL) : base(manager)
        {
            this.baseURL = baseURL;
        }
        public void GoToLoginPage()
        {
            if (driver.Url == baseURL + "/mantisbt-2.25.7/login_page.php")
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL + "/mantisbt-2.25.7/login_page.php");
        }

        public void GoToGroupsPage()
        {
            if (driver.Url == baseURL + "/addressbook/group.php"
                && IsElementPresent(By.Name("new")))
            {
                return;
            }
            driver.FindElement(By.LinkText("groups")).Click();
        }
    }
}

