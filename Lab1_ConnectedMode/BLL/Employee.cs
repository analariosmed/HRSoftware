using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Lab1_ConnectedMode.DAL; //add




namespace Lab1_ConnectedMode.BLL
{
    public class Employee
    {
        //properties
        private int employeeNumber;
        private string firstName;
        private string lastName;
        private string jobTitle;

        //encaptulation
        public int EmployeeNumber { get => employeeNumber; set => employeeNumber = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string JobTitle { get => jobTitle; set => jobTitle = value; }

        //constructor
        public Employee() 
        {
            EmployeeNumber = 0;
            FirstName = string.Empty;
            LastName = string.Empty;
            JobTitle = string.Empty;
        }

        public Employee(int employeeNumber, string firstName, string lastName, string jobTitle)
        {
            this.employeeNumber = employeeNumber;
            this.firstName = firstName;
            this.lastName = lastName;
            this.jobTitle = jobTitle;          
        }

        public void SaveEmployee(Employee employee)
        {
            EmployeeDB.SaveRecord(employee);
        }


        public List<Employee> GetEmployees()
        {
            return EmployeeDB.GetAllRecords();
        }

        public bool IsUniqueNumber(int employeeNumber)
        {
            bool existing = EmployeeDB.IsAnExistingNumber(employeeNumber);

            return existing;
        }

        public void UpdateEmployee(Employee employee)
        {
            EmployeeDB.UpdateEmployee(employee);
        }

        public void DeleteEmployee(Employee employee)
        {
            EmployeeDB.Delete(employee.employeeNumber);
        }

        public List<Employee> SearchEmployee (int comboBoxValue ,string inputFirstName, string inputLastName, int eNumb)
        {
            switch (comboBoxValue)
            {
                case 0:
                    // labelDisplay.Text = "Enter Employee Number";
                    List<Employee> list = new List<Employee> ();
                    list.Add(EmployeeDB.SearchById(eNumb));
                    return list ;
                   
                case 1:
                    //labelDisplay.Text = "Enter First Name :";
                    return EmployeeDB.SearchByFirstName(inputFirstName);
                   

                case 2:
                    //  labelDisplay.Text = "Enter Last Name :";
                    return EmployeeDB.SearchByLastName(inputLastName);
                    

                case 3:
                    // labelDisplay.Text = "Enter First Name :";
                    //labelDisplay2.Text = "Enter Last Name :";
                    return EmployeeDB.SearchByBoth(inputFirstName, inputLastName);
                default:
                    Console.WriteLine(" Employeee dont found");
                    return new List<Employee>();
            }
        }
    }
}
