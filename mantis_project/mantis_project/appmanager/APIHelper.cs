using mantis_project.Mantis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_project
{
    public class APIHelper : HelperBase
    {
        public APIHelper(ApplicationManager manager) : base(manager) { }

        public void CreateNewProject(AccountData account, ProjectData project)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            
            
            Mantis.ProjectData projectdata = new Mantis.ProjectData();
            projectdata.name = project.Name;

            client.mc_project_add(account.Username, account.Password, projectdata);
        }
    }
}
