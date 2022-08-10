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
    public class RaiserService
    {
        public static List<RaiserModel> Get()
        {
            var data = DataAccessFactory.GetRaiserDataAccess().Get();
            var d = new List<RaiserModel>();
            foreach (var item in data)
            {
                d.Add(new RaiserModel()
                {
                    uId = item.uId,
                    uName = item.uName,
                    uEmail = item.uEmail,
                    uGender = item.uGender,
                    uPassword = item.uPassword,
                    uUserName = item.uUserName
                });
            }
            return d;
        }

        public static RaiserModel GetOnly(int id)
        {
            var item = DataAccessFactory.GetRaiserDataAccess().Get(id);
            var d = new RaiserModel()
            {
                uId = item.uId,
                uName = item.uName,
                uEmail = item.uEmail,
                uGender = item.uGender,
                uPassword = item.uPassword,
                uUserName = item.uUserName
            };
            return d;

        }

        public static bool Create(RaiserModel item)
        {
            var user = new users1()
            {
                uId = item.uId,
                uName = item.uName,
                uEmail = item.uEmail,
                uGender = item.uGender,
                uPassword = item.uPassword,
                uUserName = item.uUserName,
            };
            return DataAccessFactory.GetRaiserDataAccess().Create(user);
        }

        //public static object Update(EUser2Model st)
        //{
        //    throw new NotImplementedException();
        //}

        public static bool Update(RaiserModel users)
        {
            //return DataAccessFactory.GetUsers1DataAccess().Update(users);
            var config = new MapperConfiguration(c => c.CreateMap<RaiserModel, users1>());
            var mapper = new Mapper(config);
            var data = mapper.Map<users1>(users);
            return DataAccessFactory.GetRaiserDataAccess().Update(data);
        }

        public static bool Delete(int id)
        {
            // throw new NotImplementedException();
            return DataAccessFactory.GetRaiserDataAccess().Delete(id);
            //return item;

            //var d1 = new EUser2Model() { dnId = item.dnId };
            // return d1;
        }
    }
}
