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
    public partial class frmExpenses : Form
    {
        DBCon localdb = new DBCon();
        public frmExpenses()
        {
            InitializeComponent();
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
        void InsertExpenses()
        {
            try
            {
                SqlCommand sql = new SqlCommand("Insert into Expenses (Period,ElectricityInvoice,WaterInvoice,GasInvoice,InternetInvoice,Salaries,Extras,ExtrasInfo) values (@Period,@ElectricityInvoice,@WaterInvoice,@GasInvoice,@InternetInvoice,@Salaries,@Extras,@ExtrasInfo)", localdb.DB());
                sql.Parameters.AddWithValue("@Period", txtPeriod.Text);
                sql.Parameters.AddWithValue("@ElectricityInvoice", decimal.Parse(txtElectricty.Text));
                sql.Parameters.AddWithValue("@WaterInvoice", decimal.Parse(txtWater.Text));
                sql.Parameters.AddWithValue("@GasInvoice", decimal.Parse(txtGas.Text));
                sql.Parameters.AddWithValue("@InternetInvoice", decimal.Parse(txtInternet.Text));
                sql.Parameters.AddWithValue("@Salaries", decimal.Parse(txtSalaries.Text));
                sql.Parameters.AddWithValue("@Extras", decimal.Parse(txtExtras.Text));
                sql.Parameters.AddWithValue("@ExtrasInfo", txtExtrasDetail.Text);
                sql.ExecuteNonQuery();
                localdb.DB().Close();
                XtraMessageBox.Show("Giderler Sisteme Eklendi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        void DeleteExpenses()
        {
            try
            {
                SqlCommand sql = new SqlCommand("Delete from Expenses where ID=@ID", localdb.DB());
                sql.Parameters.AddWithValue("@ID", txtID.Text);
                sql.ExecuteNonQuery();
                localdb.DB().Close();
                XtraMessageBox.Show("Giderler Sistemden Silindi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        void UpdateExpenses(DateTime UpdateTime)
        {
            try
            {
                SqlCommand sql = new SqlCommand("update Expenses set Period=@Period,ElectricityInvoice=@ElectricityInvoice,WaterInvoice=@WaterInvoice,GasInvoice=@GasInvoice,InternetInvoice=@InternetInvoice,Salaries=@Salaries,Extras=@Extras,ExtrasInfo=@ExtrasInfo,UpdateDate=@UpdateDate where ID=@ID ", localdb.DB());
                sql.Parameters.AddWithValue("@Period", txtPeriod.Text);
                sql.Parameters.AddWithValue("@ElectricityInvoice", decimal.Parse(txtElectricty.Text));
                sql.Parameters.AddWithValue("@WaterInvoice", decimal.Parse(txtWater.Text));
                sql.Parameters.AddWithValue("@GasInvoice", decimal.Parse(txtGas.Text));
                sql.Parameters.AddWithValue("@InternetInvoice", decimal.Parse(txtInternet.Text));
                sql.Parameters.AddWithValue("@Salaries", decimal.Parse(txtSalaries.Text));
                sql.Parameters.AddWithValue("@Extras", decimal.Parse(txtExtras.Text));
                sql.Parameters.AddWithValue("@ExtrasInfo", txtExtrasDetail.Text);
                sql.Parameters.AddWithValue("@UpdateDate", UpdateTime);
                sql.Parameters.AddWithValue("@ID", txtID.Text);
                sql.ExecuteNonQuery();
                localdb.DB().Close();
                XtraMessageBox.Show("Giderler Sistemde Güncellendi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        private void frmExpenses_Load(object sender, EventArgs e)
        {
            GetExpenses();
        }
        private void btnExpensesSave_Click(object sender, EventArgs e)
        {
            DialogResult result = XtraMessageBox.Show("Giderleri kaydetmek istiyor musunuz?", "Son Kararınız Mı?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                InsertExpenses();
                GetExpenses();
            }
        }
        private void btnExpensesDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = XtraMessageBox.Show("Giderleri silmek istiyor musunuz?", "Son Kararınız Mı?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                DeleteExpenses();
                GetExpenses();
            }
        }
        private void btnExpensesUpdate_Click(object sender, EventArgs e)
        {
            DateTime updateTime = DateTime.Now;
            DialogResult result = XtraMessageBox.Show("Giderleri güncellemek istiyor musunuz?", "Son Kararınız Mı?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                UpdateExpenses(updateTime);
                GetExpenses();
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
                    opt.SheetName = "Personeller";
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
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            txtID.Text = dr["ID"].ToString();
            txtPeriod.Text = dr["Period"].ToString();
            txtElectricty.Text = dr["ElectricityInvoice"].ToString();
            txtWater.Text = dr["WaterInvoice"].ToString();
            txtGas.Text = dr["GasInvoice"].ToString();
            txtInternet.Text = dr["InternetInvoice"].ToString();
            txtSalaries.Text = dr["Salaries"].ToString();
            txtExtras.Text = dr["Extras"].ToString();
            txtExtrasDetail.Text = dr["ExtrasInfo"].ToString();
        }
    }
}
