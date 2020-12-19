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
using Xamarin.Forms.PlatformConfiguration;

namespace TicariOtomasyonDevExpress
{
    public partial class frmProducts : Form
    {
        public frmProducts()
        {
            InitializeComponent();
        }
        DBCon localdb = new DBCon();

        void GetProducts()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Products",localdb.DB());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        void InsertProducts()
        {
            SqlCommand sql = new SqlCommand("Insert into Products (Name,Brand,Model,ProductionDate,Quantity,PurchasePrice,SalePrice,Detail) values (@Name,@Brand,@Model,@ProductionDate,@Quantity,@PurchasePrice,@SalePrice,@Detail)",localdb.DB());
            sql.Parameters.AddWithValue("@Name", txtProductName.Text);
            sql.Parameters.AddWithValue("@Brand", txtProductBrand.Text);
            sql.Parameters.AddWithValue("@Model", txtProductModel.Text);
            sql.Parameters.AddWithValue("@ProductionDate", txtProductYear.Text);
            sql.Parameters.AddWithValue("@Quantity", int.Parse((nudProductQuantity.Value).ToString()));
            sql.Parameters.AddWithValue("@PurchasePrice", decimal.Parse(txtProductBuyingPrice.Text));
            sql.Parameters.AddWithValue("@SalePrice", decimal.Parse(txtProductSellingPrice.Text));
            sql.Parameters.AddWithValue("@Detail", txtProductDetail.Text);
            sql.ExecuteNonQuery();
            localdb.DB().Close();
            XtraMessageBox.Show("Ürün Sisteme Eklendi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        void UpdateProducts()
        {
            SqlCommand sql = new SqlCommand("update Products set Name=@Name,Brand=@Brand,Model=@Model,ProductionDate=@ProductionDate,Quantity=@Quantity,PurchasePrice=@PurchasePrice,SalePrice=@SalePrice,Detail=@Detail where ID=@ID ", localdb.DB());
            sql.Parameters.AddWithValue("@ID", txtID.Text);
            sql.Parameters.AddWithValue("@Name", txtProductName.Text);
            sql.Parameters.AddWithValue("@Brand", txtProductBrand.Text);
            sql.Parameters.AddWithValue("@Model", txtProductModel.Text);
            sql.Parameters.AddWithValue("@ProductionDate", txtProductYear.Text);
            sql.Parameters.AddWithValue("@Quantity", int.Parse((nudProductQuantity.Value).ToString()));
            sql.Parameters.AddWithValue("@PurchasePrice", decimal.Parse(txtProductBuyingPrice.Text));
            sql.Parameters.AddWithValue("@SalePrice", decimal.Parse(txtProductSellingPrice.Text));
            sql.Parameters.AddWithValue("@Detail", txtProductDetail.Text);
            sql.ExecuteNonQuery();
            localdb.DB().Close();
            XtraMessageBox.Show("Ürün Sistemde Güncellendi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        void DeleteProducts()
        {
            SqlCommand sql = new SqlCommand("delete from Products where ID=@ID", localdb.DB());
            sql.Parameters.AddWithValue("@ID", txtID.Text);
            sql.ExecuteNonQuery();
            localdb.DB().Close();
            XtraMessageBox.Show("Ürün Sistemden Silindi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void frmProducts_Load(object sender, EventArgs e)
        {
            GetProducts();
        }

        private void btnProductSave_Click(object sender, EventArgs e)
        {
            DialogResult result = XtraMessageBox.Show("Ürünü eklemek istiyor musunuz?", "Son Kararınız Mı?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                InsertProducts();
                GetProducts();
            }
        }

        private void btnProductDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = XtraMessageBox.Show("Ürünü silmek istiyor musunuz?", "Son Kararınız Mı?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                DeleteProducts();
                GetProducts();
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            txtID.Text = dr["ID"].ToString();
            txtProductName.Text = dr["Name"].ToString();
            txtProductBrand.Text = dr["Brand"].ToString();
            txtProductModel.Text = dr["Model"].ToString();
            txtProductYear.Text = dr["ProductionDate"].ToString();
            nudProductQuantity.Value = int.Parse(dr["Quantity"].ToString());
            txtProductBuyingPrice.Text = dr["PurchasePrice"].ToString();
            txtProductSellingPrice.Text = dr["SalePrice"].ToString();
            txtProductDetail.Text = dr["Detail"].ToString();
        }

        private void btnProductUpdate_Click(object sender, EventArgs e)
        {
            DialogResult result = XtraMessageBox.Show("Ürünü güncellemek istiyor musunuz?", "Son Kararınız Mı?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                UpdateProducts();
                GetProducts();
            }
        }

        private void PDF_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "PDF Dosyaları (*.pdf)|*.pdf";
            
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (sfd.FileName.EndsWith(".pdf"))
                    {
                        gridView1.ExportToPdf(sfd.FileName);
                        System.Diagnostics.Process.Start(sfd.FileName);
                    }
                    

                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message);
                }
            }
        }

        private void Excel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Dosyaları (*.xlsx)|*.xlsx";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DevExpress.XtraPrinting.XlsxExportOptions opt = new DevExpress.XtraPrinting.XlsxExportOptions();
                    opt.ExportMode = DevExpress.XtraPrinting.XlsxExportMode.SingleFile;
                    opt.SheetName = "Ürünler";
                    opt.TextExportMode = DevExpress.XtraPrinting.TextExportMode.Value;
                    gridView1.ExportToXlsx(sfd.FileName, opt);
                    System.Diagnostics.Process.Start(sfd.FileName);

                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message);
                }
            }
        }
    }
}
