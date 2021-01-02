using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Charts;

namespace TicariOtomasyonDevExpress
{
    public partial class frmCart : Form
    {
        DBCon localdb = new DBCon();
        public frmCart()
        {
            InitializeComponent();
        }

        private void frmCart_Load(object sender, EventArgs e)
        {
            GetCompanyActions();
            GetCustomerActions();
            GetExpenses();
            SqlCommand total = new SqlCommand("select sum((id.TotalPrice)-(pr.Quantity*pr.PurchasePrice)) from products pr inner join [InvoiceDetail] id on id.ProductName = pr.Name", localdb.DB());
            SqlDataReader totalread = total.ExecuteReader();
            while (totalread.Read())
            {
                lblTotalPrice.Text = totalread[0].ToString() + " ₺";
            }
            SqlCommand EXP = new SqlCommand("SELECT TOP 1 ([ElectricityInvoice]+[WaterInvoice]+[GasInvoice]+[InternetInvoice]+[Salaries]+[Extras]) FROM Expenses ORDER BY ID DESC", localdb.DB());
            SqlDataReader EXPR = EXP.ExecuteReader();
            while (EXPR.Read())
            {
                lblPayments.Text = EXPR[0].ToString() + " ₺";
            }
            SqlCommand Salaries = new SqlCommand("SELECT TOP 1 Salaries FROM Expenses ORDER BY ID DESC", localdb.DB());
            SqlDataReader Salariesr = Salaries.ExecuteReader();
            while (Salariesr.Read())
            {
                lblPersonalSalaries.Text = Salariesr[0].ToString() + " ₺";
            }
            SqlCommand CustomerCount = new SqlCommand("select count(*) from Customers", localdb.DB());
            SqlDataReader CustomerCountr = CustomerCount.ExecuteReader();
            while (CustomerCountr.Read())
            {
                lblCustomerCount.Text = CustomerCountr[0].ToString();
            }
            SqlCommand CompanyCount = new SqlCommand("select count(*) from Companies", localdb.DB());
            SqlDataReader CompanyCountr = CompanyCount.ExecuteReader();
            while (CompanyCountr.Read())
            {
                lblCompanyCount.Text = CompanyCountr[0].ToString();
            }
            SqlCommand CustomerCityCount = new SqlCommand("select count(distinct(AddressCity)) from Customers", localdb.DB());
            SqlDataReader CustomerCityCountr = CustomerCityCount.ExecuteReader();
            while (CustomerCityCountr.Read())
            {
                lblCustomerCity.Text = CustomerCityCountr[0].ToString();
            }
            SqlCommand CompanyCityCount = new SqlCommand("select count(distinct(AddressCity)) from Companies", localdb.DB());
            SqlDataReader CompanyCityCountr = CompanyCityCount.ExecuteReader();
            while (CompanyCityCountr.Read())
            {
                lblCompanyCity.Text = CompanyCityCountr[0].ToString();
            }
            SqlCommand EmployeeCount = new SqlCommand("select count(*) FROM Employees", localdb.DB());
            SqlDataReader EmployeeCountr = EmployeeCount.ExecuteReader();
            while (EmployeeCountr.Read())
            {
                lblPersonalCount.Text = EmployeeCountr[0].ToString();
            }
            SqlCommand ProductCount = new SqlCommand("SELECT sum(Quantity) FROM Products", localdb.DB());
            SqlDataReader ProductCountr = ProductCount.ExecuteReader();
            while (ProductCountr.Read())
            {
                lblStockCount.Text = ProductCountr[0].ToString();
            }

            //1.CHART CONTROL

            SqlCommand Chart1 = new SqlCommand("select top 4 Period,ElectricityInvoice from Expenses order by ID DESC", localdb.DB());
            SqlDataReader Chart1r = Chart1.ExecuteReader();
            while (Chart1r.Read())
            {
                chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(Chart1r[0], Chart1r[1]));
            }
            //2.CHART CONTROL

            SqlCommand Chart2 = new SqlCommand("select top 4 Period,WaterInvoice from Expenses order by ID DESC", localdb.DB());
            SqlDataReader Chart2r = Chart2.ExecuteReader();
            while (Chart2r.Read())
            {
                chartControl2.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(Chart2r[0], Chart2r[1]));
            }
            localdb.DB().Close();
        }
        void GetExpenses()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("Select * from Expenses", localdb.DB());
                da.Fill(dt);
                gridControl1.DataSource = dt;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        void GetCustomerActions()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("Execute spGetAllCustomerActions", localdb.DB());
                da.Fill(dt);
                gridControl3.DataSource = dt;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        void GetCompanyActions()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("Execute spGetAllCompanyActions", localdb.DB());
                da.Fill(dt);
                gridControl1.DataSource = dt;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void chartControl1_Click(object sender, EventArgs e)
        {

        }
    }
}
