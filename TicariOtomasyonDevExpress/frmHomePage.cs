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
using System.Xml;

namespace TicariOtomasyonDevExpress
{
    public partial class frmHomePage : Form
    {
        DBCon localdb = new DBCon();
        public frmHomePage()
        {
            InitializeComponent();
        }
        void TOP10Comp()
        {
            
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("SELECT Name,AuthorizedPersonFullName,PhoneNumber1 FROM Companies", localdb.DB());
                da.Fill(dt);
                gctrlTop10Companies.DataSource = dt;

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
                SqlDataAdapter da = new SqlDataAdapter("Execute spGetTOP10CustomerActions", localdb.DB());
                da.Fill(dt);
                gctrlCustomer.DataSource = dt;
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
                SqlDataAdapter da = new SqlDataAdapter("Execute spGetTOP10CompanyActions", localdb.DB());
                da.Fill(dt);
                gctrlCompan.DataSource = dt;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        void Agenda()
        {
            try
            {

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("select TOP 10 Date, Name, Creator from Notes order by ID", localdb.DB());
                da.Fill(dt);
                gctrlAgenda.DataSource = dt;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        void Stocks()
        {            
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("select Name,Sum(Quantity) AS Quantity from Products GROUP BY Name HAVING Sum(Quantity)<20", localdb.DB());
                da.Fill(dt);
                gctrlStocks.DataSource = dt;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        void news()
        {
            XmlTextReader xml = new XmlTextReader("https://www.hurriyet.com.tr/rss/gundem");
            while (xml.Read())
            {
                if (xml.Name =="title")
                {
                        listBox1.Items.Add(xml.ReadString());
                }
            }
        }
        private void frmHomePage_Load(object sender, EventArgs e)
        {
            TOP10Comp();
            GetCompanyActions();
            GetCustomerActions();
            Agenda();
            Stocks();
            webBrowser1.Navigate("https://www.tcmb.gov.tr/kurlar/today.xml");
            news();
        }
    }
}
