using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_project
{
    public class TestBase
    {
        public static bool PERFORM_LONG_UI_CHEKS = true;
        protected ApplicationManager app;

        [TestFixtureSetUp]
        public void SetupApplicationManager()
        {
            app = ApplicationManager.GetInstance();
        }

        public static Random rnd = new Random();

        public static string GenerateRandomString(int max)
        {

            int l = Convert.ToInt32(rnd.NextDouble() * max);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < l; i++)
            {
                builder.Append(Convert.ToChar(65 + Convert.ToInt32(rnd.NextDouble() * 25)));
            }
            return builder.ToString();
        }
    }
}
