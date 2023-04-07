using OpenQA.Selenium;

namespace WebAddressbookTests
{
    public class HelperBase
    {
        protected ApplicationManager manager;
        protected IWebDriver driver;

        public HelperBase(ApplicationManager manager) { 
            this.manager = manager;
            driver = manager.Driver;
        
        }
    }
}