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
        
        public List<T> GetAllGrivance<T>(int DeptId)
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@DeptId", DeptId, DbType.Int32);
                return _dapper.GetAll<T>("Proc_GetAllGrivance", dynamicParameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public T ReplyGreivance<T>(int greivanceId,string Reply,int ReplyBy)
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@greivanceId", greivanceId, DbType.Int32);
                dynamicParameters.Add("@Reply", Reply, DbType.String);
                dynamicParameters.Add("@ReplyBy", ReplyBy, DbType.Int32);
                return _dapper.ExecuteGet<T>("Proc_ReplyGreivance", dynamicParameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}