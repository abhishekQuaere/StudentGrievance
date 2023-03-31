using Dapper;
using StudentGrievance.DBContext;
using StudentGrievance.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace StudentGrievance.DbRepository
{
    public class AdminDB
    {
        DapperDbContext _dapper = new DapperDbContext();

        public T ValidateUserLogin<T>(Authority obj)
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@LoginId", obj.LoginId, DbType.String);
                dynamicParameters.Add("@Password", obj.Password, DbType.String);
                return _dapper.ExecuteGet<T>("Proc_ValidateUserLogin", dynamicParameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public List<T> GetAllGrivance<T>()
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                return _dapper.GetAll<T>("Proc_GetAllGrivance", dynamicParameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}