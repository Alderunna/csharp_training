using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace mantis_tests
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected string baseURL;

        public RegistratioHelper Registration { get; set; }
        public FtpHelper Ftp { get; set; }

        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            baseURL = "http://localhost";
            Registration = new RegistratioHelper(this);
            Ftp = new FtpHelper(this);
        }

        ~ApplicationManager() 
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        public static ApplicationManager GetInstance() 
        {
            if (! app.IsValueCreated) 
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.driver.Url = "http://localhost/mantisbt-2.25.7/login_page.php";
                app.Value = newInstance;                
            }
            
            return app.Value;
        }


        public IWebDriver Driver 
        {
            get 
            { 
                return driver;
            }
        }

        
    }
}
