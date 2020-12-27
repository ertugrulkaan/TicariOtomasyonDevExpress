using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicariOtomasyonDevExpress
{
    public partial class frmReports : Form
    {
        public frmReports()
        {
            InitializeComponent();
        }

        private void frmReports_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ExpensesDataSet.Expenses' table. You can move, or remove it, as needed.
            this.ExpensesTableAdapter.Fill(this.ExpensesDataSet.Expenses);
            // TODO: This line of code loads data into the 'EmployeeDataSet.Employees' table. You can move, or remove it, as needed.
            this.EmployeesTableAdapter.Fill(this.EmployeeDataSet.Employees);
            // TODO: This line of code loads data into the 'CompaniesDataSet.Companies' table. You can move, or remove it, as needed.
            this.CompaniesTableAdapter.Fill(this.CompaniesDataSet.Companies);
            // TODO: This line of code loads data into the 'CustomerDataSet.Customers' table. You can move, or remove it, as needed.
            this.CustomersTableAdapter.Fill(this.CustomerDataSet.Customers);

            this.reportViewer1.RefreshReport();
            this.reportViewer2.RefreshReport();
            this.reportViewer3.RefreshReport();
            this.reportViewer4.RefreshReport();
        }
    }
}
