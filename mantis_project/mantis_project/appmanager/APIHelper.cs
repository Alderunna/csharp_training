using mantis_project.Mantis;
using OpenQA.Selenium;
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

        public List<ProjectData> GetListProjects(AccountData account)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            List<ProjectData> projects = new List<ProjectData>();
            Mantis.ProjectData[] mantisProjects = client.mc_projects_get_user_accessible(account.Username, account.Password);
            foreach (Mantis.ProjectData project in mantisProjects)
            {
                projects.Add(new ProjectData(project.name));
            }

            return projects;
        }
    }
}
