using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EF;
using DAL.Interfaces;

namespace DAL.Repo
{
    public class EmpRepo : IRepo<emp, int, bool>
    {

        FundEntities db;
        public EmpRepo(FundEntities db)
        {
            this.db = db;
        }

        public bool Create(emp obj)
        {
            db.emps.Add(obj);
            var res = db.SaveChanges();
            return res > 0;
        }

        public bool Delete(int id)
        {
            db.emps.Remove(Get(id));
            db.SaveChanges();
            // return true;

            return true;
        }

        public List<emp> Get()
        {
            return db.emps.ToList();
        }

        public emp Get(int id)
        {
            return db.emps.Find(id);
        }

        public bool Update(emp obj)
        {
            var exst = db.emps.FirstOrDefault(x => x.eId == obj.eId);
            if (exst != null)
            {
                db.Entry(exst).CurrentValues.SetValues(obj);
                db.SaveChanges();
                return true;
            }
            return false;
        }

    }
}
