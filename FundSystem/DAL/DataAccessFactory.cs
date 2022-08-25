
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
        public static IRepo<Tbl_Donor, int, bool> GetDonorDataAccess()
        {
            return new DonorRepo(db);
        }


        public static IRepo<emp, int, bool> GetempDataAccess()
        {
            return new EmpRepo(db);
        }

        public static IRepo<users1, int, bool> GetRaiserDataAccess()
        {
            return new RaiserRepo(db);
        }

        public static IAuth<Tbl_Donor> GetAuthDataAccess()
        {
            return new DonorRepo(db);
        }
        public static IRepo<Token, string, Token> GetTokenDataAccess()
        {
            return new TokenRepo(db);
        }

    }
}
