using BLL.BOs;
using DAL;
using DAL.Repo;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace BLL.Services
{
    public class DonorService
    {
        public static List<DonorModel> Get()
        {
            var data = DataAccessFactory.GetDonorDataAccess().Get();
            var d = new List<DonorModel>();
            foreach (var item in data)
            {
                d.Add(new DonorModel()
                {
                    dnId = item.dnId,
                    dnName = item.dnName,
                    dnEmail = item.dnEmail,
                    dnGender = item.dnGender,
                    dnPassword = item.dnPassword,
                    dnUserName = item.dnUserName,

                });
            }
            return d;
        }

        public static DonorModel GetOnly(int id)
        {
            var item = DataAccessFactory.GetDonorDataAccess().Get(id);
            var d = new DonorModel()
            {
                dnId = item.dnId,
                dnName = item.dnName,
                dnEmail = item.dnEmail,
                dnGender = item.dnGender,
                dnPassword = item.dnPassword,
                dnUserName = item.dnUserName,
            };
            return d;

        }

        public static bool Create(DonorModel item)
        {
            var user = new Tbl_Donor()
            {
                dnId = item.dnId,
                dnName = item.dnName,
                dnEmail = item.dnEmail,
                dnGender = item.dnGender,
                dnPassword = item.dnPassword,
                dnUserName = item.dnUserName,
            };
            return DataAccessFactory.GetDonorDataAccess().Create(user);
        }

     

        public static bool Update(DonorModel users)
        {
            var config = new MapperConfiguration(c => c.CreateMap<DonorModel, Tbl_Donor>());
            var mapper = new Mapper(config);
            var data = mapper.Map<Tbl_Donor>(users);
           return DataAccessFactory.GetDonorDataAccess().Update(data);
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.GetDonorDataAccess().Delete(id);

        }
    }
}

