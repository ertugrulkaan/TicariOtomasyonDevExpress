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
    public partial class frmInvoiceDetail : Form
    {
        //TODO: BURADA EKLENEN DETAY ÜRÜNLER PRODUCTSDAN GELSİN ORDA OLMAYAN ÜRÜN EKLENEMESİN.
        DBCon localdb = new DBCon();
        public string id;
        double price = 0;
        public frmInvoiceDetail()
        {
            InitializeComponent();
        }
        void InsertInvoiceDetails()
        {
            try
            {
                SqlCommand sql = new SqlCommand("insert into InvoiceDetail (InvoiceID,ProductName,Quantity,UnitPrice,TotalPrice) values (@InvoiceID,@ProductName,@Quantity,@UnitPrice,@TotalPrice)", localdb.DB());
                sql.Parameters.AddWithValue("@InvoiceID", txtInvoiceID.Text);
                sql.Parameters.AddWithValue("@ProductName", txtProductName.Text);
                sql.Parameters.AddWithValue("@Quantity", txtQuantity.Text);
                sql.Parameters.AddWithValue("@UnitPrice", double.Parse(txtUnitPrice.Text));
                sql.Parameters.AddWithValue("@TotalPrice", double.Parse(txtTotalPrice.Text));
                sql.ExecuteNonQuery();
                localdb.DB().Close();
                XtraMessageBox.Show("Faturaya ait satışı yapılan ürün sisteme kayıt edildi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        void GetInvoiceDetail()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("Execute spGetInvoiceDetailbyActiveInvoiceID @InvoiceID=@p1", localdb.DB());
                da.SelectCommand.Parameters.AddWithValue("@p1", id);
                da.Fill(dt);
                gridControl1.DataSource = dt;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        void DeleteInvoiceDetail()
        {
            try
            {
                SqlCommand sql = new SqlCommand("Delete from InvoiceDetail where ID=@ID", localdb.DB());
                sql.Parameters.AddWithValue("@ID", txtProductID.Text);
                sql.ExecuteNonQuery();
                localdb.DB().Close();
                XtraMessageBox.Show("Ürün faturadan silindi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        void UpdateInvoiceDetail()
        {
            try
            {
                SqlCommand sql = new SqlCommand("Update InvoiceDetail set ProductName=@ProductName,Quantity=@Quantity,UnitPrice=@UnitPrice,TotalPrice=@TotalPrice where ID=@ID", localdb.DB());
                sql.Parameters.AddWithValue("@ProductName", txtProductName.Text);
                sql.Parameters.AddWithValue("@Quantity", int.Parse(txtQuantity.Text));
                sql.Parameters.AddWithValue("@UnitPrice", double.Parse(txtUnitPrice.Text));
                CalcProductPrice();
                sql.Parameters.AddWithValue("@TotalPrice", price);
                sql.Parameters.AddWithValue("@ID", txtProductID.Text);
                sql.ExecuteNonQuery();
                localdb.DB().Close();
                XtraMessageBox.Show("Satılan ürün faturada güncellendi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void frmInvoiceDetail_Load(object sender, EventArgs e)
        {
            GetInvoiceDetail();
        }
        double CalcProductPrice()
        {
            try
            {
                if (txtUnitPrice.Text != null && txtQuantity.Text != null)
                {
                    price = double.Parse(txtQuantity.Text) * double.Parse(txtUnitPrice.Text);
                }
            }
            catch (Exception ex)
            {
            }
            return price;
        }
        private void btnInvoiceDetailSave_Click(object sender, EventArgs e)
        {
            DialogResult result = XtraMessageBox.Show("Faturaya ait satışı yapılan ürünü kaydetmek istiyor musunuz?", "Son Kararınız Mı?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                CalcProductPrice();
                txtTotalPrice.Text = price.ToString();
                InsertInvoiceDetails();
                GetInvoiceDetail();
            }
        }       
        private void btnCalc_Click(object sender, EventArgs e)
        {
            CalcProductPrice();
            txtTotalPrice.Text = price.ToString();
        }
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                txtProductID.Text = dr["ID"].ToString();
                txtProductName.Text = dr["ProductName"].ToString();
                txtQuantity.Text = dr["Quantity"].ToString();
                txtUnitPrice.Text = dr["UnitPrice"].ToString();
                txtTotalPrice.Text = dr["TotalPrice"].ToString();
                txtInvoiceID.Text = dr["InvoiceID"].ToString();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnInvoiceDetailDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = XtraMessageBox.Show("Faturaya ait satışı yapılan ürünü silmek istiyor musunuz?", "Son Kararınız Mı?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                DeleteInvoiceDetail();
                GetInvoiceDetail();
            }
        }
        private void btnInvoiceDetailUpdate_Click(object sender, EventArgs e)
        {
            DialogResult result = XtraMessageBox.Show("Faturaya ait satışı yapılan ürünü güncelleme istiyor musunuz?", "Son Kararınız Mı?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                UpdateInvoiceDetail();
                GetInvoiceDetail();
            }
        }
    }
}
