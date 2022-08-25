using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EF;
using DAL.Interfaces;

    namespace DAL.Repo
{
    public class DonorRepo : IRepo<Tbl_Donor, int, bool>, IAuth<Tbl_Donor>
    {
        FundEntities db;
        public DonorRepo(FundEntities db)
        {
            this.db = db;
        }
        public Tbl_Donor Authenticate(string username, string password)
        {
            return db.Tbl_Donor.FirstOrDefault(u => u.dnUserName.Equals(username)
            && u.dnPassword.Equals(password));

        }
        public bool Create(Tbl_Donor obj)
        {
            db.Tbl_Donor.Add(obj);
            var res = db.SaveChanges();
            return res > 0;
        }

        public bool Delete(int id)
        {
            db.Tbl_Donor.Remove(Get(id));
            db.SaveChanges();
           

            return true;
        }

        public List<Tbl_Donor> Get()
        {
            return db.Tbl_Donor.ToList();
        }

        public Tbl_Donor Get(int id)
        {
            return db.Tbl_Donor.Find(id);
        }

        public bool Update(Tbl_Donor obj)
        {
            var exst = db.Tbl_Donor.FirstOrDefault(x => x.dnId == obj.dnId);
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
