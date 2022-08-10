using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EF;
using DAL.Interfaces;
namespace DAL.Repo
{
    public class RaiserRepo : IRepo<users1, int>
    {
 
            FundEntities db;
            public RaiserRepo(FundEntities db)
            {
                this.db = db;
            }

            public bool Create(users1 obj)
            {
                db.users1.Add(obj);
                var res = db.SaveChanges();
                return res > 0;
            }

            public bool Delete(int id)
            {
                db.users1.Remove(Get(id));
                db.SaveChanges();
                // return true;

                return true;
            }

            public List<users1> Get()
            {
                return db.users1.ToList();
            }

            public users1 Get(int id)
            {
                return db.users1.Find(id);
            }

            public bool Update(users1 obj)
            {
                var exst = db.users1.FirstOrDefault(x => x.uId == obj.uId);
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
