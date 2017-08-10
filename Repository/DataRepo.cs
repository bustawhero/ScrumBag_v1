using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer;
using BugProj.Data;
using BugProj.Models;
using System.Data.SqlClient;

namespace BugProj.Repositories
{
    public class DataRepo
    {
        private BugProjContext _db;
        //private int _companyid;

        public DataRepo(BugProjContext db )
        {
            this._db = db;
            
        }

        public List<ProjTasks> GetProjectTasks(int bugID)
        {
          
          var tasks =  _db.ProjTasks.Where(p=> p.BugId == bugID).ToList();
          return tasks;

        }

        public List<ProjTasks> GetProjectClientTask(int clientId)
        {
            var clientp = new SqlParameter("@clientID", clientId);
            List<ProjTasks> lst = _db.ProjTasks
            .FromSql("TasksbyClient @clientID", clientp)
            .ToList();

            return lst;

        }

        public async Task<Company> GetCompanyAsync(int companyid)
        {
            var comp = await _db.Company.Where(c=> c.Id == companyid).FirstOrDefaultAsync();

            comp.Client = await _db.Clients.Where((c)=> c.CompanyId == companyid).ToListAsync();

            return comp;
        }

        public Company GetCompany(int companyid)
        {
            var comp =  _db.Company.Where(c=> c.Id == companyid).FirstOrDefault();

            //comp.Client =  _db.Clients.Where((c)=> c.CompanyId == companyid).ToList();

            return comp;
        }

        public void UpdateCompanyData(Company company)
        { 
            try{
                _db.Update(company);
                _db.SaveChanges();
            }
            catch(Exception e)
            {
                string message = e.Message;
                string newM = message;
            }
            
        }

        public IEnumerable<Clients> GetClientData(int compid )
        {
           var clients = _db.Clients.Where(cl=> cl.CompanyId == compid).ToList();

           return clients;
        }

        public IEnumerable<ProjectViewModel> GetProjectData(int clientID)
        {
            var projs = _db.Projects.Where(proj=> proj.ClientId == clientID ).ToList();

            List<ProjectViewModel> projlist = new List<ProjectViewModel>();

            foreach(Projects p in projs)
            {
                int count =  _db.Bugs.Where((bug)=> bug.ExtractId == p.Id).Count();

                projlist.Add( new ProjectViewModel{ Id = p.Id, Name = p.Name, Descr = p.Descr, ClientId = p.ClientId
                , CreateDate = p.CreateDate, BugCount = count });
            }

            return projlist;
        }

        public IEnumerable<BugViewModel> GetListofBugs(int projectid)
        {

            List<BugViewModel> blist = new List<BugViewModel>();
            try
            {
                var bugs = _db.Bugs.Where((b)=> b.ExtractId == projectid).ToList();
                
                foreach(Bugs b in bugs)
                {
                    int count =  _db.ProjTasks.Where((p)=> p.Complete == false && p.BugId == b.Id).Count();

                    blist.Add( new BugViewModel{ Id = b.Id, Name = b.Name, ProjType = b.ProjType, BugStatus = b.BugStatus
                    , BackLog = b.BackLog, OpenTaskCount = count });

                }
                return blist;
            }
            catch(Exception e)
            {
              string m =   e.Message;
              string message = m;
              return blist;
            }

        }

        public Bugs GetBugData(int bugID)
        {
            var bug = _db.Bugs.Where(b=> b.Id == bugID).FirstOrDefault();

            return bug;
        }

        public void AddProject(Projects proj)
        {
            _db.Add(proj);
            _db.SaveChanges();
        }

        public void AddProjects(Projects[] multproj)
        {
            _db.AddRange(multproj);
            _db.SaveChanges();
        }

        public void AddBug(Bugs bug)
        {
            _db.Add(bug);
            _db.SaveChanges();
        }

        public void AddProjects(Bugs[] multbug)
        {
            _db.AddRange(multbug);
            _db.SaveChanges();
        }

    }
}