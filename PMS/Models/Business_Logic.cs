using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using PMS.Controllers;
using System.Reflection.Emit;

namespace PMS.Models
{
    public class Business_Logic
    {
        public string objConnectionString;
        private IConfiguration Configuration;
        public Business_Logic(IConfiguration _configuration)
        {
            Configuration = _configuration;
            objConnectionString = Configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
        }

    
        public DataSet CategorySearch(int is_active, int spmode)
        {
            try
            {
                System.Data.DataSet ds = new System.Data.DataSet();
                Database db = new Microsoft.Practices.EnterpriseLibrary.Data.Sql.SqlDatabase(objConnectionString);
                DbCommand cmd = db.GetStoredProcCommand("Proc_Category_Search");
                db.AddInParameter(cmd, "@IsActive", DbType.Int32, is_active);                
                db.AddInParameter(cmd, "@spmode", DbType.Int32, spmode);
                DataSet dataSet = new DataSet();
                dataSet = db.ExecuteDataSet(cmd);

                return dataSet;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public DataSet Insert_Product(string ProductName , int Product_Price, int Product_Quantity , int IsActive , string Created_By, int spmode)
        {
            try
            {
                System.Data.DataSet ds = new System.Data.DataSet();
                Database db = new Microsoft.Practices.EnterpriseLibrary.Data.Sql.SqlDatabase(objConnectionString);
                DbCommand cmd = db.GetStoredProcCommand("Proc_Insert_Product");
                db.AddInParameter(cmd, "@ProductName", DbType.String, ProductName);
                db.AddInParameter(cmd, "@Product_Price", DbType.Int32, Product_Price);
                db.AddInParameter(cmd, "@Product_Quantity", DbType.Int32, Product_Quantity);
                db.AddInParameter(cmd, "@IsActive", DbType.Int32, IsActive);
                db.AddInParameter(cmd, "@Created_By", DbType.String, Created_By);
                db.AddInParameter(cmd, "@spmode", DbType.Int32, spmode);
                DataSet dataSet = new DataSet();
                dataSet = db.ExecuteDataSet(cmd);

                return dataSet;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public DataSet GetProduct()
        {
            try
            {
                System.Data.DataSet ds = new System.Data.DataSet();
                Database db = new Microsoft.Practices.EnterpriseLibrary.Data.Sql.SqlDatabase(objConnectionString);
                DbCommand cmd = db.GetStoredProcCommand("Get_All_Products");
             
                db.AddInParameter(cmd, "@IsActive", DbType.Int32, 1);
                db.AddInParameter(cmd, "@spmode", DbType.Int32, 0);
                DataSet dataSet = new DataSet();
                dataSet = db.ExecuteDataSet(cmd);

                return dataSet;
            }
            catch (Exception ex)
            {
                throw;
            }
        }





    }
}
