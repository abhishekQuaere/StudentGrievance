using Dapper;
using StudentGrievance.DBContext;
using StudentGrievance.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracticalEvaluation.DbRepository
{
    public class AccountDb
    {
        DapperDbContext _dapper = new DapperDbContext();

        public T InsertStudentGrivance<T>(StudentGrievanceComplaint obj)
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ApplicantName", obj.ApplicantName, DbType.String);
                dynamicParameters.Add("@Email", obj.Email, DbType.String);
                dynamicParameters.Add("@File", obj.File, DbType.String);
                dynamicParameters.Add("@GrievanceCategory", obj.GrievanceCategory, DbType.String);
                dynamicParameters.Add("@GrievanceDetails", obj.GrievanceDetails, DbType.String);
                dynamicParameters.Add("@InstituteCode", obj.InstituteCode, DbType.String);
                dynamicParameters.Add("@mobile", obj.mobile, DbType.String);
                dynamicParameters.Add("@UserType", obj.UserType, DbType.String);
                dynamicParameters.Add("@Ip", obj.Ip, DbType.String);
                return _dapper.ExecuteGet<T>("Proc_InsertStudentGrivance", dynamicParameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SelectListItem> GetGrievanceCategory()
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            return _dapper.GetAll<SelectListItem>("Proc_GetGrievanceCategory", dynamicParameters);
        }

        public T CheckUserValidation<T>(Student obj)
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ApplicantName", obj.Name, DbType.String);
                dynamicParameters.Add("@Email", obj.Email, DbType.String);
                dynamicParameters.Add("@mobile", obj.mobile, DbType.String);
                return _dapper.ExecuteGet<T>("Proc_CheckUserValidation", dynamicParameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public T GetComplainetStatus<T>(ComplainedStatus obj)
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ComplainetNo", obj.ComplainetNo, DbType.String);
                dynamicParameters.Add("@Email", obj.Email, DbType.String);
                dynamicParameters.Add("@mobile", obj.mobile, DbType.String);
                return _dapper.ExecuteGet<T>("Proc_GetComplainetStatus", dynamicParameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}