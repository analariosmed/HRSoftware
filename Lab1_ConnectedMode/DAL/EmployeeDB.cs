using Lab1_ConnectedMode.BLL;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1_ConnectedMode.BLL; //to use the form here
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms; //add for db


namespace Lab1_ConnectedMode.DAL
{
    public static class EmployeeDB
    {
        //public static void SaveRecord(Employee employee)
        //{
        //    SqlConnection conn = UtilityDB.GetDBConnection();

        //    ///SQLcommand provide a SQL Statement(insert/delete/update/select)
        //    ///paso1: create an object
        //    ///THIS IS THE VERSION 1 but is not good (problrem:SQL injeccion)
        //    SqlCommand cmdInsert = new SqlCommand();
        //    cmdInsert.Connection = conn;
        //    // VALUES TO ENTER (333,'Ana','Larios','Programming')
        //    cmdInsert.CommandText = "INSERT INTO Employees " +
        //     "VALUES (" + employee.EmployeeNumber + "," +
        //                "'" + employee.FirstName + "'," +
        //                "'" + employee.LastName + "'," +
        //                "'" + employee.JobTitle + "')";

        //    //writte the sequence statement (line to execute)
        //    cmdInsert.ExecuteNonQuery();
        //    conn.Close();


        //}

        public static void SaveRecord(Employee employee)
        {
            SqlConnection conn = UtilityDB.GetDBConnection();

            ///SQLcommand provide a SQL Statement(insert/delete/update/select)
            ///paso1: create an object
            ///this version doesnt inject the data so we gonna using the parameters
            ///@IS A PLACEHOLDER
            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.Connection = conn;
            cmdInsert.CommandText = "INSERT INTO Employees (EmployeeNumber,FirstName,LastName,JobTitle)" +
                                            "VALUES(@EmployeeNumber,@FirstName,@LastyName,@JobTitle)";

            cmdInsert.Parameters.AddWithValue("@EmployeeNumber", employee.EmployeeNumber);
            cmdInsert.Parameters.AddWithValue("@FirstName", employee.FirstName);
            cmdInsert.Parameters.AddWithValue("@LastyName", employee.LastName);
            cmdInsert.Parameters.AddWithValue("@JobTitle", employee.JobTitle);

            //write the sequence statement (line to execute)
            cmdInsert.ExecuteNonQuery();
            conn.Close();

        } 
            //method 
          public static List<Employee> GetAllRecords()
           {
            List<Employee> listE = new List<Employee>();
            SqlConnection conn = UtilityDB.GetDBConnection();
            SqlCommand cmdSelectAll = new SqlCommand("SELECT * FROM Employees", conn);
            SqlDataReader reader = cmdSelectAll.ExecuteReader(); //applied to select statement
            Employee employee ;
            while (reader.Read())
            {
               employee = new Employee();
               employee.EmployeeNumber = Convert.ToInt32(reader["EmployeeNumber"]);
               employee.FirstName = reader["FirstName"].ToString();
               employee.LastName = reader["LastName"].ToString();
               employee.JobTitle = reader["JobTitle"].ToString();
               listE.Add(employee);

            }
            conn.Close();
            return listE;
           }

// a method to search a student by studentId
//overloaded methods : Two methods having the same
//                     name but different signature are
//                     called overloaded methods
        public static Employee SearchById (int eNumb)
        {
            SqlConnection conn = UtilityDB.GetDBConnection();
            SqlCommand cmdSelectAll = new SqlCommand("SELECT * FROM Employees WHERE EmployeeNumber = " + eNumb, conn);
            //cmdSelectAll.Parameters.AddWithValue("@eNumb", eNumb);

            SqlDataReader reader = cmdSelectAll.ExecuteReader(); //applied to select statement
            Employee employee;
            employee = new Employee();
            reader.Read();
            employee.EmployeeNumber = Convert.ToInt32(reader["EmployeeNumber"]);
            employee.FirstName = reader["FirstName"].ToString();
            employee.LastName = reader["LastName"].ToString();
            employee.JobTitle = reader["JobTitle"].ToString();
            conn.Close();
            return employee;
        }

        public static List<Employee> SearchByFirstName(string inputFirstName)
        {
            List<Employee> listE = new List<Employee>();

            SqlConnection conn = UtilityDB.GetDBConnection();
            SqlCommand cmdSelectAll = new SqlCommand("SELECT * FROM Employees WHERE FirstName= @inputFirstName", conn);
            cmdSelectAll.Parameters.AddWithValue("@inputFirstName", inputFirstName);

            SqlDataReader reader = cmdSelectAll.ExecuteReader(); //applied to select statement
            Employee employee;
            while (reader.Read())
            {
                employee = new Employee();
                employee.EmployeeNumber = Convert.ToInt32(reader["EmployeeNumber"]);
                employee.FirstName = reader["FirstName"].ToString();
                employee.LastName = reader["LastName"].ToString();
                employee.JobTitle = reader["JobTitle"].ToString();
                listE.Add(employee);

            }
            conn.Close();
            return listE;


        }

        public static List<Employee> SearchByLastName(string inputLastName)
        {
            List<Employee> listE = new List<Employee>();

            SqlConnection conn = UtilityDB.GetDBConnection();
            SqlCommand cmdSelectAll = new SqlCommand("SELECT * FROM Employees WHERE LastName= @inputLastName", conn);
            cmdSelectAll.Parameters.AddWithValue("@inputLastName", inputLastName);

            SqlDataReader reader = cmdSelectAll.ExecuteReader(); //applied to select statement
            Employee employee;
            while (reader.Read())
            {
                employee = new Employee();
                employee.EmployeeNumber = Convert.ToInt32(reader["EmployeeNumber"]);
                employee.FirstName = reader["FirstName"].ToString();
                employee.LastName = reader["LastName"].ToString();
                employee.JobTitle = reader["JobTitle"].ToString();
                listE.Add(employee);

            }
            conn.Close();
            return listE;

        }

        public static List<Employee> SearchByBoth(string inputFirstName, string inputLastName)
        {
            List<Employee> listE = new List<Employee>();

            SqlConnection conn = UtilityDB.GetDBConnection();
            SqlCommand cmdSelectAll = new SqlCommand("SELECT * FROM Employees WHERE FirstName = @inputFirstName AND LastName= @inputLastName", conn);
            cmdSelectAll.Parameters.AddWithValue("@inputFirstName", inputFirstName);
            cmdSelectAll.Parameters.AddWithValue("@inputLastName", inputLastName);

            SqlDataReader reader = cmdSelectAll.ExecuteReader(); //applied to select statement
            Employee employee;
            while (reader.Read())
            {
                employee = new Employee();
                employee.EmployeeNumber = Convert.ToInt32(reader["EmployeeNumber"]);
                employee.FirstName = reader["FirstName"].ToString();
                employee.LastName = reader["LastName"].ToString();
                employee.JobTitle = reader["JobTitle"].ToString();
                listE.Add(employee);

            }
            conn.Close();
            return listE;

        }

        public static bool IsAnExistingNumber(int eNumb)
        {
            List<Employee> listE = new List<Employee>();
            SqlConnection conn = UtilityDB.GetDBConnection();
            SqlCommand cmdSelectAll = new SqlCommand("SELECT * FROM Employees WHERE EmployeeNumber = " + eNumb, conn);
            SqlDataReader reader = cmdSelectAll.ExecuteReader(); //applied to select statement
            Employee employee;
            while (reader.Read())
            {
                employee = new Employee();
                employee.EmployeeNumber = Convert.ToInt32(reader["EmployeeNumber"]);
                listE.Add(employee);
            }
            conn.Close();

            if (listE.Count != 0 )
            {

                return true;
            }
            else
            {
                return false;
            }
           
        }

        //public static bool IsUnique_v2 (int emp)
        //{
        //    List<Employee> listE = GetAllRecords();
            
        //    foreach (Employee em in listE)
        //        {
                
        //        if (em.EmployeeNumber == emp)
        //         {  
        //            return true; 
        //        }
        //    }
        //    return true;
        //}

        public static void UpdateEmployee(Employee employeeUpdated)
        {
            using (SqlConnection conn = UtilityDB.GetDBConnection())
            {

                SqlCommand cmdUpdate = new SqlCommand();
                cmdUpdate.Connection = conn;
                cmdUpdate.CommandText = "UPDATE Employees " +
                    "SET FirstName=@FirstName, " +
                         "LastName=@LastName, " +
                         "JobTitle=@JobTitle " +
                         "WHERE EmployeeNumber = @EmployeeNumber ";
                cmdUpdate.Parameters.AddWithValue("@EmployeeNumber", employeeUpdated.EmployeeNumber);
                cmdUpdate.Parameters.AddWithValue("@FirstName", employeeUpdated.FirstName);
                cmdUpdate.Parameters.AddWithValue("@LastName", employeeUpdated.LastName);
                cmdUpdate.Parameters.AddWithValue("@JobTitle", employeeUpdated.JobTitle);
                cmdUpdate.ExecuteNonQuery();

            }

            
        }

        public static void Delete(int empNumb)
        {
            SqlConnection conn = UtilityDB.GetDBConnection();
            try
            {  
                SqlCommand cmdDelete = new SqlCommand();
                cmdDelete.Connection = conn;
                cmdDelete.CommandText = "DELETE Employees " +
                                        "WHERE EmployeeNumber=@EmployeeNumber";
                cmdDelete.Parameters.AddWithValue("@EmployeeNumber", empNumb);
                cmdDelete.ExecuteNonQuery();

            }
            catch(SqlException ex) 
            {
             throw ex;
            
            }
            finally
            {
                conn.Close();
            }
        }
    }
}

