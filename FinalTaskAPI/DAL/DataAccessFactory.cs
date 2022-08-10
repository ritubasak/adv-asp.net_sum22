
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EF;
using DAL.Interfaces;
using DAL.Repo;


namespace DAL
{
    public class DataAccessFactory
    {
        static FundEntities db = new FundEntities(); 
        public static IRepo<Tbl_Donor, int> GetDonorDataAccess()
        {
            return new DonorRepo(db);
        }


        public static IRepo<emp, int> GetempDataAccess()
        {
            return new EmpRepo(db);
        }

        public static IRepo<users1, int> GetRaiserDataAccess()
        {
            return new RaiserRepo(db);
        }

        //public static IRepo<employee, int> GetEmployeeDataAccess()
        //{
        //    return new EmployeeRepo(db);
        //}

    }
}
