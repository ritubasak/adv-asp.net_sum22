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
    public class EmpService
    {
        public static List<EmpModel> Get()
        {
            var data = DataAccessFactory.GetempDataAccess().Get();
            var d = new List<EmpModel>();
            foreach (var item in data)
            {
                d.Add(new EmpModel()
                {
                    eId = item.eId,
                    eName = item.eName,
                    eUserName = item.eUserName,
                    eEmail = item.eEmail,
                    eGender = item.eGender,
                    ePassword = item.ePassword

                });
            }
            return d;
        }

        public static EmpModel GetOnly(int id)
        {
            var item = DataAccessFactory.GetempDataAccess().Get(id);
            var d = new EmpModel()
            {
                eId = item.eId,
                eName = item.eName,
                eUserName = item.eUserName,
                eEmail = item.eEmail,
                eGender = item.eGender,
                ePassword = item.ePassword
            };
            return d;

        }

        public static bool Create(EmpModel item)
        {
            var user = new emp()
            {
                eId = item.eId,
                eName = item.eName,
                eUserName = item.eUserName,
                eEmail = item.eEmail,
                eGender = item.eGender,
                ePassword = item.ePassword
            };
            return DataAccessFactory.GetempDataAccess().Create(user);
        }

        //public static object Update(EUser2Model st)
        //{
        //    throw new NotImplementedException();
        //}

        public static bool Update(EmpModel user)
        {
            //var users = new employee()
            //{
            //    eId = user.eId,
            //    eName = user.eName,
            //    eUserName = user.eUserName,
            //    eEmail = user.eEmail,
            //    eGender = user.eGender,
            //    ePassword = user.ePassword
            //};
            //return DataAccessFactory.GetEmployeeDataAccess().Update(users);


            var config = new MapperConfiguration(c => c.CreateMap<EmpModel, emp>());
            var mapper = new Mapper(config);
            var data = mapper.Map<emp>(user);
            return DataAccessFactory.GetempDataAccess().Update(data);


            //var data = Mapper.Map<employee,EmployeeModel>(user);
            //return DataAccessFactory.GetEmployeeDataAccess().Update(data);
        }

        public static bool Delete(int id)
        {
            // throw new NotImplementedException();
            return DataAccessFactory.GetempDataAccess().Delete(id);
            //return item;

            //var d1 = new EUser2Model() { dnId = item.dnId };
            // return d1;
        }
    }
}
