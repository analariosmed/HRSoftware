using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Security.Cryptography;


namespace Lab1_ConnectedMode.DAL
{
    public class UtilityDB
    {
        public static SqlConnection GetDBConnection()
        {
            //SqlConnection connDB = new SqlConnection();
            //connDB.ConnectionString = @"server=LAPTOP-ANA\SQLEXPRESS;
            //    database = EmployeeDB;user=sa;password=Ae8185281";
            //connDB.Open();
            //return connDB;

           // Version 2
            SqlConnection connDB = new SqlConnection();
            connDB.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            connDB.Open();
            return connDB;
        }
    }
}
