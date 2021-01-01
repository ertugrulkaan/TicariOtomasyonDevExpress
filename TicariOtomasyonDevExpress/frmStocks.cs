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

namespace TicariOtomasyonDevExpress
{
    public partial class frmStocks : Form
    {
        DBCon localdb = new DBCon(); 
        DataTable dt = new DataTable();
        public frmStocks()
        {
            InitializeComponent();
        }
        void GetProducts()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Select Name,SUM(Quantity) as Quantity from Products group by Name", localdb.DB());
                da.Fill(dt);
                gridControl1.DataSource = dt;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        void GetProductDetails(string productName)
        {
            try
            {
                DataTable dt1 = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("execute spGetProductsByName @ProductName=@productName", localdb.DB());
                da.SelectCommand.Parameters.AddWithValue("@productName", productName);
                da.Fill(dt1);
                gridControl2.DataSource = dt1;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void frmStocks_Load(object sender, EventArgs e)
        {
            GetProducts();
        }
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                var product = dr["Name"].ToString();
                GetProductDetails(product);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
