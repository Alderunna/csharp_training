using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoIt;

namespace addressbook_tests_autoit
{
    public class ApplicationManager
    {

        private AutoItX aux;
        private GroupHelper groupHelper;
        public ApplicationManager() 
        {
            aux = new AutoItX();
            groupHelper = new GroupHelper(this);
        }

        public void Stop()
        {

        }

        public AutoItX Aux
        {
            get
            {
                return aux;
            }
        }

        public GroupHelper Groups
        {
            get
            {
                return groupHelper;
            }
        }
    }
}
