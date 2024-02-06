using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using Lab1_ConnectedMode.DAL; //for testing 
using System.Data.SqlClient;
using Lab1_ConnectedMode.BLL; // to use the class employee
using Lab1_ConnectedMode.VALIDATION;
using Lab1_ConnectedMode.DAL; //to use GUI


namespace Lab1_ConnectedMode.GUI
{
    public partial class FormEmployee : Form
    {
        public FormEmployee()
        {
            InitializeComponent();
        }

        int valueComboBox;
        private void FormEmployee_Load(object sender, EventArgs e) //CODE doble click in the form for make visible and invisible some tools 
        {
            labelDisplay.Visible = false;
            labelDisplay2.Visible = false;
            textBoxInput.Visible = false;
            textBoxInput2.Visible = false;
        }

        //private void buttonConnectDB_Click(object sender, EventArgs e)
        //{
        //    SqlConnection connDB = UtilityDB.GetDBConnection();
        //    MessageBox.Show("Database connection is" + connDB.State.ToString(), "Database Connection");
        //}

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            //Employee employee = new Employee(7777777,"Ana","Larios", "Programming");
            //EmployeeDB.SaveRecord(employee);
            //MessageBox.Show("Save sucessfully!","Configuration");


            //input validation
            string input = "";
            input = textBoxEmployeeNumber.Text.Trim();
            if (!Validator.IsValid(input, 7))
            {
                MessageBox.Show("Invalid Employee Id, must be 7 digits");
                textBoxEmployeeNumber.Clear();
                textBoxEmployeeNumber.Focus();
                return;
            }


            //validate duplicate id
            Employee employee = new Employee();
            if (employee.IsUniqueNumber(Convert.ToInt32(input))==true)
            {
                MessageBox.Show("This employee exist already.", "Duplicate Employee Number", MessageBoxButtons.OK,MessageBoxIcon.Error);
                textBoxEmployeeNumber.Clear();
                textBoxEmployeeNumber.Focus();
                return;
            }

            //validation first name just letters and spaces
            input = textBoxFirstName.Text.Trim();
            if (!Validator.IsValidName(input))
            {
                MessageBox.Show("Invalid First Name, must be just letters");
                textBoxFirstName.Clear();
                textBoxFirstName.Focus();
                return;
            }

            //validate last name just letters and spaces
            input = textBoxLastName.Text.Trim();
            if (!Validator.IsValidName(input))
            {
                MessageBox.Show("Invalid Last Name, must be just letters");
                textBoxLastName.Clear();
                textBoxLastName.Focus();
                return;
            }


            employee.EmployeeNumber = Convert.ToInt32(textBoxEmployeeNumber.Text.Trim());
            employee.FirstName = textBoxFirstName.Text.Trim();
            employee.LastName = textBoxLastName.Text.Trim();
            employee.JobTitle = textBoxJobTitle.Text.Trim();
            EmployeeDB.SaveRecord(employee);

            MessageBox.Show("Saved employee", "Confirmation");


            textBoxEmployeeNumber.Clear();
            textBoxFirstName.Clear();
            textBoxLastName.Clear();
            textBoxJobTitle.Clear();


        }


        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee();
            employee.EmployeeNumber = Convert.ToInt32(textBoxEmployeeNumber.Text);
            employee.FirstName = textBoxFirstName.Text;
            employee.LastName = textBoxLastName.Text;
            employee.JobTitle = textBoxJobTitle.Text;
            employee.UpdateEmployee(employee);
            MessageBox.Show("Employee data has been update sucessfully");
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee();
            employee.EmployeeNumber = Convert.ToInt32(textBoxEmployeeNumber.Text);
            employee.DeleteEmployee(employee);
            MessageBox.Show("Employee data has been deleted sucessfully");
        }

        private void buttonListAll_Click_1(object sender, EventArgs e)
        {
            listViewEmployee.Items.Clear();
            Employee employee = new Employee();
            List<Employee> listE = employee.GetEmployees();
            if (listE != null)
            {
                foreach (Employee em in listE)
                {
                    ListViewItem item = new ListViewItem(em.EmployeeNumber.ToString());
                    item.SubItems.Add(em.FirstName);
                    item.SubItems.Add(em.LastName);
                    item.SubItems.Add(em.JobTitle);
                    listViewEmployee.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show("No employees data", "Missing Data");
            }
        }

        private void comboBoxSearchBy_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBoxSearchBy.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an option" +
                MessageBoxIcon.Error + MessageBoxButtons.OK);
                return;
            }
            valueComboBox=comboBoxSearchBy.SelectedIndex;
            switch (comboBoxSearchBy.SelectedIndex)
            {
                case 0:
                    labelDisplay.Visible = true;
                    labelDisplay.Text = "Enter Employee Number";
                    textBoxInput.Visible = true; ;
                    textBoxInput.Clear();
                    textBoxInput.Focus();

                    break;

                case 1:
                    labelDisplay.Visible = true;
                    labelDisplay.Text = "Enter First Name :";
                    textBoxInput.Visible = true;
                    textBoxInput.Clear();
                    textBoxInput.Focus();
                    break;

                case 2:
                    labelDisplay2.Visible = true;
                    labelDisplay2.Text = "Enter Last Name :";
                    textBoxInput2.Visible = true;
                    textBoxInput.Clear();
                    textBoxInput.Focus();
                    break;

                case 3:
                    labelDisplay.Visible = true;
                    labelDisplay.Text = "Enter First Name :";
                    textBoxInput.Visible = true;
                    labelDisplay2.Visible = true;
                    labelDisplay2.Text = "Enter Last Name :";
                    textBoxInput2.Visible = true;
                    textBoxInput.Clear();
                    textBoxInput.Focus();
                    break;


            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {

        }
    }
}

